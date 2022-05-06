using Polly;
using Polly.Retry;

namespace TTWS_Api_DotNet6_Final.Repository
{
    public class SymbolRepository : ISymbolRepository
    {
        SymbolClient _client;
        public SymbolRepository(SymbolClient client)
        {
            _client = client;
        }

        public Task<string> GetByIsin(int id, string isin)
        {
            return _client.GetByIsinClient(id, isin);
        }
    }
}
