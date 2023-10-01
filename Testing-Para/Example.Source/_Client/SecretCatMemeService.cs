namespace Example.Source._Client
{
    // Variation 1.2
    public class SecretCatMemeService
    {
        private ICatMemeApiClient _client;
        private ILogger _logger;
        private CatServiceConfiguration _config;
        private IMemeCache _cache;

        public SecretCatMemeService(ICatMemeApiClient client, ILogger logger, CatServiceConfiguration config, IMemeCache cache)
        {
            _client = client;
            _logger = logger;
            _config = config;
            _cache = cache;
        }

        public string GetRandomCatMeme()
        { 
            var currentRate = _client.GetCurrentRate();
            string catMeme;
            if(currentRate < _config.RateLimit)
            { 
                catMeme = _cache.GetRandom();
                _logger.LogInfo("Meme retrieved from the cache");
            }
            else
            {
                catMeme = _client.GetRandomCatMeme();
                _cache.Add(catMeme);
                _logger.LogInfo("Meme retrieved from a client");
            }

            return catMeme;
        }
    }
}
