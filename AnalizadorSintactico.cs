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
        private string entrada, salida, pilaString, reduccion;
        public void escanear(List<Token> listaTokens, DataGridView tabla)
        {
            while (true)
            {
                foreach (Token t in listaTokens)
                    entrada += t.getValor() + " ";
                if (pila.Count == 0)
                    tabla.Rows.Add("$0", entrada);

                // Sección que entra al archivo .lr y encuentra la salida dependiendo del token a analizar
                StreamReader archivo = File.OpenText("compilador.lr");
                string linea = null;
                int i = 0;
                pila.Push(10);
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
                // Se convierte la línea que se captura a un array de enteros
                linea = linea.Replace("\t", " ");
                List<int> arraylinea = new List<int>();
                for(int j = 0; j < linea.Length; j++)
                {
                    if(linea.Substring(j, 1) == "-")
                    {
                        arraylinea.Add(Int32.Parse(linea.Substring(j + 1, 1))*-1);
                        i++;
                    }
                    else
                    {
                        if(linea.Substring(j+1, 1) != " ")
                            arraylinea.Add(Int32.Parse(linea.Substring(j, 1)+ linea.Substring(j+1, 1)));
                        else
                            arraylinea.Add(Int32.Parse(linea.Substring(j, 1)));
                    }

                }

                int index = listaTokens[0].getValorEntero();
                MessageBox.Show(arraylinea[index].ToString());
            }
        }
    }
}
