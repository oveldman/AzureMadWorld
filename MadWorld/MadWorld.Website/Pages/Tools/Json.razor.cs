using System;
using System.Text.Json;
using BlazorMonaco;

namespace MadWorld.Website.Pages.Tools
{
    public partial class Json
    {
        protected override void OnInitialized()
        {
            Lanuage = "json";
        }

        private async Task FormatJson()
        {
            try
            {
                string jsonText = await GetValueFromEditor();
                var jDoc = JsonDocument.Parse(jsonText);
                string jsonFormated = JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true });
                await SetValueInEditor(jsonFormated);
            }
            catch (Exception)
            {
                ShowError("Json is not valid");
            }
        }
    }
}

