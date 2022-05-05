using Polly;
using Polly.Retry;

namespace TTWS_Api_DotNet6_Final.Repository
{
    public class SymbolRepository : ISymbolRepository
    {
        private readonly HttpClient _client;
        private readonly AsyncRetryPolicy _policy;

        public SymbolRepository(HttpClient client)
        {
            _policy = Policy.Handle<Exception>().WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2)
            }, (exception, timespan) =>
            {
                Console.WriteLine(exception.Message, timespan);
            });
            _client=client;
        }
        public async Task<string> GetByIsin(string uri, int id, string isin)
        {
            HttpResponseMessage response = null;
            await _policy.ExecuteAsync(async () =>
            {
                _client.BaseAddress = new Uri(uri);
                response = await _client.GetAsync($"?action=getSymbolsByISIN&customerID={id}&isin={isin}");
                response.EnsureSuccessStatusCode();
            });
            return await response.Content.ReadAsStringAsync();  
        }
    }
}
