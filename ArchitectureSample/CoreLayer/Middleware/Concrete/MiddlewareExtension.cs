using CoreLayer.Middleware.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Middleware.Concrete
{
    public class MiddlewareExtension<TMiddleWare> : IMiddlewareExtension<TMiddleWare> where TMiddleWare : class, IMiddleware, new()
    {
       
        public IDataResult<bool> InvokeAsync(IApplicationBuilder applicationBuilder)
        {
            try
            {
                applicationBuilder.UseMiddleware<TMiddleWare>();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(ex);
            }
            throw new NotImplementedException();
        }
    }
}
