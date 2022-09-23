using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void WriteSecond()
        {
            while(true)
            {
                Console.WriteLine(new String(' ', 10) + "Вторичный");
            }
        }
        static void Main(string[] args)
        {
            /*ThreadStart это делегат, который представляет метод, который выполняется в отношении Thread.
            Этому делегату передается метод(в данном случае WriteSecond()) который мы хотим запустить в новом потоке*/
            ThreadStart writeSecond = new ThreadStart(WriteSecond);

            /*thread обьектно ориентированное представление потока в который передаем делегат writeSecond
            С помощью этого класса можно запускать и управлять потоками*/
            Thread thread = new Thread(writeSecond);

            //для запуска потока вызываем у экземпляра thread метод Start()
            thread.Start();
            while (true)
            {
                Console.WriteLine("Первичный");
            }
        }
    }
}

/*Для каждого потока выделяется 1мб стека, не больше, ни меньше*/