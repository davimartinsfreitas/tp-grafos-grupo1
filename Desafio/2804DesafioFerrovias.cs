namespace tp_grafos.RepresentacaoGrafos
{
    public class DesafioFerrovias
    {
        public void Executar()
        {
            string entrada = Console.ReadLine() ?? " " ;

            string[] configGrafo = entrada.Split(' ');

            int numCidades = int.Parse(configGrafo[0]);

            int custoMedio = int.Parse(configGrafo[1]);

            int[,] grafo = new int[numCidades, numCidades];

            for (int i = 0; i < numCidades; i++)
            {
                string[] distancias = Console.ReadLine().Split(' ');
                for (int j = 0; j < numCidades; j++)
                {
                    grafo[i, j] = int.Parse(distancias[j]);
                }
            }

            bool matrizModificada = false;
          
            for (int k = 0; k < numCidades && !matrizModificada; k++)
            {
                for (int j = 0; j < numCidades && !matrizModificada; j++)
                {
                    if (grafo[k, j] != grafo[j, k] || (k == j && grafo[k,j] > 0))
                    {
                        matrizModificada = true;
                    }
                }
            }

            if (!matrizModificada)
            {
                for (int k = 0; k < numCidades && !matrizModificada; k++)
                {
                    for (int j = 0; j < numCidades && !matrizModificada; j++)
                    {
                        for (int i = 0; i < numCidades && !matrizModificada; i++)
                        {
                            if (grafo[i, j] > grafo[i, k] + grafo[k, j])
                            {
                                matrizModificada = true;
                            }

                        }
                    }
                }
            }

            if (matrizModificada)
            {
                Console.WriteLine("*");
            }
            else
            {
                int custoTotal = 0;
                int numeroArestasEssenciais = 0;

                for (int i = 0; i < numCidades; i++)
                {
                    for (int j = 0; j < numCidades; j++)
                    {
                        if (grafo[i, j] > 0)
                        {
                            bool arestaEsssencial = true;

                            for (int k = 0; k < numCidades; k++)
                            {
                                if (k != i && k != j && grafo[i, j] == grafo[i, k] + grafo[k, j])
                                {
                                    arestaEsssencial = false;
                                    break;
                                }
                            }

                            if (arestaEsssencial)
                            {
                                numeroArestasEssenciais++;
                            }
                        }
                    }
                }
                custoTotal = (numeroArestasEssenciais * custoMedio)/2;
                Console.WriteLine(custoTotal);
            }
        }
    }
}
