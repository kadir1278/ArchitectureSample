using Microsoft.AspNetCore.Http;

namespace MiddlewareLayer.Middleware
{
    public class CheckProjectStatusMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                //bool projectDomainStatus = false;
                //string requestDomain = context.Request.Host.ToString().ToLower();
                ////string projectName = Assembly.GetExecutingAssembly().GetName().Name;
                //using (HttpClient httpClient = new HttpClient())
                //{
                //    httpClient.BaseAddress = new Uri($"");
                //    var result = httpClient.GetAsync(httpClient.BaseAddress).Result;
                //    projectDomainStatus = JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
                //}

                //if (projectDomainStatus)
                //    await next.Invoke(context);
                //else
                //{
                //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                //    context.Response.Redirect("");
                //}

                await next.Invoke(context);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
