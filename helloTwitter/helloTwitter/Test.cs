using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace helloTwitter
{
    class Test
    {
        static void Main(String[] args)
        {
            //Class1 c1 = new Class1();
            //HistoryTwitter ht = new HistoryTwitter();
            //ht.History();
            //c1.StreamTwitter();
            Thread history,stream;
            
            history = new Thread(new ThreadStart(historyLoop));
            stream = new Thread(new ThreadStart(streamLoop));
            // Lancement du thread
            history.Start();
            stream.Start();
        }
        public static void historyLoop()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                HistoryTwitter.History();
            }
        }
        public static void streamLoop()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                Class1.StreamTwitter();
            }
        }
    }
}
