using System;
using System.ComponentModel.DataAnnotations;

namespace TextEditor
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
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("3 - Editar arquivo existente");
            Console.WriteLine("4 - Excluir arquivo existente");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Create(); break;
                case 3: Edit(); break;
                case 4: Delete(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }
        
        static void Create()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
            Console.WriteLine("------------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }
        
        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo que você deseja editar?");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }

                Console.WriteLine("Digite seu novo texto abaixo: (ESC para sair)");
                Console.WriteLine("--------------------------------------------");

                string newText = "";

                do
                {
                    newText += Console.ReadLine();
                    newText += Environment.NewLine;
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                SaveExisting(newText, path);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado. Pressione Enter para voltar ao menu!");
                Console.ReadLine();
                Menu();
            }
        }
        
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho você deseja para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");
            Console.ReadLine();
            Menu();
        }
        
        static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo você deseja excluir?");
            string path = Console.ReadLine();

            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"Arquivo {path} excluído com sucesso. Pressione Enter para voltar ao menu.");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado. Pressione Enter para voltar ao menu.");
                Console.ReadLine();
                Menu();
            }
        }
        
        static void SaveExisting(string text, string path)
        {
            Save(text);
        }

    }
}