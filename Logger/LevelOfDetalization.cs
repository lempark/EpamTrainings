using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LevelOfDetalization
    {
        public delegate string MessageBuilder(Exception ex);
        private MessageBuilder buildMessage;

        public readonly static LevelOfDetalization info;
        public readonly static LevelOfDetalization trace;

        static LevelOfDetalization()
        {
            info = new LevelOfDetalization() { buildMessage = Info };
            trace = new LevelOfDetalization() { buildMessage = Trace };
        }

        public static string Info(Exception ex)
        {
            return ex.Message;
        }

        public static string Trace(Exception ex)
        {
            return $"{ex.Message} \n {ex.StackTrace}";
        }

        public string CallMessageBuilder(Exception ex)
        {
            return buildMessage?.Invoke(ex);
        }
    }
}
