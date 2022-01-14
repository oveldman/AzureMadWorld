using System;
using MadWorld.Website.JavascriptManager.Interfaces;
using Microsoft.JSInterop;

namespace MadWorld.Website.JavascriptManager
{
	public class SmartlookManager : ISmartlookManager
    {
        private readonly IJSRuntime _JSRuntime;

        public SmartlookManager(IJSRuntime jsRuntime)
        {
            _JSRuntime = jsRuntime;
        }

        public void Init()
        {
            _JSRuntime.InvokeVoidAsync("SmartLookAnalyser.Init");
        }
    }
}

