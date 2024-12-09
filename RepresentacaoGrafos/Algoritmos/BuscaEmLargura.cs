using System;
using System.Collections.Generic;
using System.Text;

namespace tp_grafos.RepresentacaoGrafos.Algoritmos
{
    public class BuscaEmLargura
    {
        private IRepresentacaoGrafos _grafo;
        private bool[] _visitados;
        private List<int> _resultado;
        private Queue<int> _fila;
        private int[] _nivel;
        private int[] _predecessor;

        public BuscaEmLargura(IRepresentacaoGrafos grafo)
        {
            _grafo = grafo;
        }

        public string Executar(int inicio)
        {
            int vertices = _grafo.QuantidadeDeVertices();
            _visitados = new bool[vertices];
            _resultado = new List<int>();
            _fila = new Queue<int>();
            _nivel = new int[vertices];
            _predecessor = new int[vertices];

            for (int i = 0; i < vertices; i++)
            {
                _predecessor[i] = -1;
            }

            int indiceInicio = inicio - 1;
            _fila.Enqueue(indiceInicio);
            _visitados[indiceInicio] = true;

            Console.WriteLine($"Iniciando BFS a partir do vértice: {inicio}");

            while (_fila.Count > 0)
            {
                int atual = _fila.Dequeue();
                _resultado.Add(atual + 1);

                Console.WriteLine($"Processando vértice: {atual + 1}");

                List<int> vizinhos = ObterVizinhos(atual);
                vizinhos.OrderBy(x => x);
                foreach (var vizinho in vizinhos)
                {
                    if (!_visitados[vizinho])
                    {
                        Console.WriteLine($"  Visitando e enfileirando: {vizinho + 1}");
                        _visitados[vizinho] = true;
                        _nivel[vizinho] = _nivel[atual] + 1;
                        _predecessor[vizinho] = atual;
                        _fila.Enqueue(vizinho);
                    }
                }
            }

            for (int i = 0; i < vertices; i++)
            {
                if (!_visitados[i])
                {
                    Console.WriteLine($"Vértice desconexo encontrado: {i + 1}. \n Iniciando nova BFS.");
                    _fila.Enqueue(i);
                    _visitados[i] = true;

                    while (_fila.Count > 0)
                    {
                        int atual = _fila.Dequeue();
                        _resultado.Add(atual + 1);

                        foreach (var vizinho in ObterVizinhos(atual))
                        {
                            if (!_visitados[vizinho])
                            {
                                Console.WriteLine($"  Visitando e enfileirando: {vizinho + 1}");
                                _visitados[vizinho] = true;
                                _fila.Enqueue(vizinho);
                            }
                        }
                    }
                }
            }

            return FormatResultado();
        }

        private List<int> ObterVizinhos(int vertice)
        {
            return _grafo.ObterVizinhos(vertice);
        }

        private string FormatResultado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ordem de visita (BFS):");
            foreach (var vertice in _resultado)
            {
                sb.AppendLine($"Vértice {vertice}");
            }

            sb.AppendLine("\nInformações da busca:");

            for (int i = 0; i < _grafo.QuantidadeDeVertices(); i++)
            {
                sb.AppendLine();
                if (_predecessor[i] != -1)
                {
                    sb.Append($"pai[{(i + 1)}]: {(_predecessor[i] + 1)}; ");
                }
                else
                {
                    sb.Append($"pai[{i + 1}]: não possui predecessor; ");
                }

                sb.Append($"nivel[{(i + 1)}]: {_nivel[i]};\n");
            }

            return sb.ToString();
        }
    }
}
