using System;
using System.Collections.Generic;

namespace MyCaves
{
    public class View
    {
        public View() {}

        public void InvalidOption()
        {
            Console.WriteLine("\nOpcao invalida! Preciona qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        //mostrar mapa gerado
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