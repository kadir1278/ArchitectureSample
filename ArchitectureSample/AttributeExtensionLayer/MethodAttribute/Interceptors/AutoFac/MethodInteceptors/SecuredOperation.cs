using Castle.DynamicProxy;
using CoreLayer.DataAccess.Enums;
using CoreLayer.Extensions;
using CoreLayer.Helper;
using Microsoft.AspNetCore.Http;
using System.Security;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors
{
    public class SecuredOperation : MethodInterception
    {
        private List<string> _roles;
        public SecuredOperation(params PermissionEnum[] roles)
        {
            _roles = new List<string>() { "Admin" };
            foreach (var item in roles)
                _roles.Add(item.ToString());
        }

        protected override void OnBefore(IInvocation invocation)
        {
            HttpContext httpContext= HttpContextHelper.GetHttpContext();
            var roleClaims = httpContext.User.ClaimRoles();

            foreach (var item in _roles)
            {
                if (roleClaims.Contains(item))
                    return;
            }
            throw new SecurityException("Geçersiz rol yetkisi");

        }
    }
}
