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
            return _symbol.GetSymbolByIsinService(isin);

        }
    }
}

