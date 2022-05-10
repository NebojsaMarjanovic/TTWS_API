using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TTWS_Api_Dotnet6_BusinessLogic.Model
{
    [XmlRoot(ElementName = "Symbol", Namespace = "urn:schemas-teletrader-com:mb", DataType = "string", IsNullable = true)]
    public class Symbol
    {
        [XmlAttribute("id")]
        public string Id { get; set; }


        [XmlAttribute("name")]
        public string Name { get; set; }


        [XmlAttribute("tickerSymbol")]
        public string TickerSymbol { get; set; }


        [XmlAttribute("isin")]
        public string Isin { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Ticker: {TickerSymbol} n Isin: {Isin}";
        }
    }
}
