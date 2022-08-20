namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Add(string key, object value, int duration);

        bool IsAddable(string key);

        void Remove(string key);

        void RemoveByPattern(string pattern);
    }
}