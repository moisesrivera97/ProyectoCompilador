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

            for(int i = 0; i < textBox.Text.Length; i++)
            {
                if(textBox.Text[i].ToString() == "[")
                {
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 1;
                    textBox.SelectedText = "\n";
                }
            }
            string auxReves = "";
            string auxNormal = "";
            int ignore = 1;
            while (true)
            {
                if(!textBox.Text.Contains("]"))
                    break;

                if(textBox.Text[textBox.Text.Length-ignore].ToString() != "]" && textBox.Text[textBox.Text.Length - ignore].ToString() != "\n")
                {
                    if (textBox.Text[textBox.Text.Length - 1].ToString() == "¡")
                    {
                        auxReves += textBox.Text[textBox.Text.Length - ignore].ToString();
                        char[] a = auxReves.ToCharArray();
                        System.Array.Reverse(a);
                        auxNormal = new string(a);
                        textBox.SelectionStart = textBox.Text.Length - 1;
                        textBox.SelectionLength = 1;
                        textBox.SelectedText = auxNormal;
                        ignore += auxNormal.Length;
                        auxNormal = "";
                        auxReves = "";
                    }
                    else
                    {
                        auxReves += textBox.Text[textBox.Text.Length - ignore].ToString();
                        textBox.SelectionStart = textBox.Text.Length - ignore;
                        textBox.SelectionLength = 1;
                        textBox.SelectedText = "";
                    }
                }
                else
                {
                    if(auxReves == "")
                    {
                        textBox.SelectionStart = textBox.Text.Length - ignore;
                        textBox.SelectionLength = 1;
                        textBox.SelectedText = "";
                    }
                    else
                    {
                        int corchetes = obtenerCorchetes(textBox);
                        int pos = nuevaPosicion(textBox, corchetes);

                        char[] a = auxReves.ToCharArray();
                        System.Array.Reverse(a);
                        auxNormal = new string(a);
                        auxNormal = "¡" + auxNormal;

                        textBox.SelectionStart = pos;
                        textBox.SelectionLength = 0;
                        textBox.SelectedText = auxNormal;
                        auxReves = "";
                        auxNormal = "";
                    }
                }
            }

            for(int i = 0; i < textBox.Text.Length; i++)
            {
                if(textBox.Text[i].ToString() == "?" || textBox.Text[i].ToString() == "¡")
                {
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 1;
                    textBox.SelectedText = "\t";
                }
            }

            return arbolReal;
        }

        private int obtenerCorchetes(RichTextBox textBox)
        {
            int numCorchetes = 0;

            for(int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i].ToString() == "]")
                    numCorchetes++;
            }

            return numCorchetes;
        }
        private int nuevaPosicion(RichTextBox textBox, int corchetes)
        {
            int pos = 0;
            int tope = 0;
            for(int i = textBox.Text.Length - 1; i >= 0; i--)
            {
                if (textBox.Text[i].ToString() == "\n")
                    tope++;
                if(tope == corchetes)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
    }
}
