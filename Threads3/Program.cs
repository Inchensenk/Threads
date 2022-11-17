using System;

namespace CriticalSection
{
    class MyClass
    {
        //объект блокировки(это может быть любой объект)
        object block = new object();
        public void Method()
        {
            int hash = Thread.CurrentThread.GetHashCode();

            //Критическая секция
            lock(block) 
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine($"Поток (бегун) # {hash}: итерация (круг) {counter}");
                    Thread.Sleep(100);
                }
                Console.WriteLine(new string('-', 37));
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80,40);

            MyClass instance = new MyClass();

            //Создание потоков по слабой ссылке
            for (int i = 0; i < 3; i++)
            {
                new Thread(instance.Method).Start();
            }
            Thread.Sleep(1000);

            Console.ReadKey();
        }
    }
}