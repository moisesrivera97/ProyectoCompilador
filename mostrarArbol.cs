using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    class mostrarArbol
    {
        public string desplegar(Stack<Dictionary<string, string>> arbol, RichTextBox textBox)
        {
            string arbolCadena = null;
            foreach(KeyValuePair<string,string> v in arbol.Peek())
            {
                arbolCadena = v.Key + v.Value;
            }

            string arbolReal = null;
            bool bandera = true;
            for(int i = 0; i < arbolCadena.Length; i++)
            {
                if (bandera == true)
                {
                    if(arbolCadena[i].ToString() != "_")
                        arbolReal += arbolCadena[i].ToString();
                    else
                        bandera = false;
                }
                else
                {
                    if (!char.IsDigit(arbolCadena[i]))
                    {
                        bandera = true;
                        arbolReal += arbolCadena[i].ToString();
                    }
                }
            }

            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.AppendText(arbolReal);

            return arbolReal;
        }
    }
}
