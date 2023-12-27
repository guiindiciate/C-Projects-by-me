using System;

namespace StopWatch
{

    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo -> 10s");
            Console.WriteLine("M = Minuto -> 1m");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();
            char type = char.Parse(data.Substring(data.Length - 1, 1));
            int time = int.Parse(data.Substring(0, data.Length - 1));
            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;

            if (time == 0)
                Environment.Exit(0);

            PreStart(time * multiplier);

        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        // AO INVES DO VALOR SUBIR, FAZER ELE DESCER
        // AO INVES DE WHILE, USE FOR
        static void Start(int time)
        {
            // int currentTime = 0;

            // while (currentTime != time)
            // {
            //     Console.Clear();
            //     currentTime++;
            //     Console.WriteLine(currentTime);
            //     Thread.Sleep(1000);
            // }


            for (int i = time; i <= i; i--)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }


            Console.Clear();
            Console.WriteLine("StopWatch finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}