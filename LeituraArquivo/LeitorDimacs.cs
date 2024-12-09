using System.Text;
using tp_grafos.RepresentacaoGrafos;

namespace tp_grafos.LeituraArquivo
{
    internal class LeitorDimacs
    {
        public IRepresentacaoGrafos ParseToRepresentacaoGrafo(string caminhoArquivo)
        {
            IRepresentacaoGrafos representacaoGrafos;
            try
            {
                StreamReader arq = new StreamReader(caminhoArquivo, Encoding.UTF8);

                string configGrafo = arq.ReadLine();

                string[] atributosGrafo = configGrafo.Split(' ');

                int numVertices = Convert.ToInt32(atributosGrafo[0]);

                int numArestas = Convert.ToInt32(atributosGrafo[1]);

                double densidade = (double) numArestas/(numVertices*(numVertices-1));

                if(Math.Round(densidade) == 1){
                    representacaoGrafos = new MatrizAdjacencia(numVertices);
                }else{
                    representacaoGrafos = new ListaAdjacencia(numVertices);
                }

                for (int i = 0; i < numArestas; i++)
                {
                    string configAresta = arq.ReadLine();
                    if (configAresta != null)
                    {
                        string[] atributosAresta = configAresta.Split(' ');

                        int origem = Convert.ToInt32(atributosAresta[0]);
                        int destino = Convert.ToInt32(atributosAresta[1]);
                        int peso = Convert.ToInt32(atributosAresta[2]);


                        origem--;
                        destino--;

                        representacaoGrafos.AdicionarAresta(origem, destino, peso);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ler o arquivo: " + caminhoArquivo);
            }

            return representacaoGrafos;
        }    
    }
}
