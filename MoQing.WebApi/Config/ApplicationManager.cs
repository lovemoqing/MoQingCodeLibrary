using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoQing.WebApi.Config
{
    public class ApplicationManager
    {

        private static ApplicationManager _appManager;
        private IWebHost _web;
        private CancellationTokenSource _tokenSource;
        private bool _running;
        private bool _restart;

        public bool Restarting => _restart;

        public ApplicationManager()
        {
            _running = false;
            _restart = false;

        }

        public static ApplicationManager Load()
        {
            if (_appManager == null)
                _appManager = new ApplicationManager();

            return _appManager;
        }

        public void Start()
        {
            if (_running)
                return;

            if (_tokenSource != null && _tokenSource.IsCancellationRequested)
                return;

            _tokenSource = new CancellationTokenSource();
            _tokenSource.Token.ThrowIfCancellationRequested();
            _running = true;

            _web = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            _web.RunAsync(_tokenSource.Token);
        }

        public void Stop()
        {
            if (!_running)
                return;

            _tokenSource.Cancel();
            _running = false;
        }

        public void Restart()
        {
            Stop();

            _restart = true;
            _tokenSource = null;
        }
    }
}
