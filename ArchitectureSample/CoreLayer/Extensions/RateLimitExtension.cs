using CoreLayer.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Builder;
using System.Threading.RateLimiting;

namespace CoreLayer.Extensions
{
    public static class RateLimitExtension
    {
        /// <summary>
        /// tetiklenmesi için "app.UseRateLimiter();" komutunun program.cs içerisine eklenmiş olması gerekmektedir
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="policyName"></param>
        /// kullanmak istediğiniz limit modelinin tanım ismi
        /// <param name="limitTimeRange"></param>
        /// limit süresinin belirlenmesi içindır
        /// <param name="permitRequestLimit"></param>
        /// belirlenen limit süresi içerisinde kaç istek kabul edileceği bilgisidir
        /// <param name="autoReplenishment"></param>
        /// süre dolduğunda işlemin başa sarması için önerilir
        /// <param name="queueProcessingOrder"></param>
        /// zaman aşımı durumunda kuyrukta biriken isteklerin hangi sırada işleme alınacağı bilgisidir
        /// <param name="queueLimit"></param>
        /// kuyrukta kaç istek tutulacağı bilgisidir
        /// <returns></returns>
        public static IServiceCollection RateLimitByPolicyName(this IServiceCollection serviceCollection,
                                                        string policyName,
                                                        TimeSpan limitTimeRange,
                                                        int permitRequestLimit,
                                                        bool autoReplenishment = true,
                                                        QueueProcessingOrder queueProcessingOrder = QueueProcessingOrder.OldestFirst,
                                                        int queueLimit = 0)
        {
            serviceCollection.AddRateLimiter(setting => setting.AddFixedWindowLimiter(policyName, options =>
            {
                options.AutoReplenishment = autoReplenishment;
                options.PermitLimit = permitRequestLimit;
                options.Window = limitTimeRange;
                options.QueueProcessingOrder = queueProcessingOrder;
                options.QueueLimit = queueLimit;
            }));
            return ServiceTool.Create(serviceCollection);
        }
    }
}
