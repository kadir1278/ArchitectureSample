using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public class MemoryCacheHelper
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheHelper(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public object GetCacheData(string cacheKey)
        {
            var cacheData = memoryCache.Get(cacheKey);

            if (cacheData is not null)
                return cacheData;

            return null;
        }

        public bool CheckCacheData(string cacheKey) => memoryCache.TryGetValue(cacheKey, out object ObecjtData);

        public bool CreateCacheData(string cacheKey, object value, DateTimeOffset dateTimeOffset)
        {
            try
            {
                if (!memoryCache.TryGetValue(cacheKey, out value))
                    memoryCache.Set(cacheKey, value, dateTimeOffset);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
