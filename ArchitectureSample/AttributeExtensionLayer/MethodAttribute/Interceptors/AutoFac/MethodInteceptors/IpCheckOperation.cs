using Castle.DynamicProxy;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text.Json;

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
                {
                    _httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    throw new SecurityException("Forbidden error");
                }
                else
                    return;
            }
            catch (FormatException)
            {
                _httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                throw;
            }
            catch (SecurityException)
            {
                _httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                throw;
            }
            catch (Exception)
            {
                _httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                throw;
            }

        }
    }
}

