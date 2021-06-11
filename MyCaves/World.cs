using System;

namespace MyCaves
{
    public class World
    {
        public int NumLinhas {get; set;}
        public int NumColunas{get; set;}
        private TipoTerreno[,] world;

        public World(int numLinhas, int numColunas)
        {
            NumLinhas = numLinhas;
            NumColunas = numColunas;
            
            world = new TipoTerreno[NumLinhas, NumColunas];

            GenerateRandomWorld();
        }


        //Gera um mundo aleatorio com rock e ground
        private void GenerateRandomWorld()
        {   
            for(int x = 0; x < world.GetLength(0); x++)
            {
                for(int y = 0; y < world.GetLength(1); y++)
                {
                    Random rand = new Random();
                    int value = rand.Next(1,3);

                    if(value == 1)
                        world[x,y] = TipoTerreno.Ground;
                    else
                        world[x,y] = TipoTerreno.Rock;
                }
            }
        }

        //Funcao usada quando o x ou y ultrapassam o numero limite do mapa
        private int GetPosicaoOver(int pos, bool linhas)
        {
            if(linhas)
            {
                if(pos >= NumLinhas)
                {
                    pos -= NumLinhas;
                }
                else if(pos < 0)
                {
                    pos += NumLinhas;
                }
            }
            else
            {
                if(pos >= NumColunas)
                {
                    pos -= NumColunas;
                }
                else if(pos < 0)
                {
                    pos += NumColunas;
                }
            }

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
                    int X = GetPosicaoOver(x+i, true);
                    int Y = GetPosicaoOver(y+j, false);
                    
                    if(world[X, Y] == TipoTerreno.Rock)
                        numRocks += 1;
                }
            }

            if(numRocks >= 5)
                casasRock = true;

            return casasRock;
        }

        //obter o tipo de terreno no local do mapa
        public TipoTerreno GetValuePos(int x, int y)
        {
            int X = GetPosicaoOver(x, true);
            int Y = GetPosicaoOver(y, false);
            return world[x,y];
        }

        //alterar o tipo de terreno no local do mapa
        public void SetValuePos(int x, int y, TipoTerreno terreno)
        {
            world[x,y] = terreno;
        }
        
        //copiar mundo
        public void CopyOtherWorld(World otherWorld)
        {
            for(int x = 0; x < NumLinhas; x++)
            {
                for(int y = 0; y < NumColunas; y++)
                {
                    world[x,y] = otherWorld.GetValuePos(x,y);
                }
            }
        }
    }
}