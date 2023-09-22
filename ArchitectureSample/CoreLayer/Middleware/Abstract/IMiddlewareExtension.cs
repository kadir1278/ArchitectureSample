using CoreLayer.Results.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Middleware.Abstract
{
    public interface IMiddlewareExtension<TMiddleWare> where TMiddleWare : class, IMiddleware, new()
    {
        IDataResult<bool> InvokeAsync(IApplicationBuilder applicationBuilder);
    }
}
