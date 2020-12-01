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
        public void desplegar(Dictionary<string, List<string>> arbol, RichTextBox textBox)
        {
            while(arbol.Count > 0)
            {
                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;
                textBox.AppendText(arbol.Keys.First() + "\n");

                arbol.Remove(arbol.Keys.First());
            }
            /*
            foreach(KeyValuePair<string, List<string>> n in arbol)
            {
                string hijos = null;
                foreach(string s in n.Value)
                {
                    hijos += s + ", ";
                }

                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;
                textBox.AppendText(n.Key + ". hijos: " + hijos + "\n");
            }*/
        }
    }
}
