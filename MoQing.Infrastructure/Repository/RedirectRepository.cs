using Infrastructure.IRepositorie;
using Infrastructure.Repositorie;
using MoQing.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure
{
    public class RedirectRepository: SqlSugarBaseRepository<Redirect>, IRedirectRepository
    {
    }
}
