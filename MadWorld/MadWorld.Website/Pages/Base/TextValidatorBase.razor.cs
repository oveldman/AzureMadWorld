using System;
using BlazorMonaco;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Base
{
	public partial class TextValidatorBase : ComponentBase
	{
        protected string Lanuage = "None";
    	protected string Result = string.Empty;

		protected MonacoEditor _editor { get; set; }
		protected string[] decorationIds;

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

