namespace Business.Caching
{
    public interface ICacheService
    {
        void Set<T>(string key, T data);
        T Get<T>(string key);
        bool Exists(string key);
        void Remove(string key);
    }
}
