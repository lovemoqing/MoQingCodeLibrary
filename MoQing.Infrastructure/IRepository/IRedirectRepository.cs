using Infrastructure.IRepositorie;
using MoQing.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure
{
    public interface IRedirectRepository: ISqlSugarBaseRepository<Redirect>
    {
    }
}
