using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TTWS_Api_Dotnet6_BusinessLogic.Model;
using TTWS_Api_DotNet6_BusinessLogic.Repository;

namespace TTWS_Api_Dotnet6_BusinessLogic.Services
{
    public class XMLReader : IXMLReader/*<Symbol>*/
    {
        Symbol _symbol;
        public XMLReader(Symbol symbol)
        {
            _symbol = symbol;
        }

        public IEnumerable<Symbol> ParseXmlResponse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            XNamespace ns = doc.Root.Name.Namespace;
            IEnumerable<XElement> xelements = doc.Descendants(ns + "Symbol");
            MemoryStream stream = null;
            List<Symbol> symbols = new List<Symbol>();

            
            var serializer = new XmlSerializer(typeof(Symbol), "");
            foreach (XElement xelement in xelements)
            {
                stream = new MemoryStream(Encoding.UTF8.GetBytes(xelement.ToString()));


                _symbol = (Symbol)serializer.Deserialize(stream);
                symbols.Add(_symbol);

                Console.WriteLine(_symbol.Name);
            }

            return symbols;
        }

       


    }
}