using ApiKeyAuthentication.Shared;
using ApiKeyMiddleware.Data.Helpers;
using System.Data;

namespace ApiKeyAuthentication.Data
{
    public class ApiClientRepository : IApiClientRepository
    {
        private readonly DatabaseHelper _db;

        public ApiClientRepository(string connectionString)
        {
            _db = new DatabaseHelper(connectionString);
        }

        public ApiClient GetApiClient(string appId, string apiKey)
        {
            return _db.GetFirstOrDefault<ApiClient>("GetApiClient", new { AppId = appId, ApiKey = apiKey }, CommandType.StoredProcedure);
        }
    }
}
