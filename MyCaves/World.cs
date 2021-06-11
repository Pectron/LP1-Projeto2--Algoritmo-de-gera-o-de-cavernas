using System.Random;

namespace MyCaves
{
    public class World
    {
        public int NumLinhas {get; set;}
        public int NumColunas{get; set;}

        private TipoTerreno[,] world;

        public World(int numLinhas, int numColunas)
        {
            world = new TipoTerreno[numLinhas, numColunas];

            GenerateRandomWorld();
        }


        private void GenerateRandomWorld()
        {   
            for(int x = 0; x < world.GetLength(0); x++)
            {
                for(int y = 0; y < world.GetLength(1); y++)
                {
                    Random rand = new Random();
                    int value = rand.Next(1,3);

                    if(value == 1)
                        world = TipoTerreno.Ground;
                    else
                        world = TipoTerreno.Rock;
                }
            }
        }

        private int GetPosicaoOver(int pos)
        {
            //se 10 fica 0, se 11 fica 1, ..
            if(pos >= 10)                
                pos -= 10; 

            //se -1 fica 9, se -2 fica 8, ..
            else if(pos < 0)
                pos += 10;

            return pos;
        }

        //funcao retorna true se tiver >= 5 casas rock vizinhas
        public bool VerificarCasasVizinhasRock(int x, int y)
        {
            bool casasRock = false;
            int numRocks = 0;

            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    int X = GetPosicaoOver(x+i);
                    int Y = GetPosicaoOver(y+j);

                    if(world[X, Y] == TipoTerreno.Rock)
                        numRocks += 1;
                }
            }

            if(numRocks >= 5)
                casasRock = true;

            return casasRock;
        }

        public TipoTerreno GetValuePos(int x, int y) => world[x,y];
        

        public void CopyOtherWorld(TipoTerreno[,] otherWorld)
        {
            for(int x = 0; x < world.GetLength(0); x++)
            {
                for(int y = 0; y < world.GetLength(1); y++)
                {
                    world = otherWorld.GetValuePos(x,y);
                }
            }
        }
    }
}