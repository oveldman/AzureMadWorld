using System;
namespace MadWorld.Website.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }

        private void ResetRole()
        {
            _authenticationHandler.ResetRoles();
        }
    }
}

