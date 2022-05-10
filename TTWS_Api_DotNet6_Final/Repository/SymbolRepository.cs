using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;

namespace TTWS_Api_DotNet6_Final.Repository
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

        public Task<string> GetByIsin(string isin)
        {
            return _client.GetByIsinClient(_config.CustomerId, isin);
        }
    }
}
