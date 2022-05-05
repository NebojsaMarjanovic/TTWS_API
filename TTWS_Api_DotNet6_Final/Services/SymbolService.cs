using Microsoft.Extensions.Options;
using TTWS_Api_DotNet6_Final.Repository;

namespace TTWS_Api_DotNet6_Final.Services
{
    public class SymbolService : ISymbolService
    {
        private readonly TTWSConfiguration _config;
        private readonly ISymbolRepository _repository;
        public SymbolService(IOptions<TTWSConfiguration> config,ISymbolRepository repository)
        {
            _config = config.Value;
            _repository = repository;
        }
        public Task<string> GetSymbolByIsinService(string isin)
        {
            return _repository.GetByIsin(_config.Server,_config.CustomerId, isin);
        }

    }
}
