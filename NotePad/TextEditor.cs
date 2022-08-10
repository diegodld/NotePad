using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    class TextEditor
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja Fazer?");
            Console.WriteLine("1 - Abrir aequivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: OpenFile(); break;
                case 2: EditFile(); break;
                default:
                    Console.WriteLine("opção inválida!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }


        static void OpenFile()
        {
        Ponto:
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo ex:(c:/file/texto.txt)");
            var path = Console.ReadLine();

            try
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine("---------------------");
                    Console.WriteLine(text);
                    file.Close();
                    Console.WriteLine("Pressione Qualquer tecla para continuar...");
                    Console.ReadKey();
                    Menu();
                };
            }
            catch (Exception e)
            {

                Console.WriteLine($"Erro = {e}");
                Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                goto Ponto;
            }
        }

        static void EditFile()
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

            SaveFile(text);
        }

        static void SaveFile(string text)
        {
        Ponto:
            Console.Clear();
            Console.WriteLine(" Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();
            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
                    file.Close();
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Menu();

                };

            }
            catch (Exception e)
            {

                Console.WriteLine("Ocorreu um erro..");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
                goto Ponto;
            }
        }
    }
}
