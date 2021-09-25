using System;
namespace MadWorld.Website.Pages.Tools
{
    public partial class GuidGenerator
    {
        public int MaxGeneate { get; set; } = 4000;
        public int TotalGenerate { get; set; } = 1;
        public string GuidBody { get; set; }

        private void GenerateGuid()
        {
            GuidBody = string.Empty;

            TotalGenerate = TotalGenerate < MaxGeneate ? TotalGenerate : MaxGeneate;

            for (int i = 0; i < TotalGenerate; i++)
            {
                GuidBody += Guid.NewGuid().ToString() + Environment.NewLine;
            }
        }
    }
}
