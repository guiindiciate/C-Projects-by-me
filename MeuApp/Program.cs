using System;
using System.Runtime.InteropServices;

namespace MeuApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Product mouse = new Product(54, "Razer", 499.92, EProductType.Product, "Esse mouse tem diversas funções, incluindo 12 botões ao seu lado com comandos.");

            var manutencaoEletrica = new Product(2, "Manutenção elétrica residencial", 500, EProductType.Service, "Description");
            mouse.Id = 55;

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
            Console.WriteLine(mouse.Price);
            Console.WriteLine((int)mouse.Type);
            Console.WriteLine(mouse.Description);

        }
    }


    struct Product
    {

        public Product(int id, string name, double price, EProductType type, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
            Description = description;
        }

        public int Id;
        public string Name;
        public double Price;
        public EProductType Type;
        public string Description;

        public double PriceInDolar(double dolar)
        {
            return Price * dolar;
        }
    }

    enum EProductType
    {
        Product = 1,
        Service = 2
    }

}