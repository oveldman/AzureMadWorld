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

        protected override string FormatValue(string jsonText)
        {
            var jsonDoc = JsonDocument.Parse(jsonText);
            return JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
        }

        protected override async Task<bool> TryValidateValue(string value)
        {
            try
            {
                JsonDocument.Parse(value);
                return true;
            }
            catch (JsonException jsonException)
            {
                await ShowError(jsonException, GetLineNumber(jsonException));
                return false;
            }
        }

        private int GetLineNumber(JsonException jsonException)
        {
            if (!jsonException.LineNumber.HasValue) return 0;
            return Int32.TryParse(jsonException.LineNumber.ToString(), out int linenumber) ? linenumber : 0;
        }
    }
}

