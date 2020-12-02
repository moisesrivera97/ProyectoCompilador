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
        public void desplegar(Stack<Dictionary<string, string>> arbol, RichTextBox textBox)
        {
            string arbolCadena = null;
            foreach(KeyValuePair<string,string> v in arbol.Peek())
            {
                arbolCadena = v.Key + v.Value;
            }
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.AppendText(arbolCadena);

        }
    }
}
