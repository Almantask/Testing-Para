using Example.Source._Client;
using FluentAssertions;
using Moq;

namespace Example.Source.Tests._Client
{
    // Variation 1.2
    public class SecretCatMemeServiceTests
    {
        // Separate 
        private readonly SecretCatMemeService _service;

        private readonly Mock<ICatMemeApiClient> _client;
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IMemeCache> _cache;
        private readonly CatServiceConfiguration _config;

        public SecretCatMemeServiceTests()
        {
            _client = new Mock<ICatMemeApiClient>();
            _logger = new Mock<ILogger>();
            _config = new CatServiceConfiguration();
            _cache = new Mock<IMemeCache>();

            _service = new SecretCatMemeService(_client.Object, _logger.Object, _config, _cache.Object);
        }

        [Fact]
        public void GetRandomCatMeme_GivenUnderRateLimit_ReturnsMemeFromClient()
        {
            // Don't rely on implicit values when those values are essential for the test.
            _config.RateLimit = int.MaxValue;

            var memeFromClient = "meme-from-client";
            _client
                .Setup(client => client.GetRandomCatMeme())
                .Returns(memeFromClient);

            var meme = _service.GetRandomCatMeme();

            meme.Should().Be(memeFromClient);
        }

        [Fact]
        public void GetRandomCatMeme_GivenMemeRetrievedFromClient_LogsMemeWasRetrievedFromAClient()
        {
            _config.RateLimit = int.MaxValue;

            var meme = _service.GetRandomCatMeme();

            _logger.Verify(logger => logger.LogInfo("Meme retrieved from a client"), Times.Once());
        }

        [Fact]
        public void GetRandomCatMeme_GivenUnderRateLimit_AddsMemeToTheCache()
        {
            _config.RateLimit = int.MaxValue;

            var memeFromClient = "meme-from-client";
            _client
                .Setup(client => client.GetRandomCatMeme())
                .Returns(memeFromClient);


            _service.GetRandomCatMeme();

            _cache.Verify(cache => cache.Add(memeFromClient), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetRandomCatMeme_GivenAtOrAboveRateLimit_ReturnsMemeFromTheChache(int configuredRateLimit)
        {
            // Order should match how you read the name.
            _config.RateLimit = configuredRateLimit;

            var memeFromCache = "meme-from-client";
            _cache
                .Setup(cache => cache.GetRandom())
                .Returns(memeFromCache);

            _client
                .Setup(client => client.GetCurrentRate())
                .Returns(0);

            var meme = _service.GetRandomCatMeme();

            meme.Should().Be(memeFromCache);
        }

        [Fact]
        public void GetRandomCatMeme_GivenMemeRetrievedFromTheCache_LogsMemeRetrievedFromTheCache()
        {
            _config.RateLimit = -1;

            var meme = _service.GetRandomCatMeme();

            _logger.Verify(logger => logger.LogInfo("Meme retrieved from the cache"), Times.Once());
        }
    }
}
