using System.Text;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class MatrizAdjacencia : IRepresentacaoGrafos
    {
        private double[,] matriz;

        public MatrizAdjacencia(int vertices)
        {
            matriz = new double[vertices, vertices];
        }

        public void ClonarMatriz(double[,] matrizClone)
        {
            for (int i = 0; i < QuantidadeDeVerices(); i++)
            {
                for (int j = 0; j < QuantidadeDeVerices(); j++)
                {
                    if (this.matriz[i,j]>0)
                    {
                        matrizClone[i, j] = matriz[i,j];
                    }
                }
            }

        }
        
        public void SubstituirOPeso(double peso, int origem, int destino)
        {
            int indiceOrigem = origem -1;
            int indiceDestino = destino -1;
            if (!IsArestaExistente(indiceOrigem,indiceDestino))
            {
                throw new ArgumentException("Não a aresta compativel com a informada! ");
            }
            matriz[indiceOrigem, indiceDestino] = peso;
        }

        public double obterPeso(int origem, int destino)
        {
            return matriz[origem, destino];
        }

        public void AdicionarAresta(int origem, int destino, double peso)
        {
            matriz[origem, destino] = peso;
        }

        public int QuantidadeDeVerices()
        {
            return matriz.GetLength(0);
        }

        public void Imprimir()
        {
            Console.WriteLine("Matriz de Adjacência:");
            int tamanho = matriz.GetLength(0);
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    Console.Write($"{matriz[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public string ObterArestasAdjacentes(int origem, int destino)
        {
            int tamanho = matriz.GetLength(0);
            int origemAux = origem - 1;
            int destinoAux = destino - 1;

            if (!IsArestaExistente(origemAux, destinoAux))
            {
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }

            string arestasAdjacentes = "\nArestas Adjacentes a aresta (" + origem + "," + destino + "):\n";

            for (int i = 0; i < tamanho; i++)
            {
                if (i != destinoAux && matriz[origemAux, i] > 0)
                {
                    arestasAdjacentes += $"({origem},{i + 1},{matriz[origemAux, i]})\n";
                }
                else if (matriz[i, origemAux] > 0)
                {
                    arestasAdjacentes += $"({i + 1},{origem},{matriz[i, origemAux]})\n";
                }
                else if (i != origemAux && matriz[i, destinoAux] > 0)
                {
                    arestasAdjacentes += $"({i + 1},{destino},{matriz[i, destinoAux]})\n";
                }
                else if (matriz[destinoAux, i] > 0)
                {

                    arestasAdjacentes += $"({destino},{i + 1},{matriz[destinoAux, i]})\n";
                }
            }
            return arestasAdjacentes;
        }


        public bool IsArestaExistente(int origem, int destino)
        {
            return origem >= 0 && origem < matriz.GetLength(0)
                && destino >= 0 && destino < matriz.GetLength(1)
                && matriz[origem, destino] > 0;
        }

        public Dictionary<string, StringBuilder> ObterVerticesAdjacentes(int vertice)
        {
            int tamanho = matriz.GetLength(0);
            int indiceVertice = vertice - 1;

            if (indiceVertice < 0 || indiceVertice >= tamanho)
            {
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            Dictionary<string, StringBuilder> adjacencias = new Dictionary<string, StringBuilder>();
            StringBuilder sucessores = new StringBuilder("Sucessores:\n");
            StringBuilder predecessores = new StringBuilder("Predecessores:\n");

            for (int i = 0; i < tamanho; i++)
            {
                if (matriz[indiceVertice, i] > 0)
                {
                    sucessores.AppendLine((i + 1).ToString());
                }

                if (matriz[i, indiceVertice] > 0)
                {
                    predecessores.AppendLine((i + 1).ToString());
                }
            }
            adjacencias.Add("sucessores", sucessores);
            adjacencias.Add("predecessores", predecessores);
            return adjacencias;
        }

        public string ObterArestasIncidentes(int vertice)
        {
            int tamanho = matriz.GetLength(0);
            int indiceVertice = vertice - 1;

            if (indiceVertice < 0 || indiceVertice >= tamanho)
            {
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            StringBuilder arestasIncidentes = new StringBuilder();

            for (int i = 0; i < tamanho; i++)
            {
                if (matriz[indiceVertice, i] > 0)
                {
                    string arestaFormatada = $"({vertice},{i + 1},{matriz[indiceVertice, i]})\n";
                    arestasIncidentes.AppendLine(arestaFormatada);
                }

                if (matriz[i, indiceVertice] > 0)
                {
                    string arestaFormatada = $"({i + 1},{vertice},{matriz[i, indiceVertice]})\n";
                    arestasIncidentes.AppendLine(arestaFormatada);
                }
            }
            return arestasIncidentes.ToString();
        }

        public string ObterVerticesIncidentesAAresta(int origem, int destino)
        {
            int tamanho = matriz.GetLength(0);
            int indiceOrigem = origem - 1;
            int indiceDestino = destino - 1;

            if (!IsArestaExistente(indiceOrigem, indiceDestino))
            {
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }

            string verticesIncidentes = "";

            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (i == indiceOrigem && j == indiceDestino && matriz[i, j] > 0)
                    {
                        verticesIncidentes += i + 1 + "\n";
                        verticesIncidentes += j + 1;
                    }
                }
            }
            return verticesIncidentes;
        }

        public bool VerificarVerticesAdjacentes(int origem, int destino)
        {
            int indiceOrigem = origem - 1;
            int indiceDestino = destino - 1;
            return IsArestaExistente(indiceOrigem, indiceDestino) || IsArestaExistente(indiceDestino, indiceOrigem);
        }

        public int ObterGrauEntradaVertice(int vertice)
        {
            int tamanho = matriz.GetLength(0);
            int indiceVertice = vertice - 1;

            if (indiceVertice < 0 || indiceVertice >= tamanho)
            {
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            int grau = 0;

            for (int i = 0; i < tamanho; i++)
            {
                if (matriz[i, indiceVertice] > 0)
                {
                    grau++;
                }
            }
            return grau;
        }

        public int ObterGrauSaidaVertice(int vertice)
        {
            int tamanho = matriz.GetLength(0);
            int indiceVertice = vertice - 1;

            if (indiceVertice < 0 || indiceVertice >= tamanho)
            {
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            int grau = 0;

            for (int i = 0; i < tamanho; i++)
            {
                if (matriz[indiceVertice, i] > 0)
                {
                    grau++;
                }
            }
            return grau;
        }

    }
}

