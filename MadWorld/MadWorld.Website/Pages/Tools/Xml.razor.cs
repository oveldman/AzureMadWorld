using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BlazorMonaco;

namespace MadWorld.Website.Pages.Tools
{
    public partial class Xml
    {
        protected override void OnInitialized()
        {
            Lanuage = "xml";
        }

        protected override string FormatValue(string xmlText)
        {
            XDocument doc = XDocument.Parse(xmlText);
            return doc.ToString();
        }

        protected override async Task<bool> TryValidateValue(string value)
        {
            try
            {
                new XmlDocument().LoadXml(value);
                return true;
            }
            catch (XmlException xmlException)
            {
                await ShowError(xmlException, xmlException.LineNumber);
                return false;
            }
        }
    }
}
