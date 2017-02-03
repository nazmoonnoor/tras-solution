using System;

namespace Tras.Core.Domain.Common
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        T Get<T>(string key, int cacheTime, Func<T> acquire);

        void Set(string key, object data, int cacheTime);

        bool IsSet(string key);

        void Remove(string key);

        void Clear();
    }
}