namespace PPP
{
    using System;
    using System.Diagnostics;

    class Program
    {

        static void Main(string[] args)
        {
            Utils.Calibrate();
            //Utils.SetNumberOfProcessors(1);
            Stopwatch sw = Stopwatch.StartNew();
            GoulashRecipe.MakeGoulash();
            Console.WriteLine("We're done in {0} minutes.", sw.ElapsedMilliseconds/60);

            Console.ReadLine();
        }

 

    }
}

