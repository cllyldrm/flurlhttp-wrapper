# FlurlHttp Wrapper

[![Build status](https://ci.appveyor.com/api/projects/status/2wc38vjgnkhuojc9?svg=true)](https://ci.appveyor.com/project/cllyldrm/flurlhttpwrapper)

Custom wrapper for flurl http with polly circuit breaker. You can use on .net core projects.

## Getting Started

### Installing

From the package manager console:

	PM> Install-Package FlurlHttpWrapper
  
### Using

First you have to add these configurations.

````c#
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.GetSection("RestClientSettings");
            services.Configure<RestClientSettings>(settings);

            services.AddFlurlHttpWrapper();
        }
 ````
 
RestClientSettings class is need for polly circuit breaker settings. You can implement in your appsettings like this.
 
    {
        "RestClientSettings": {
             "PollyCircuitBreakExceptionCount": 50,
             "PollyCircuitBreakDurationInSeconds": 10
        }
    }
    
Now, you can start to create your clients.
 
 ````c#
    public interface IElasticClient : IRestClient
    {
    }
    
    public class ElasticClient : RestClient, IElasticClient
    {
        public ElasticClient(IFlurlClientFactory clientFactory, IOptions<RestClientSettings> restClientSettings)
            : base(clientFactory, restClientSettings, "http://localhost:9200/")
        {
        }
    }
 ````
 
Add singleton instance this client.

 ````c#
    services.AddSingleton<IElasticClient, ElasticClient>();
 ````
  
That' s all ! Example of usage.
 
 ````c#
    private readonly IElasticClient _elasticClient;
    
    public ElasticService(IElasticClient elasticClient)
    {
         _elasticClient = elasticClient;
    }

    public async Task<SearchResult> GetArticles()
    {
         return await _elasticClient.GetAsync<SearchResult>("_search");
    }
 ````
