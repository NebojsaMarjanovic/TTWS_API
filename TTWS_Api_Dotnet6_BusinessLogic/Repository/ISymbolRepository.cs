using TTWS_Api_Dotnet6_BusinessLogic.Model;

namespace TTWS_Api_DotNet6_BusinessLogic.Services
{
    public interface ISymbolRepository
    {
        Task<IEnumerable<Symbol>> GetByIsin(string isin);
    }
}
