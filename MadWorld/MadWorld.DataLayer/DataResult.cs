using System;
namespace MadWorld.DataLayer
{
    public class DataResult
    {
        public Guid? RowID { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool Succeed {
            get
            {
                return !Error;
            }
        }
    }
}
