using System;
using System.Text.Json;
using BlazorMonaco;

namespace MadWorld.Website.Pages.Tools
{
    public partial class Json
    {
        private string Result = string.Empty;

        private MonacoEditor _editor { get; set; }
        private string[] decorationIds;

        private async Task EditorOnDidInit(MonacoEditorBase editor)
        {
            await SetLine(false, 0);
        }

        private async Task FormatJson()
        {
            try
            {
                string jsonText = await GetJsonFromEditor();
                var jDoc = JsonDocument.Parse(jsonText);
                string jsonFormated = JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true });
                await SetJsonInEditor(jsonFormated);
            }
            catch (Exception)
            {
                ShowError("Xml is not valid");
            }
        }

        private async Task<string> GetJsonFromEditor()
        {
            return await _editor.GetValue();
        }

        private async Task SetJsonInEditor(string json)
        {
            await _editor.SetValue(json);
        }

        private void ShowError(string errorMessage)
        {
            Result = errorMessage;
        }

        private void OnContextMenu(EditorMouseEvent eventArg)
        {
            Console.WriteLine("OnContextMenu : " + System.Text.Json.JsonSerializer.Serialize(eventArg));
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

        private StandaloneEditorConstructionOptions EditorConstructionOptions(MonacoEditor editor)
        {
            return new StandaloneEditorConstructionOptions
            {
                Language = "json",
                GlyphMargin = true,
                Theme = "vs-dark",
                Value = string.Empty
            };
        }
    }
}

