using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace DockerDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDatabase _redisDb;

        public RedisController(IConfiguration configuration, IDatabase database)
        {
            _redisDb=database;
        }

        [HttpGet]
        //This function will return myvalue
        public async Task<string> ReadConfigFromStartUpAndStoreToRedis()
        {
            string key = "mykey";
            string value = "myvalueworkingredisinconfig";
            await _redisDb.StringSetAsync(key, value);

            // Retrieve the value from Redis
            string retrievedValue = await _redisDb.StringGetAsync(key);

            // Print the retrieved value
            Console.WriteLine($"Retrieved value from Redis: {retrievedValue}");

            // Close the Redis connection
            //redis.Close();

            return retrievedValue;
        }

        [HttpGet]
        public string StoreValueToRedis()
        {
            // redis connection string
            string redisConnectionString = "demoapp-redis-master:6379";

            // Connect to Redis
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);

            IDatabase db = redis.GetDatabase();

            // Set a key-value pair in Redis
            string key = "mykey";
            string value = "myvalue";
            db.StringSetAsync(key, value);

            // Retrieve the value from Redis
            string retrievedValue = db.StringGet(key);

            // Print the retrieved value
            Console.WriteLine($"Retrieved value from Redis: {retrievedValue}");

            // Close the Redis connection
            redis.Close();

            return retrievedValue;
        }

    }
}