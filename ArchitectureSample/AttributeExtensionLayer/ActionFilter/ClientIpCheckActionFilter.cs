using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;


namespace AttributeExtensionLayer.ActionFilter
{
    public class ClientIpCheckActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress ipAddress = context.HttpContext.Connection.RemoteIpAddress;
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
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            else
                base.OnActionExecuting(context);
        }
    }
}
