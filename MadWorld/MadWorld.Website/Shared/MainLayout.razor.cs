using System;
namespace MadWorld.Website.Shared
{
	public partial class MainLayout
	{
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _smartlookManager.Init();
        }
    }
}

