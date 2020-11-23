using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Compilador
{
    class AnalizadorSintactico
    {
        private Stack<int> pila = new Stack<int>();
        private string entrada, pilaString, reduccion;
        public void escanear(List<Token> listaTokens, DataGridView tabla)
        {
            while (true)
            {
                // Sección que entra al archivo .lr y encuentra la salida dependiendo del token a analizar
                StreamReader archivo = File.OpenText("compilador.lr");
                string linea = null;
                int i = 0;
                while (!archivo.EndOfStream)
                {
                    linea = archivo.ReadLine();
                    if (pila.Count == 0)
                    {
                        if (i == 54) break;
                    }
                    else
                        if (i == pila.Peek() + 54) break;

                    i++;
                }
                archivo.Close();
                List<int> arrayValores = obtenerArray(linea); // Se transorma el string obtenido de valores en un array de enteros

                int index = listaTokens[0].getValorEntero();
                int salidaLR = arrayValores[index];

                //Se muestra en la tabla los valores de la pila, la entrada y la salida
                foreach (Token t in listaTokens)
                    entrada += t.getValor() + " ";
                if (pila.Count == 0)
                    if(salidaLR > 0)
                        tabla.Rows.Add("$0", entrada, "D"+salidaLR.ToString());
                    else
                        tabla.Rows.Add("$0", entrada, "R" + salidaLR.ToString());
                else
                {
                    var copiaPila = new Stack<int>(new Stack<int>(pila));
                    while (copiaPila.Count > 0)
                    {
                        pilaString += copiaPila.Peek().ToString() + " "; 
                        copiaPila.Pop();
                    }
                    if (salidaLR > 0)
                        tabla.Rows.Add(pilaString+ " $0", entrada, "D" + salidaLR.ToString());
                    else
                        tabla.Rows.Add(pilaString+ " $0", entrada, "R" + salidaLR.ToString());
                }

                if(salidaLR == -1)
                {
                    MessageBox.Show("Análisis sintáctico terminado con éxito");
                    break;
                }
                if(salidaLR == 0)
                {
                    MessageBox.Show("Error sintáctico en '" + listaTokens[0] + "' ");
                    break;
                }
                if(salidaLR > 0)
                {
                    pila.Push(listaTokens[0].getValorEntero());
                    pila.Push(salidaLR);
                    listaTokens.RemoveAt(0);
                }
                if(salidaLR < -1)
                {

                }
                pilaString = "";
                entrada = "";
                MessageBox.Show("Pausa para el café");
            }
        }

        private List<int> obtenerArray(string linea)
        {
            List<int> arraylinea = new List<int>();

            // Se convierte la línea que se captura a un array de enteros
            linea = linea.Replace("\t", " ");
            for (int j = 0; j < linea.Length; j++)
            {
                if (linea.Substring(j, 1) != " ")
                {
                    if (linea.Substring(j, 1) == "-")
                    {
                        if (linea.Substring(j + 2, 1) != " ")
                        {
                            arraylinea.Add(Int32.Parse(linea.Substring(j + 1, 1) + linea.Substring(j + 2, 1)) * -1);
                            j++;
                        }
                        else
                            arraylinea.Add(Int32.Parse(linea.Substring(j + 1, 1)) * -1);
                        j++;
                    }
                    else
                    {
                        if (j < linea.Length - 1)
                            if (linea.Substring(j + 1, 1) != " ")
                            {
                                arraylinea.Add(Int32.Parse(linea.Substring(j, 1) + linea.Substring(j + 1, 1)));
                                j++;
                            }
                            else
                                arraylinea.Add(Int32.Parse(linea.Substring(j, 1)));
                        else
                            arraylinea.Add(Int32.Parse(linea.Substring(j, 1)));
                    }
                }
            }
            return arraylinea;
        }
    }
}
