using System;
using MadWorld.Website.Manager.Interfaces;
using Microsoft.JSInterop;

namespace MadWorld.Website.Manager
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
            _JSRuntime.InvokeVoidAsync($"{JavascriptClassname}.Init", name);
        }

        public void Play()
        {
            _JSRuntime.InvokeVoidAsync($"{JavascriptClassname}.Play");
        }
    }
}

