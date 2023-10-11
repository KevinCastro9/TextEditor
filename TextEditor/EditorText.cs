using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class EditorText
    {
        public void Menu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("O que você deseja realizar ?");
                Console.WriteLine("1 - Abrir arquivo");
                Console.WriteLine("2 - Criar novo arquivo");
                Console.WriteLine("0 - Sair");

                short option = short.Parse(Console.ReadLine());

                switch(option)
                {
                    case 0: 
                        Environment.Exit(0); break;
                    case 1:
                        OpenFile(); break;
                    case 2:
                        NewFile(); break;
                    default: 
                        Menu(); break;
                }
            }
            catch(Exception ex)
            {
            
            }
        }

        public void OpenFile()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Em qual caminho está o arquivo ?");
                var path = Console.ReadLine();

                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }

                Console.WriteLine("");
                Console.ReadLine();
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu o erro: " + ex.Message + " ao tentar abrir o arquivo. Por gentileza tente novamente!");
            }
        }

        public void NewFile()
        {
            string text = "";

            try
            {
                Console.Clear();
                Console.WriteLine("Digite seu texto abaixo (clique ESC após inserir todas as linhas com enter para sair).");
                Console.WriteLine("-----------------------------------------------");

                do
                {
                    text += Console.ReadLine();
                    text += Environment.NewLine;
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);

                Salve(text);
            }
            catch (Exception ex)
            {

            }
        }

        public void Salve(string text)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Em qual caminho deseja salvar o arquivo ?");
                var path = Console.ReadLine();

                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.WriteLine($"O arquivo foi salvo com sucesso! No caminho: {path}");
                Console.WriteLine("Clique em qualquer tecla para voltar ao Menu!");
                Console.ReadKey();
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu o erro: " + ex.Message + " ao tentar salvar o arquivo. Por gentileza tente novamente!");
            }
        }
    }
}
