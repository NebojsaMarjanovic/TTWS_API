using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using TTWS_Api_Dotnet6_BusinessLogic.Model;
using TTWS_Api_DotNet6_BusinessLogic.Repository;

namespace TTWS_Api_DotNet6_BusinessLogic.Services
{
    public class SymbolRepository : ISymbolRepository
    {
        SymbolClient _client;
        private readonly TTWSConfiguration _config;

        public SymbolRepository(SymbolClient client, IOptions<TTWSConfiguration> config)
        {
            _client = client;
            _config = config.Value;
        }

        public Task<IEnumerable<Symbol>> GetByIsin(string isin)
        {
            return _client.GetByIsinClient(_config.CustomerId, isin);
        }
    }
}
