using System;
using System.Collections.Concurrent;

namespace Threads5
{
    public class Program
    {

        static object block = new object();
        static void WriteSecond()
        {
            for (int i = 0; i < 20; i++)
            {
                lock (block)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(new string(' ', 10)+ "Вторичный" );
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }
            }



            
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteSecond);
            thread.Start();
            for (int i = 0; i < 20; i++)
            {
                lock(block)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Первичный");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(100);
                }

            }

            Console.ReadKey();
        }
    }
}