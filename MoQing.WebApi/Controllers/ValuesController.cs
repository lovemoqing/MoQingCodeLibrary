using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoQing.Application.FileService;
using MoQing.Domain;
using MoQing.Infrastructure.Config;
using MoQing.Infrastructure.FileService;

namespace MoQing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IFileService _fileService;
        private readonly IMapper _mapper;
        public ValuesController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<string> Post(FileInfoDto model)
        {
            var AK = ConfigExtensions.Configuration["Qiniu:AK"];
            var user = _mapper.Map<FileInfo>(model); //映射
            FileStrategyContext context = new FileStrategyContext(new FileFactory().Create("策略名称"));
            context.Upload();
            return _fileService.GetName() + "|" + user.Name + "|" + AK; 
        }
    }
}
