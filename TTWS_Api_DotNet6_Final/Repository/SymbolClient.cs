using Polly;
using Polly.Retry;

namespace TTWS_Api_DotNet6_Final.Repository
{
    public class SymbolClient
    {
        private readonly HttpClient _client;
        private readonly AsyncRetryPolicy _policy;

        public SymbolClient(HttpClient client) 
        {
            _client = client;

            _policy = Policy.Handle<Exception>().WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2)
            }, (exception, timespan) =>
            {
                Console.WriteLine(exception.Message, timespan);
            });
        }

        public async Task<string> GetByIsinClient(int id, string isin)
        {
            HttpResponseMessage response = null;
            await _policy.ExecuteAsync(async () =>
            {
                //_client.BaseAddress = new Uri(uri);
                response = await _client.GetAsync($"?action=getSymbolsByISIN&customerID={id}&isin={isin}");
                response.EnsureSuccessStatusCode();
            });
            return await response.Content.ReadAsStringAsync();
        }
    }
}
