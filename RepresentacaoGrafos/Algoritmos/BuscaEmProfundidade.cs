using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos.Algoritmos
{
    public class BuscaEmProfundidade
    {
        private int verticeInicial;
        private IRepresentacaoGrafos grafos;
        private int[] tempoDescoberta;
        private int[] tempoDeTermino;
        private int[] predecessor;
        private int tempoGlobal;

        public BuscaEmProfundidade(int verticeInicial, IRepresentacaoGrafos grafos)
        {
            this.verticeInicial = verticeInicial;
            this.grafos = grafos;
            tempoDescoberta = new int[grafos.QuantidadeDeVertices()];
            tempoDeTermino = new int[grafos.QuantidadeDeVertices()];
            predecessor = new int[grafos.QuantidadeDeVertices()];
            tempoGlobal = 0;
        }

        public int GetVerticeInicial()
        {
            return verticeInicial;
        }

        public void IniciarBusca()
        {
            int n = grafos.QuantidadeDeVertices();

            tempoGlobal = 0;
            int indiceVertice = verticeInicial - 1;

            for (int i = 0; i < n; i++)
            {
                tempoDeTermino[i] = 0;
                tempoDescoberta[i] = 0;
                predecessor[i] = -1;
            }

            ExecultarBuscaEmProfundidade(indiceVertice);

            while (tempoDeTermino.ToList().Any(tempoDescoberta => tempoDescoberta == 0))
            {
                int verticeNaoVisitado = tempoDeTermino.ToList().FindIndex(tempoDescoberta => tempoDescoberta == 0);

                if (verticeNaoVisitado != -1)
                    ExecultarBuscaEmProfundidade(verticeNaoVisitado);
            }
            ;

        }

        public void ExecultarBuscaEmProfundidade(int vertice)
        {
            tempoGlobal++;
            tempoDescoberta[vertice] = tempoGlobal;

            List<int> vizinhos = grafos.ObterVizinhos(vertice);
            vizinhos.OrderBy(x => x);
            foreach (int v in vizinhos)
            {
                if (tempoDescoberta[v] == 0)
                {
                    predecessor[v] = vertice;
                    ExecultarBuscaEmProfundidade(v);
                }
            }
            tempoGlobal++;
            tempoDeTermino[vertice] = tempoGlobal;
        }

        public void Imprimir()
        {
            Console.WriteLine("Informações da busca: ");
            for (int i = 0; i < grafos.QuantidadeDeVertices(); i++)
            {
                if (predecessor[i] != -1)
                {
                    Console.Write($"pai[{(i + 1)}]: {(predecessor[i] + 1)}; ");
                }
                else
                {
                    Console.Write($"pai[{i+1}]: não possui predecessor; ");
                }
                Console.Write($"tempo de descoberta[{(i + 1)}]: {tempoDescoberta[i]}; ");
                Console.Write($"tempo de término[{(i + 1)}]: {tempoDeTermino[i]};\n");
                Console.WriteLine();
            }

        }

    }
}
