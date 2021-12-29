using System;
namespace MadWorld.Website.Shared
{
	public partial class AdminLayout
	{
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _smartlookManager.Init();
        }
    }
}

