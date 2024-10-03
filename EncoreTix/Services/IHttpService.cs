namespace EncoreTIX.Services
{
    public interface IHttpService
    {
        Task<String> GetAsync<T>(string endpoint);
    }
}
