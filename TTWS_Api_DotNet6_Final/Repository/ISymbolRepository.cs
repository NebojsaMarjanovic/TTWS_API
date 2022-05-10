namespace TTWS_Api_DotNet6_Final.Repository
{
    public interface ISymbolRepository
    {
        Task<string> GetByIsin(string isin);
    }
}
