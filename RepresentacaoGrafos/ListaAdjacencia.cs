﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tp_grafos.RepresentacaoGrafos
{
    internal class ListaAdjacencia : IRepresentacaoGrafos
    {
          private Dictionary<int, List<(int, int)>> lista;

        public ListaAdjacencia(int vertices)
        {
            lista = new Dictionary<int, List<(int, int)>>();
            for (int i = 1; i <= vertices; i++)
            {
                lista[i] = new List<(int, int)>();
            }
        }
 
        public void AdicionarAresta(int origem, int destino, int peso)
        {
            lista[origem].Add((destino, peso));
        }
 
        public void Imprimir()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var vertice in lista)
            {
                Console.Write($"{vertice.Key}: ");
                foreach (var aresta in vertice.Value)
                {
                    Console.Write($"({aresta.Item1}, {aresta.Item2}) ");
                }
                Console.WriteLine();
            }
        }

        public string ObterArestasAdjacentes(int origem, int destino){
            if(!IsArestaExistente(origem, destino)){
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }
            
            string arestasAdjacentes = "\nArestas Adjacentes a aresta (" + origem + "," + destino + "):\n";

            foreach(KeyValuePair<int, List<(int, int)>> adjacencias in lista)
            {
                foreach(var elemento in adjacencias.Value)
                {
                    bool mesmoPredecessor = adjacencias.Key == destino || (adjacencias.Key == origem && elemento.Item1 != destino);
                    bool mesmoSucessor = adjacencias.Key != origem && (elemento.Item1 == origem || elemento.Item1 == destino);
                    
                    if(mesmoPredecessor || mesmoSucessor)
                    {
                        arestasAdjacentes += "(" + adjacencias.Key + "," + elemento.Item1 + "," + elemento.Item2 + ")\n"; 
                    }
                }
            }

            return arestasAdjacentes;
        }

        public bool IsArestaExistente(int origem, int destino)
        {
            return lista.ContainsKey(origem) && lista[origem].Find(a => a.Item1 == destino) != (0, 0);
        }

        public Dictionary<string, StringBuilder> ObterVerticesAdjacentes(int vertice)
        {
            if(!lista.ContainsKey(vertice)){
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            Dictionary<string, StringBuilder> verticesAdjacentes = new Dictionary<string, StringBuilder>();
            
            StringBuilder sucessores = new StringBuilder("Sucessores:\n");
            lista[vertice].ForEach((aresta) => sucessores.AppendLine(aresta.Item1.ToString()));

            StringBuilder predecessores = new StringBuilder("Predecessores:\n");
            foreach(KeyValuePair<int, List<(int, int)>> adjacencias in lista)
            {
                if(adjacencias.Value.Any((aresta) => aresta.Item1 == vertice))
                    predecessores.AppendLine(adjacencias.Key.ToString());
            }

            verticesAdjacentes.Add("sucessores", sucessores);
            verticesAdjacentes.Add("predecessores", predecessores);
            return verticesAdjacentes;        
        }

        public string ObterArestasIncidentes(int vertice)
        {
            if (!lista.ContainsKey(vertice))
            {
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            StringBuilder arestasIncidentes = new StringBuilder();

            foreach(KeyValuePair<int, List<(int, int)>> adjacencias in lista)
            {
                foreach(var aresta in  adjacencias.Value)
                {
                    if ( adjacencias.Key == vertice || (adjacencias.Key != vertice && aresta.Item1 == vertice) )
                    {
                        string arestaFormatada = "(" + adjacencias.Key + "," + aresta.Item1 + "," + aresta.Item2 + ")";
                        arestasIncidentes.AppendLine(arestaFormatada);
                    }
                }
            }
            return arestasIncidentes.ToString();
        }

        public string ObterVerticesIncidentesAAresta(int origem, int destino)
        {
            if(!IsArestaExistente(origem, destino)){
                throw new ArgumentException("A aresta informada não existe no grafo!");
            }
            string verticesIncidentes = lista.Keys.First((vertice) => vertice == origem).ToString();
            verticesIncidentes += "\n"+lista[origem].First((aresta) => aresta.Item1 == destino).Item1;

            return verticesIncidentes;
        }

        public bool VerificarVerticesAdjacentes(int origem, int destino)
        {
            return IsArestaExistente(origem, destino) || IsArestaExistente(destino, origem);
        }

        public int ObterGrauEntradaVertice(int vertice)
        {
            if(!lista.ContainsKey(vertice)){
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }

            int grau = 0;

            foreach(KeyValuePair<int, List<(int, int)>> adjacencias in lista)
            {
                if(adjacencias.Value.Any((aresta) => aresta.Item1 == vertice && adjacencias.Key != vertice))
                {
                    grau++;
                }
            }    

            return grau;
        }

        public int ObterGrauSaidaVertice(int vertice)
        {
            if(!lista.ContainsKey(vertice)){
                throw new ArgumentException("O vértice informado não existe no grafo!");
            }
        
            int grau = 0;
            lista[vertice].ForEach((aresta) => grau++);
            return grau;
        }
    }
}
    