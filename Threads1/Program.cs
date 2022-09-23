using System;
using System.Globalization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {

        static void WriteSecond()
        {
            int counter = 0;

            while (counter < 10)
            {
                Console.WriteLine($"Thread Id {Thread.CurrentThread.GetHashCode()}, coounter = {counter}");
                counter++;
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(WriteSecond));
            thread.Start();

            WriteSecond();
            Console.ReadKey();
        }
    }
}