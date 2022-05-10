using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TTWS_Api_Dotnet6_BusinessLogic.Model;
using TTWS_Api_DotNet6_BusinessLogic.Services;
=======
using TTWS_Api_DotNet6_Final.Services;
>>>>>>> d7914c22f739219ca8eae2dd2f1bd2052cd3a039

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


<<<<<<< HEAD
        [HttpGet("{isin}")]
        public async Task<string> GetSymbolByIsin(string isin)
        {
            //vraca bez Symbol{ }
            var obj = await _symbol.GetSymbolByIsinService(isin);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);


            //vraca sa Symbol{}
            //var json = new
            //{
            //    Symbol = await _symbol.GetSymbolByIsinService(isin)
            //};
            //return JsonConvert.SerializeObject(json, Formatting.Indented);

=======
        [HttpGet("{isin}")]        
        public Task<string> GetSymbolByIsin(string isin)
        {
            return _symbol.GetSymbolByIsinService(isin);
>>>>>>> d7914c22f739219ca8eae2dd2f1bd2052cd3a039

        }
    }
}

