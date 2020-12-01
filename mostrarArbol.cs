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
            foreach(KeyValuePair<string,string> v in arbol.Peek())
            {
                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;
                textBox.AppendText(v.Key + "\n hijos: \n" + v.Value);
            }
            
            /*while(arbol.Count > 0)
            {
                string hijos = null;
                foreach(string h in arbol.Values.First())
                {
                    hijos += h + "\t ";
                }
                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;
                textBox.AppendText(arbol.Keys.First() + "\t\t hijos: " + hijos + "\n");

                arbol.Remove(arbol.Keys.First());
            }*/
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
