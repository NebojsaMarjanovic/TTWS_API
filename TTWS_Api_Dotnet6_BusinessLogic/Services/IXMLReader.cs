using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TTWS_Api_Dotnet6_BusinessLogic.Model;

namespace TTWS_Api_Dotnet6_BusinessLogic.Services
{
    public interface IXMLReader/*<T> where T: class*/
    {

        IEnumerable<Symbol> ParseXmlResponse(string xml);
    }
}
