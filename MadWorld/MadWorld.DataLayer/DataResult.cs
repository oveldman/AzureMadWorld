using System;
namespace MadWorld.DataLayer
{
    public class DataResult
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public bool Succeed {
            get
            {
                return !Error;
            }
        }
    }
}
