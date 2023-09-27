namespace Example.Source._Client
{
    // Variation 1.2
    public class SecretCatGifService
    {
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
