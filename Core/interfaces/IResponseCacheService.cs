using System;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string chacheKey,object response,TimeSpan timeToLive);
        Task<string> GetCachedResponseAsync(string cachKey);
    }
}