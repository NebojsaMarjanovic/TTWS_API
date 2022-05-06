using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTWS_Api_DotNet6_Final.Services;

namespace TTWS_Api_DotNet6_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymbolController : ControllerBase
    {
        private readonly ISymbolService _symbol;
        public SymbolController(ISymbolService symbol)
        {
            _symbol= symbol;
        }

        [HttpGet("{isin}")]
        public Task<string> GetSymbolByIsin(string isin)
        {
            if(!string.IsNullOrEmpty(isin) && char.IsLetter(isin[0]) && char.IsLetter(isin[1]) && char.IsNumber(isin[2]))
            return _symbol.GetSymbolByIsinService(isin);
            else return Task.FromResult("Bad input parameter") ;
        }
    }
}
