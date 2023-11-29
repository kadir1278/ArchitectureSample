using Castle.DynamicProxy;
using CoreLayer.DataAccess.Enums;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using CoreLayer.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors
{
    public class SecuredOperation : MethodInterception
    {
        private List<string> _roles;
        private HttpContext _httpContext;
        public SecuredOperation(params PermissionEnum[] roles)
        {
            _roles = new List<string>() { "Admin" };
            foreach (var item in roles)
                _roles.Add(item.ToString());
            _httpContext = HttpContextHelper.GetHttpContext();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContext.User.ClaimRoles();

            foreach (var item in _roles)
            {
                if (roleClaims.Contains(item))
                    return;
            }
            throw new SecurityException("Geçersiz rol yetkisi");

        }
    }
}
