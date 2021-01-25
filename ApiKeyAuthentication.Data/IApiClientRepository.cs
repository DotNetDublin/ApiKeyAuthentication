using ApiKeyAuthentication.Shared;

namespace ApiKeyAuthentication.Data
{
    public interface IApiClientRepository
    {
        ApiClient GetApiClient(string appId, string apiKey);
    }
}