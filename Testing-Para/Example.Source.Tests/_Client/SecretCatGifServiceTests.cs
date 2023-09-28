using Castle.Core.Logging;
using Example.Source._Client;
using Moq;

namespace Example.Source.Tests._Client
{
    // Variation 1.2
    public class SecretCatGifServiceTests
    {
        private readonly SecretCatGifService _service;
        private readonly Mock<ICatGifApiClient> _client;
        private readonly Mock<ILogger> _logger;
        private readonly CatServiceConfiguration _config;

        // client - setup: current rate limit, the GET
        // config - setup max rate limit
        // logger - verify log

        public string GetRandomCatGif()
        {
            // Check whether daily calls limit is exceeded or not (api, config)
            // Get random gif (api)
            // Log that a call was made (logger)
            return "";
        }
    }
}
