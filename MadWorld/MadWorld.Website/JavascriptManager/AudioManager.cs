using System;
using MadWorld.Website.JavascriptManager.Interfaces;
using Microsoft.JSInterop;

namespace MadWorld.Website.JavascriptManager
{
	public class AudioManager : IAudioManager
	{
        private string JavascriptClassname = "AudioPlayer";
        private readonly IJSRuntime _JSRuntime;

        public AudioManager(IJSRuntime jsRuntime)
		{
            _JSRuntime = jsRuntime;
		}

        public void Init(string name)
        {
            _JSRuntime.InvokeVoidAsync($"{JavascriptClassname}.Create", name);
        }

        public void Play()
        {
            _JSRuntime.InvokeVoidAsync($"{JavascriptClassname}.Play");
        }
    }
}

