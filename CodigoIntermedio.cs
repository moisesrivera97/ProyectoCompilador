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
                        if (!aux.Contains(","))
                        {
                            textBox.SelectionStart = textBox.TextLength;
                            textBox.SelectionLength = 0;
                            int pos = aux.IndexOf(" ");
                            string nombre = aux.Substring(pos + 1);
                            string valor = aux.Substring(0, pos);
                            textBox.AppendText(nombre + " = " + valor + "\n");
                            aux = "";
                        }
                        else
                        {
                            int pos = aux.IndexOf(" ");
                            string valor = aux.Substring(0, pos);
                            string nombres = aux.Substring(pos + 1);
                            string nomAux = null;
                            MessageBox.Show(nombres);
                            while (nombres.Length > 0)
                            {
                                if(nombres[0].ToString() != ",")
                                {
                                    nomAux += nombres[0].ToString();
                                    nombres = nombres.Substring(1);
                                }
                                else
                                {
                                    textBox.SelectionStart = textBox.TextLength;
                                    textBox.SelectionLength = 0;
                                    textBox.AppendText(nomAux + " = " + valor + "\n");
                                    nomAux = "";
                                    nombres = nombres.Substring(1);
                                }
                            }
                            textBox.SelectionStart = textBox.TextLength;
                            textBox.SelectionLength = 0;
                            textBox.AppendText(nomAux + " = " + valor + "\n");
                            nomAux = "";
                            aux = "";
                        }
                    }
                }
                else if(simbolos[i].getTipo() == Token.Tipo.LLAVE_AP)
                {
                    aux = "";
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
