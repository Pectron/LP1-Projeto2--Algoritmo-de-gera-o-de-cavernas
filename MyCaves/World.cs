namespace MyCaves
{
    public class World
    {
        public int NumLinhas {get; set;}
        public int NumColunas{get; set;}

        public TipoTerreno[,] world;

        public World(int numLinhas, int numColunas)
        {
            world = new TipoTerreno[numLinhas, numColunas];
            //gerar mundo
        }


        private void GenerateRandomWorld()
        {   
            for(int x = 0; x < world.GetLength(0); x++)
            {
                for(int y = 0; y < world.GetLength(1); y++)
                {
                    Random rand = new Random();
                    
                }
            }
        }
    }
}