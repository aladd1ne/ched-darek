using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.interfaces;
using StackExchange.Redis;

namespace Infrastructure.services
{
    public class ResponseCachServices : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCachServices(IConnectionMultiplexer redis)
        {

            _database = redis.GetDatabase();
        }

        public async Task CacheResponseAsync(string chacheKey, object response, TimeSpan timeToLive)
        {
            if (response == null)
            {
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var serializedResponse = JsonSerializer.Serialize(response,options);
            await _database.StringSetAsync(chacheKey,serializedResponse,timeToLive);
        }

        public async Task<string> GetCachedResponseAsync(string cachKey)
        {
            var cachedResponse  = await _database.StringGetAsync(cachKey);

            if(cachedResponse.IsNullOrEmpty)
            {
                return null;
            }

            return cachedResponse;
        }
    }
}