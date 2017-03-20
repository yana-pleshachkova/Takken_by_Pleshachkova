using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    class Logger
    {
        private Dictionary<string, string> movingMessages = new Dictionary<string, string>();
        private int lastKey;

        public Logger()
        {
            lastKey = 0;
        }

        public int LastKey
        {
            get { return lastKey; }
            set { lastKey = value; }
        } 

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void SaveAction(string movingMesage)
        {
            movingMessages.Add("moveTo" + LastKey, movingMesage);
            LastKey++;
        }

        public Dictionary<string, String> GetActions()
        {
            return movingMessages;
        }
    }
}
