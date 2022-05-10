using Microsoft.Extensions.Options;
using TTWS_Api_Dotnet6_BusinessLogic.Model;

namespace TTWS_Api_DotNet6_BusinessLogic.Services
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
        public Task<IEnumerable<Symbol>> GetSymbolByIsinService(string isin)
        {
            return _repository.GetByIsin(isin);
            
        }

    }
}
