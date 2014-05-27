namespace PPP
{
    using System;
    using System.Diagnostics;
    static class Utils
    {
        private static long ciclesPerSecond = 127659000;
        /// <summary>
        /// Simulates som CPU Intensive work ad displays a message on the screen
        /// </summary>
        /// <param name="work">What to say to the user</param>
        /// <param name="seconds">How many "fake" seconds it takes.</param>
        internal static void DoWork(string work, int seconds)
        {
            Console.WriteLine("Let's {0} for {1} seconds.", work, seconds);
            SpinningArround(seconds);
            Console.WriteLine("We are done with {0}.", work);
        }

        /// <summary>
        /// Sets the maximum nuber of processors to be used by this application.
        /// </summary>
        /// <param name="procs"></param>
        internal static void SetNumberOfProcessors(int procs)
        {
            int value = (int)Math.Pow(2, procs) - 1;
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(value);
        }

        /// <summary>
        /// Let's see how many cycles we get in on second
        /// </summary>
        internal static void Calibrate()
        {
            Stopwatch sw = Stopwatch.StartNew();
            SpinningArround(1);
            sw.Stop();

            ciclesPerSecond /= (int)sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Simulates CPU intensive work.
        /// </summary>
        /// <param name="seconds">The number of seconds</param>
        /// <returns></returns>
        private static int SpinningArround(int seconds)
        {
            int dummyVar = 0;

            for (long i = 0; i < ciclesPerSecond * seconds; i++)
            {
                dummyVar += (int)i % 5;
            }
            return dummyVar;
        }
    }
}
