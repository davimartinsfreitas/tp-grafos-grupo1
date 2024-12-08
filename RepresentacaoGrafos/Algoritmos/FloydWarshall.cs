using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_grafos.RepresentacaoGrafos.Algoritmos
{
    public class Floyd_Warshall
    {
        private IRepresentacaoGrafos? grafos;
        private double[,] distancia;

        public Floyd_Warshall(IRepresentacaoGrafos grafos)
        {
            this.grafos = grafos;
            distancia = new double[0, 0];
        }
        public void execultarFloyd()
        {

            int n = grafos.QuantidadeDeVerices();
            distancia = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        distancia[i, j] = int.MaxValue;
                    }
                    else
                    {
                        distancia[i, j] = 0;
                    }

                }
            }
           grafos.ClonarMatriz(distancia);

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distancia[i, j] > distancia[i, k] + distancia[k, j])
                        {
                            distancia[i, j] = distancia[i, k] + distancia[k, j];
                        }

                    }
                }
            }
        }
        public string ImprimirMenorCaminho()
        {
            var result = new StringBuilder();
            int n = grafos.QuantidadeDeVerices();

            result.AppendLine("Distâncias:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.Append(distancia[i, j] + " "); 
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
