using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EulersMonocle
{
    public static class Crack
    {
        private static Stopwatch timer;
        public static void Start()
        {
            if (timer == null)
                timer = new Stopwatch();

            Debug.WriteLine("Timer started at {0}", DateTime.Now.TimeOfDay);
            timer.Start();
        }

        public static void Stop()
        {
            timer.Stop();
            Debug.WriteLine("Timer stoped at {0}, elpased time {1}", DateTime.Now.TimeOfDay, timer.Elapsed);
        }
    }
}
