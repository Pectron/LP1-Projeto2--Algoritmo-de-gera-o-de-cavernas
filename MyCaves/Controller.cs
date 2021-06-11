namespace MyCaves
{
    public class Controller
    {
        private World[] words;
        private View view;

        public Controller()
        {
            words = new World[3];
        }

        public void Run(View view)
        {
            int input;
            this.view = view;

            do
            {
                // 1 -> Construir novo Mundo
                // 0 -> Exit
                input = view.MainMenu();

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        int n = InsertNewWorld();
                        Algoritmo(n);
                        view.ShowWorld();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            }
            while (input != 0);
        }


        private int InsertNewWorld()
        {
            // Pedir à view um novo world
            int n;
            World world = view.AskForWorld(n);

            World newWorld = new World(world.NumLinhas, world.NumColunas);
            World auxWorld = new World(world.NumLinhas, world.NumColunas);

            words[0] = word;
            words[1] = newWorld;
            words[2] = auxWorld;

            return n;
        }

        private void Algoritmo(int n)
        {
            for(int i = 0; i < n; i++)
            {
                //percorrer o newWorld e construi-lo
                for(int x = 0; x < words[1].NumLinhas; x++)
                {
                    for(int y = 0; y < words[1].NumColunas; y++)
                    {
                        if(words[0].VerificarCasasVizinhasRock() == true)
                            words[1].SetValuePos = TipoTerreno.Rock;
                        else
                            words[1].SetValuePos = TipoTerreno.Ground;
                    }
                }
                //trocar Referencias entre o world e newWorld
                TrocarRef();
            }
        }

        private void TrocarRef()
        {
            words[2].CopyOtherWorld(words[0]);
            words[0].CopyOtherWorld(words[1]);
            words[1].CopyOtherWorld(words[2]);
        }
    }
}