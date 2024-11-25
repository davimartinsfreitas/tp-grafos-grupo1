using System.Text;
using tp_grafos.RepresentacaoGrafos;

namespace tp_grafos.LeituraArquivo
{
    internal class LeitorDimacs
    {
        private string caminhoArquivo;
        private MatrizAdjacencia? matrizAdjacencia;

        public LeitorDimacs(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public MatrizAdjacencia? LerDados()
        {
            try
            {
                StreamReader arq = new StreamReader(caminhoArquivo, Encoding.UTF8);

                string configuracaoGrafo = arq.ReadLine();

                string[] atributosGrafos = configuracaoGrafo.Split(' ');

                int numVertices = Convert.ToInt32(atributosGrafos[0]);

                int numArestas = Convert.ToInt32(atributosGrafos[1]);

                matrizAdjacencia = new MatrizAdjacencia(numVertices);

                for (int i = 0; i < numArestas; i++)
                {
                    string dadosAresta = arq.ReadLine();
                    string[] atributosAresta = dadosAresta.Split(' ');

                    int origem = Convert.ToInt32(atributosAresta[0])-1;
                    int destino = Convert.ToInt32(atributosAresta[1])-1;
                    int peso =  Convert.ToInt32(atributosAresta[2]);

                    matrizAdjacencia.AdicionarAresta(origem,destino,peso);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            return matrizAdjacencia;
        }

        public MatrizAdjacencia? Grafo
        { 
            get {return matrizAdjacencia; }
        }
    }
}
