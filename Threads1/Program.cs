using System;
using System.Globalization;

namespace Threads1
{
    class Program
    {

        static void WriteSecond()
        {
            //счетчик
            int counter = 0;

            while (counter < 10)
            {
                //Вывод Id потока и счетчик цикла
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

/*При запуске программы для каждого потока был свой counter, 
 * то есть для каждого потока счетчик был от 0 до 9 в зависимости от итерации цикла while
 
Это говорит о том что в каждом потоке как будто бы выполнялась своя копия метода WriteSecond()
Но на самом деле выполнялась сложная операция пересчета адресов, за которые отвечает система,
Так же происходят некоторые операции копирования и  в итоге получаются как бы две разные копии одно и того же метода,
которые работают независимо в разных потоках поэтому у каждого потока свой собственный counter*/

