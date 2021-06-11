namespace MyCaves
{
    public class Controller
    {
        private World[] words;
        private View view;

        private string linhas, colunas, nString;

        public Controller(string[] args)
        {
            words = new World[3];

            if(args.Length == 3)
            {
                linhas = args[0];
                colunas = args[1];
                nString = args[2];
            }
            else
            {
                System.Environment.Exit(0);  
            }
        }

        public void Run(View view)
        {
            this.view = view;
            
            //verifica se os argumentos dados são numeros
            int nLinhas = -5;
            int.TryParse(linhas, out nLinhas);
            int nColunas = -5;
            int.TryParse(colunas, out nColunas);
            int n = -5;
            int.TryParse(nString, out n);

            //se os numeros forem positivos (verifica tbm se string alterou o num)
            if((n > 0 ) && (nColunas > 0 ) && (nLinhas > 0))
            {
                //Cria mundo novo
                CreatNewWorld(nLinhas,nColunas,n);

                //Implementa Algoritmo
                Algoritmo(n);

                //Mostra o mundo gerado
                view.ShowWorld(words[0]);
            }
        }

        //Gera o mundo principal bem como os restantes
        private void CreatNewWorld(int nLinhas, int nColunas, int n)
        {
            World world = new World(nLinhas, nColunas);
            World newWorld = new World(world.NumLinhas, world.NumColunas);
            World auxWorld = new World(world.NumLinhas, world.NumColunas);

            words[0] = world;
            words[1] = newWorld;
            words[2] = auxWorld;
        }

        //o algoritmo pedido
        private void Algoritmo(int n)
        {
            for(int i = 0; i < n; i++)
            {
                //percorrer o newWorld e construi-lo
                for(int x = 0; x < words[1].NumLinhas; x++)
                {
                    for(int y = 0; y < words[1].NumColunas; y++)
                    {
                        if(words[0].VerificarCasasVizinhasRock(x, y) == true)
                            words[1].SetValuePos(x, y, TipoTerreno.Rock);
                        else
                            words[1].SetValuePos(x, y, TipoTerreno.Ground);
                    }
                }
                //trocar Referencias entre o world e newWorld
                TrocarRef();
            }
        }

        //trocar referencias entre o world e new world
        private void TrocarRef()
        {
            words[2].CopyOtherWorld(words[0]);
            words[0].CopyOtherWorld(words[1]);
            words[1].CopyOtherWorld(words[2]);
        }
    }
}