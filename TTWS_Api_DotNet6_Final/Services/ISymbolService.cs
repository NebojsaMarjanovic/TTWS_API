namespace TTWS_Api_DotNet6_Final.Services
{
    public interface ISymbolService
    {
        Task<string> GetSymbolByIsinService(string isin);
    }
}
