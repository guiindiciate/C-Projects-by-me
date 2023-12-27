using System;
using System.ComponentModel.Design;

namespace StopWatchDecrease
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
            Console.WriteLine("S = SEGUNDOS || M = MINUTOS || 0 = SAIR");
            Console.WriteLine("Escolha o tempo para o cronômetro: ");

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


        static void Start(int time)
        {
            // while (time > 0)
            // {
            //     Console.Clear();
            //     Console.WriteLine(time);
            //     Thread.Sleep(1000);
            //     time--;
            // }


            for (int i = time; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("StopWatchDecrease finalizado");
            Thread.Sleep(2500);
            Menu();
        }
    }
}