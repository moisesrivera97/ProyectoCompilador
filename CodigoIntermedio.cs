using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Compilador
{
    class CodigoIntermedio
    {
        public void generarCodigo(string arbol, RichTextBox textBox, List<Token> simbolos)
        {
            int contT = 0;
            int contW = 0;
            string aux = null;
            for(int i = 0; i<simbolos.Count;i++)
            {
                if(simbolos[i].getTipo() == Token.Tipo.PUNTOYCOMA)
                {
                    Regex identificador = new Regex(@"[int|float][a-zA-Z0-9]+");
                    if (identificador.IsMatch(aux))
                    {
                        textBox.SelectionStart = textBox.TextLength;
                        textBox.SelectionLength = 0;
                        int pos = aux.IndexOf(" ");
                        string nombre = aux.Substring(pos+1);
                        string valor = aux.Substring(0, pos);
                        textBox.AppendText(nombre + " = " + valor + "\n");
                        aux = "";
                    }
                }
                else if(simbolos[i].getTipo() == Token.Tipo.LLAVE_AP)
                {

                }
                else if(simbolos[i].getTipo() == Token.Tipo.IF)
                {

                }
                else if (simbolos[i].getTipo() == Token.Tipo.WHILE)
                {

                }
                else
                {
                    aux += simbolos[i].getValor() + " ";
                }
            }
        }
    }
}
