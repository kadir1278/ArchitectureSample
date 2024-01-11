using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Reflection;

namespace MiddlewareLayer.Middleware
{
    public class CheckProjectStatusMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                string currentProjectName = Assembly.GetExecutingAssembly().GetName().Name;
                string currentDomain = context.Request.Host.ToString().ToLower();
                string currentDateTime = DateTime.Now.ToString("ddMMyyyy");

                bool projectDomainStatus = false;
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(String.Format("url", currentProjectName, currentDomain));
                    
                    var result = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    projectDomainStatus = JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
                }

                if (projectDomainStatus)
                    await next.Invoke(context);
                else
                    throw new Exception($"Sistem admini ile görüşünüz - {currentProjectName} - {currentDomain} - {currentDateTime}");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
