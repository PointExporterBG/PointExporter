using PE.Cache.Properties;
using System;
using System.Runtime.Caching;

namespace PE.Cache.Default
{
    public class CacheManager : ICacheManager
    {
        private ObjectCache cache = MemoryCache.Default;

        public void Set(string key, object value)
        {
            cache.Set(key, value, DateTime.Now.AddHours(Settings.Default.CacheExpirationHours));
        }

        public object Get(string key)
        {
            return cache.Get(key);
        }
    }
}
