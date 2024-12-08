using System;
using System.Collections.Generic;
using System.Text;

namespace tp_grafos.RepresentacaoGrafos.Algoritmos
{
    internal class BuscaEmLargura
    {
        private IRepresentacaoGrafos _grafo;
        private bool[] _visitados;
        private List<int> _resultado;
        private Queue<int> _fila;

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

            // Adiciona o vértice inicial à fila
            int indiceInicio = inicio - 1; // Converter para 0-indexado
            _fila.Enqueue(indiceInicio);
            _visitados[indiceInicio] = true;

            Console.WriteLine($"Iniciando BFS a partir do vértice: {inicio}");

            while (_fila.Count > 0)
            {
                int atual = _fila.Dequeue();
                _resultado.Add(atual + 1); // Armazenar o índice ajustado (1-indexado)

                Console.WriteLine($"Processando vértice: {atual + 1}");

                // Obter vértices adjacentes do atual
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

            // Após o loop, verificar se há vértices desconexos e adicioná-los
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
            return sb.ToString();
        }
    }
}
