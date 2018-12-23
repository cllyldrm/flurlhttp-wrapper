namespace FlurlHttpWrapper.Config
{
    public class FlurlWrapperClientSettings
    {
        public int PollyCircuitBreakExceptionCount { get; set; }

        public int PollyCircuitBreakDurationInSeconds { get; set; }
    }
}