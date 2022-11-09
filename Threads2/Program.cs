using System;
using System.Threading;

namespace Threads2
{
    public class Program
    {
        static void WriteSecond()
        {
            //CurrentThread содержит ссылку на поток в контексте которого будет запущен метод WriteSecond
            Thread thread = Thread.CurrentThread;
            thread.Name = "Вторичный";
            Console.WriteLine($"Id потока {thread.Name}: {thread.GetHashCode()}");

            for (int counter = 0; counter< 10; counter++)
            {
                Console.WriteLine(new string(' ', 10) + thread.Name + " " + counter);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Thread primaryThread = Thread.CurrentThread;
           primaryThread.Name  = "Первичный";
            Console.WriteLine($"Id потока {primaryThread.Name}: {primaryThread.GetHashCode()}");

            Thread secondaryThread = new Thread(WriteSecond);
            secondaryThread.Start();

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine(primaryThread.Name+ " " + counter);
                Thread.Sleep(1500);
            }

            Console.ReadKey();
        }
    }
}