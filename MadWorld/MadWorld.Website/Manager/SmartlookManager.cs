using System;
using MadWorld.Website.Manager.Interfaces;
using Microsoft.JSInterop;

namespace MadWorld.Website.Manager
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

