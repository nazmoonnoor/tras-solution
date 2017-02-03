using System;
using System.Runtime.Caching;

namespace Tras.Core.Domain.Common
{
    public class CacheManager : ICacheManager
    {
        private ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public T Get<T>(string key, int cacheTime, Func<T> acquire)
        {
            if (IsSet(key))
            {
                return Get<T>(key);
            }
            else
            {
                var result = acquire();
                Set(key, result, cacheTime);
                return result;
            }
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}