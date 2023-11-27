using Castle.DynamicProxy;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security;
using System.Text.Json;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors
{
    public class IpCheckOperation : MethodInterception
    {

        protected override void OnBefore(IInvocation ınvocation)
        {
            try
            {
                HttpContext _httpContext = HttpContextHelper.GetHttpContext();

                IPAddress ipAddress = _httpContext.Connection.RemoteIpAddress;
                string[] strArray = new string[1] { "192.168.1.1" };
                bool flag = true;
                if (ipAddress.IsIPv4MappedToIPv6)
                    ipAddress = ipAddress.MapToIPv4();
                foreach (string ipString in strArray)
                {
                    if (IPAddress.Parse(ipString).Equals(ipAddress))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    throw new SecurityException(JsonSerializer.Serialize(new ErrorDataResult<bool>("Forbidden error")));
                else
                    return;
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

