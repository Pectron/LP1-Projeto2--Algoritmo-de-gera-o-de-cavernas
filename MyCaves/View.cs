using System;
using System.Collections.Generic;

namespace MyCaves
{
    public class View
    {
        private Controller controller;

        public View(Controller controller) 
        {
            this.controller = controller;
        }

        public int MainMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----");
            Console.WriteLine("1. Construir um novo Mundo");
            Console.WriteLine("0. Exit");
            Console.WriteLine("");
            Console.Write("> ");

            return int.Parse(Console.ReadLine());
        }

        public void InvalidOption()
        {
            Console.WriteLine("\nOpcao invalida! Preciona qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public World AskForWorld(out int n)
        {
            int nLinhas;
            int nColunas;

            Console.WriteLine();
            Console.WriteLine("Inserir Dados Mundo");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.Write("Numero Linhas > ");
            nLinhas = Console.ReadLine();
            Console.Write("Numero Colunas > ");
            nColunas = int.Parse(Console.ReadLine());
            Console.Write("Numero Repeticoes > ");
            n = int.Parse(Console.ReadLine());

            return new World(nLinhas, nColunas);
        }


        public void ShowWorld(World world)
        {
            Console.WriteLine();

            for(int x = 0; x < world.NumLinhas; x++)
            {
                for(int y = 0; y < world.NumColunas; y++)
                {
                    if(world.GetValuePos(x,y) == TipoTerreno.Rock)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}