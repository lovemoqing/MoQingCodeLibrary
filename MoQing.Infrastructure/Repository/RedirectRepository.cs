using MoQing.Domain;
using MoQing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure
{
    public class RedirectRepository: SqlBaseRepository<FileInfo>, IRedirectRepository
    {

    }
}
