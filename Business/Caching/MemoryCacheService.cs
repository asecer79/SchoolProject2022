using Microsoft.Extensions.Caching.Memory;

namespace Business.Caching
{
    public class MemoryCacheService:ICacheService
    {
        readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<T>(string key, T data)
        {
           // var jsonString = JsonConvert.SerializeObject(data);
            _memoryCache.Set<T>(key, data);
        }

        public T Get<T>(string key)
        {
            var data = _memoryCache.Get<T>(key);

            //var jsonString = JsonConvert.SerializeObject(data);
           return data;
        }

        public bool Exists(string key)
        {
            return _memoryCache.Get(key) != null ? true : false;
        }

        public void Remove(string key)
        {
           _memoryCache.Remove(key);
        }
    }
}
