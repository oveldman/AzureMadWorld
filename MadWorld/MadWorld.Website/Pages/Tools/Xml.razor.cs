using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BlazorMonaco;

namespace MadWorld.Website.Pages.Tools
{
    public partial class Xml
    {
        private string Result = string.Empty;
        private int TotalValidations = 0;

        private MonacoEditor _editor { get; set; }
        private string[] decorationIds;

        private async Task FormatXml()
        {
            try
            {
                string xmlText = await GetXmlFromEditor();
                XDocument doc = XDocument.Parse(xmlText);
                string xmlFormated = doc.ToString();
                await SettXmlFromEditor(xmlFormated);
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
                string xmlText = await GetXmlFromEditor();
                new XmlDocument().LoadXml(xmlText);
                Result = $"Xml is Valid ({TotalValidations})";
            }
            catch (XmlException xmlException)
            {
                await SetLine(true, xmlException.LineNumber);
                ShowError(xmlException);
            }
        }

        private async Task<string> GetXmlFromEditor()
        {
            return await _editor.GetValue();
        }

        private async Task SettXmlFromEditor(string xml)
        {
            await _editor.SetValue(xml);
        }

        private void ShowError(string errorMessage)
        {
            Result = errorMessage;
        }

        private void ShowError(XmlException ex)
        {
            Result = ex.Message;
        }

        private async Task SetLine(bool showLine, int linenumber)
        {
            ModelDeltaDecoration[] newDecorations = new ModelDeltaDecoration[0];

            if (showLine)
            {
                newDecorations = new ModelDeltaDecoration[]
                {
                new ModelDeltaDecoration
                {
                    Range = new BlazorMonaco.Range(linenumber,1,linenumber,1),
                    Options = new ModelDecorationOptions
                    {
                        IsWholeLine = true,
                        ClassName = "decorationContentClass",
                        GlyphMarginClassName = "decorationGlyphMarginClass"
                    }
                }
                    };

                await _editor.RevealLineInCenter(linenumber, ScrollType.Smooth);
            }

            decorationIds = await _editor.DeltaDecorations(decorationIds, newDecorations);
            // You can now use 'decorationIds' to change or remove the decorations
        }

        private async Task EditorOnDidInit(MonacoEditorBase editor)
        {
            await SetLine(false, 0);
        }

        private StandaloneEditorConstructionOptions EditorConstructionOptions(MonacoEditor editor)
        {
            return new StandaloneEditorConstructionOptions
            {
                Language = "xml",
                GlyphMargin = true,
                Theme = "vs-dark",
                Value = string.Empty
            };
        }

        private void OnContextMenu(EditorMouseEvent eventArg)
        {
            Console.WriteLine("OnContextMenu : " + System.Text.Json.JsonSerializer.Serialize(eventArg));
        }
    }
}
