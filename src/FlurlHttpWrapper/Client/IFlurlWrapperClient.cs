namespace FlurlHttpWrapper.Client
{
    using System.Threading.Tasks;

    public interface IFlurlWrapperClient
    {
        Task<TModel> GetAsync<TModel>(string path)
            where TModel : new();

        Task<TModel> PostAsync<TModel>(string path, string query)
            where TModel : new();

        Task<TModel> DeleteAsync<TModel>(string path)
            where TModel : new();

        Task<TModel> PatchAsync<TModel>(string path, string query)
            where TModel : new();

        Task<TModel> PutAsync<TModel>(string path, string query)
            where TModel : new();
    }
}
