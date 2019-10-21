using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class MyLogger : ILogger
    {
        public ISource Src { get; private set; }
        public LevelOfDetalization DetalizationLevel { get; private set; }

        public void Configuration(ISource src , LevelOfDetalization detalizationLevel)
        {
            Src = src;
            DetalizationLevel = detalizationLevel;
        }

        public void LogException(Exception ex)
        {
            Src.Write(DetalizationLevel.CallMessageBuilder(ex));
        }
    }
}
