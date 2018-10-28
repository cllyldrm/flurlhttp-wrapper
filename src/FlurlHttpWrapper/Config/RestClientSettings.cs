namespace FlurlHttpWrapper.Config
{
    public class RestClientSettings
    {
        public int PollyCircuitBreakExceptionCount { get; set; }

        public int PollyCircuitBreakDurationInSeconds { get; set; }
    }
}