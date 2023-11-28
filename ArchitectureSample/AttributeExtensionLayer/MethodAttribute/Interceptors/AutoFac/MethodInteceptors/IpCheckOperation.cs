using Castle.DynamicProxy;
using CoreLayer.Helper;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security;

namespace AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors
{
    public class IpCheckOperation : MethodInterception
    {

        protected override void OnBefore(IInvocation ınvocation)
        {
                HttpContext _httpContext = HttpContextHelper.GetHttpContext();
            try
            {
                IPAddress ipAddress = _httpContext.Connection.RemoteIpAddress;
                string[] strArray = new string[1] { "::1" };
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
                {
                    throw new SecurityException("Forbidden error");
                }
                else
                    return;
            }
            catch (FormatException)
            {
                throw;
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

