namespace Example.Source._Client
{
    // Variation 1.2
    public class SecretCatMemeService
    {
        private ICatMemeApiClient _client;
        private ILogger _logger;
        private CatServiceConfiguration _config;

        public SecretCatMemeService(ICatMemeApiClient client, ILogger logger, CatServiceConfiguration config)
        {
            _client = client;
            _logger = logger;
            _config = config;
        }

        // client - setup: current rate limit, the GET
        // config - setup max rate limit
        // logger - verify log

        public string GetRandomCatMeme()
        {
            // Check whether daily calls limit is exceeded or not (api, config)
            // Get random gif (api)
            // Log that a call was made (logger)
            return "";
        }
    }
}
