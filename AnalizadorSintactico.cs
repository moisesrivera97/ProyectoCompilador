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
        private string entrada, pilaString;

        //Datos para crear el árbol de análisis sintáctico
        int nombreAux = 0;
        Stack<Dictionary<string, string>> arbolReal = new Stack<Dictionary<string, string>>(); //Lista para pruebas
        public Stack<Dictionary<string, string>> escanear(List<Token> listaTokens, DataGridView tabla)
        {
            while (true)
            {
                string linea = obtenerLinea();
                List<int> arrayValores = obtenerArray(linea); // Se transorma el string obtenido de valores en un array de enteros

                int index = listaTokens[0].getValorEntero();
                int salidaLR = arrayValores[index];

                //Se muestra en la tabla los valores de la pila, la entrada y la salida
                foreach (Token t in listaTokens)
                    entrada += t.getValor() + " ";
                if (pila.Count == 0)
                    if(salidaLR > 0)
                        tabla.Rows.Add(" 0 23", entrada, "D"+salidaLR.ToString());
                    else if (salidaLR < 0)
                        tabla.Rows.Add(" 0 23", entrada, "R" + ((salidaLR * -1) - 1).ToString());
                    else
                        tabla.Rows.Add(" 0 23", entrada, "ERROR");
                else
                {
                    var copiaPila = new Stack<int>(new Stack<int>(pila));
                    while (copiaPila.Count > 0)
                    {
                        pilaString += copiaPila.Peek().ToString() + " "; 
                        copiaPila.Pop();
                    }
                    if (salidaLR > 0)
                        tabla.Rows.Add(pilaString+ " 0 23", entrada, "D" + salidaLR.ToString());
                    else if (salidaLR < 0)
                        tabla.Rows.Add(pilaString+ " 0 23", entrada, "R" + ((salidaLR * -1) - 1).ToString());
                    else
                        tabla.Rows.Add(" 0 23", entrada, "ERROR");
                }

                // Parte que realiza una acción dependiendo se se obtuvo un desplazamiento, reducción o error.
                if(salidaLR == -1)
                {
                    MessageBox.Show("Análisis sintáctico terminado con éxito");
                    break;
                }
                if(salidaLR == 0)
                {
                    MessageBox.Show("Error sintáctico en '" + listaTokens[0].getValor() + "' ");
                    break;
                }
                if(salidaLR > 0)
                {
                    pila.Push(listaTokens[0].getValorEntero());
                    pila.Push(salidaLR);
                    Dictionary<string, string> dic = new Dictionary<string, string>(); // pruebas
                    dic.Add(listaTokens[0].getValor(), ""); //pruebas
                    arbolReal.Push(dic);   // Arbol para pruebas
                    listaTokens.RemoveAt(0);
                }
                if(salidaLR < -1)
                {
                    StreamReader reduccion = File.OpenText("compilador.lr");
                    string red = null;
                    int cont = 0;
                    while (!reduccion.EndOfStream)
                    {
                        red = reduccion.ReadLine();

                        if (cont == ((salidaLR * -1) - 1)) break;

                        cont++;
                    }
                    reduccion.Close();

                    //Convertir en lista de cadenas el resultado de la reducción
                    List<string> reduccionValor = new List<string>();
                    red = red.Replace("\t", " ");
                    string aux = null;
                    for (int v = 0; v < red.Length; v++)
                    {
                        if (red.Substring(v, 1) != " ")
                        {
                            aux += red.Substring(v, 1);
                            if(v == red.Length - 1)
                                reduccionValor.Add(aux);
                        }
                        else
                        {
                            reduccionValor.Add(aux);
                            aux = "";
                        }
                    }
                    int eliminaciones = 0;
                    string name = null;
                    if (reduccionValor[2] != "programa")
                        name = reduccionValor[2] + "," + nombreAux.ToString();
                    else
                        name = reduccionValor[2];

                    // Lista de pruebas
                    Dictionary<string, string> nodo = new Dictionary<string, string>();
                    string hijos = "[";
                    if (Int32.Parse(reduccionValor[1]) == 0)
                    {
                        nodo.Add(name, "");
                        arbolReal.Push(nodo);
                    }
                    else
                    {
                        while (eliminaciones < Int32.Parse(reduccionValor[1])*2)
                        {
                            if (pila.Count > 0)
                            {
                                if (eliminaciones > 0 && eliminaciones % 2 != 0)
                                {
                                    if (arbolReal.Peek().Values.First() == "")
                                    {
                                        if (eliminaciones != Int32.Parse(reduccionValor[1])*2 - 1)
                                            hijos += arbolReal.Peek().Keys.First().ToString() + "?";
                                        else
                                            hijos += arbolReal.Peek().Keys.First().ToString();
                                        arbolReal.Pop();
                                    }
                                    else
                                    {
                                        if (eliminaciones != Int32.Parse(reduccionValor[1])*2 - 1)
                                            hijos += arbolReal.Peek().Keys.First() + arbolReal.Peek().Values.First() + "?";
                                        else
                                            hijos += arbolReal.Peek().Keys.First() + arbolReal.Peek().Values.First();
                                        arbolReal.Pop();
                                    }
                                }
                                pila.Pop();
                            }
                            eliminaciones++;
                        }
                        hijos += "]";
                        nodo.Add(name, hijos);
                        arbolReal.Push(nodo);
                    }
                    //Termina lista de pruebas
                    nombreAux++;
                    string lineaReduccion = obtenerLinea();
                    List<int> arrayValoresReduc = obtenerArray(lineaReduccion);
                    int indexReduc = Int32.Parse(reduccionValor[0]);
                    int salidaReduc = arrayValoresReduc[indexReduc];

                    // Se añade la reducción a la tabla
                    DataGridViewRow row = tabla.Rows[tabla.Rows.Count-2];
                    if (row != null)
                        row.Cells["Reduccion"].Value = reduccionValor[2];

                    // Se añade la reducción a la pila
                    pila.Push(Int32.Parse(reduccionValor[0]));
                    pila.Push(salidaReduc);

                }
                pilaString = "";
                entrada = "";
            }
            return arbolReal;
        }

        // Sección que entra al archivo .lr y encuentra la salida dependiendo del token a analizar
        private string obtenerLinea()
        {
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
            return linea;
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
