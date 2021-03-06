using System;
using BlazorMonaco;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Base
{
	public partial class TextValidatorBase : ComponentBase
	{
        protected string Lanuage = "None";
        protected int TotalValidations = 0;
        protected string Result = string.Empty;

		protected MonacoEditor _editor { get; set; }
		protected string[] decorationIds;

        protected async Task FormatBody()
        {
            try
            {
                string editorValue = await GetValueFromEditor();
                string formatedValue = FormatValue(editorValue);
                await SetValueInEditor(formatedValue);
            }
            catch (Exception)
            {
                ShowError($"{Lanuage} is not valid");
            }
        }

        protected async Task ValidateBody()
        {
            Result = string.Empty;
            await SetLine(false, 0);
            TotalValidations++;
            string editorValue = await GetValueFromEditor();

            if (await TryValidateValue(editorValue))
            {
                Result = $"{Lanuage} is Valid ({TotalValidations})";
            }
        }

        protected virtual async Task<bool> TryValidateValue(string value)
        {
            return true;
        }

        protected virtual string FormatValue(string baseText)
        {
            return baseText;
        }

        protected void ShowError(Exception ex)
        {
            Result = ex.Message;
        }

        protected async Task ShowError(Exception ex, int lineNumber)
        {
            await SetLine(true, lineNumber);
            ShowError(ex);
        }

        protected void ShowError(string errorMessage)
		{
			Result = errorMessage;
		}

        protected async Task EditorOnDidInit(MonacoEditorBase editor)
        {
            await SetLine(false, 0);
        }

        protected async Task SetLine(bool showLine, int linenumber)
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

        protected void OnContextMenu(EditorMouseEvent eventArg)
        {
            Console.WriteLine("OnContextMenu : " + System.Text.Json.JsonSerializer.Serialize(eventArg));
        }

        protected async Task<string> GetValueFromEditor()
        {
            return await _editor.GetValue();
        }

        protected async Task SetValueInEditor(string json)
        {
            await _editor.SetValue(json);
        }

        protected StandaloneEditorConstructionOptions EditorConstructionOptions(MonacoEditor editor)
        {
            return new StandaloneEditorConstructionOptions
            {
                Language = Lanuage,
                GlyphMargin = true,
                Theme = "vs-dark",
                Value = string.Empty
            };
        }
    }
}

