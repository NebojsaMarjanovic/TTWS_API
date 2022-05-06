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


        [HttpGet("{isin:regex(([[A-Z]]{{2}})([[A-Z0-9]]{{9}})([[0-9]]{{1}}))}")]        
        public Task<string> GetSymbolByIsin(string isin)
        {
            return _symbol.GetSymbolByIsinService(isin);

        }
    }
}

