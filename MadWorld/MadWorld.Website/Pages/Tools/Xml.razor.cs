using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BlazorMonaco;

namespace MadWorld.Website.Pages.Tools
{
    public partial class Xml
    {
        private int TotalValidations = 0;

        protected override void OnInitialized()
        {
            Lanuage = "xml";
        }

        private async Task FormatXml()
        {
            try
            {
                string xmlText = await GetValueFromEditor();
                XDocument doc = XDocument.Parse(xmlText);
                string xmlFormated = doc.ToString();
                await SetValueInEditor(xmlFormated);
            }
            catch (Exception)
            {
                ShowError("Xml is not valid");
            }
        }

        private async Task ValidateXML()
        {
            Result = string.Empty;
            await SetLine(false, 0);
            TotalValidations++;

            try
            {
                string xmlText = await GetValueFromEditor();
                new XmlDocument().LoadXml(xmlText);
                Result = $"Xml is Valid ({TotalValidations})";
            }
            catch (XmlException xmlException)
            {
                await SetLine(true, xmlException.LineNumber);
                ShowError(xmlException);
            }
        }

        private void ShowError(XmlException ex)
        {
            Result = ex.Message;
        }
    }
}
