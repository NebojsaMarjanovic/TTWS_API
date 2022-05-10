using TTWS_Api_Dotnet6_BusinessLogic.Model;

namespace TTWS_Api_DotNet6_BusinessLogic.Services
{
    public interface ISymbolService
    {
        Task<IEnumerable<Symbol>> GetSymbolByIsinService(string isin);
    }
}
