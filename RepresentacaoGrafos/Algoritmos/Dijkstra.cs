using System.Text;

namespace tp_grafos.RepresentacaoGrafos.Algoritmos
{
    public class Dijkstra
    {
        private int raiz;
        private int destino;
        private int[] caminho;
        private double[] distancia;
        private bool[] explorados;
        private IRepresentacaoGrafos representacaoGrafos;
        public Dijkstra(int raiz, int destino, IRepresentacaoGrafos RepresentacaoGrafos) 
        {
            this.raiz = raiz;
            this.destino = destino;
            this.representacaoGrafos = RepresentacaoGrafos;
        }

        public int Raiz
        {
            get { return raiz; }
        }

        public int Destino
        {
            get { return destino; }
        }

        public void ExecultarMetodo()
        {
            int indiceRaiz = raiz - 1;
            int n = representacaoGrafos.QuantidadeDeVertices();
            distancia = new double[n];
            caminho = new int[n];
            explorados = new bool[n];

            for (int j = 0; j < n; j++)
            {
                distancia[j] = double.MaxValue;
            }

            distancia[indiceRaiz] = 0;

            for (int i = 0; i < n; i++)
            {
                double menor = double.MaxValue;
                int menorIndice = -1;

                if (explorados[i] == false && distancia[i] <= menor)
                {
                    menor = distancia[i];

                    menorIndice = i;
                }

                explorados[menorIndice] = true;

                for (int k = 0; k < n; k++)
                {
                    if (explorados[k] == false && representacaoGrafos.IsArestaExistente(menorIndice, k) && distancia[menorIndice] + representacaoGrafos.obterPeso(menorIndice, k) < distancia[k])
                    {
                        caminho[k] = menorIndice;
                        distancia[k] = distancia[menorIndice] + representacaoGrafos.obterPeso(menorIndice, k);
                    }
                }
            }
        }

        public string imprimir()
        {
            List<int> rota = new List<int>();
            List<double> pesos = new List<double>();

            int indiceDestino = destino - 1;
            int atual = indiceDestino;
            while (atual != raiz-1)
            {
                rota.Add(atual);

                int aux = atual;

                atual = caminho[atual];

                pesos.Add(representacaoGrafos.obterPeso(atual, aux));
            }
            rota.Reverse();
            pesos.Reverse();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Caminho mínimo:");
            for (int i = 0; i < rota.Count; i++)
            {
               sb.AppendLine($"vértice: {rota[i]} - peso: {pesos[i]}");
            }
            sb.AppendLine($"Distância total: {distancia[indiceDestino]}");

            return sb.ToString();
        }
    }
}
    

