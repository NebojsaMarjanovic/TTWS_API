using Polly;
using Polly.Retry;
using TTWS_Api_Dotnet6_BusinessLogic.Model;
using TTWS_Api_Dotnet6_BusinessLogic.Services;

namespace TTWS_Api_DotNet6_BusinessLogic.Repository
{
    public class SymbolClient
    {
        private readonly HttpClient _client;
        private readonly AsyncRetryPolicy _policy;
        private readonly IXMLReader _reader;

        public SymbolClient(HttpClient client, IXMLReader reader) 
        {
            _client = client;
            _reader = reader;

            _policy = Policy.Handle<Exception>().WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2)
            }, (exception, timespan) =>
            {
                Console.WriteLine(exception.Message, timespan);
            });
        }

        public async Task<IEnumerable<Symbol>> GetByIsinClient(int id, string isin)
        {
            HttpResponseMessage response = null;
            await _policy.ExecuteAsync(async () =>
            {
                //_client.BaseAddress = new Uri(uri);
                response = await _client.GetAsync($"?action=getSymbolsByISIN&customerID={id}&isin={isin}");
                response.EnsureSuccessStatusCode();
            });
            var temp= response.Content.ReadAsStringAsync().Result;

            var parsedTemp=_reader.ParseXmlResponse(temp);
            return parsedTemp;

        }
    }
}
