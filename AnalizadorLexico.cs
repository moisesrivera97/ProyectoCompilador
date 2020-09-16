using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    class AnalizadorLexico
    {
        private List<Token> salida;
        private int estado;
        private string auxLex;

        public List<Token> escanear(string entrada)
        {
            entrada = entrada + "#";
            salida = new List<Token>();
            estado = 0;
            auxLex = "";
            char c;

            for(int i = 0; i <= entrada.Length - 1 ; i++)
            {
                c = entrada[i];

                switch (estado)
                {
                    //Primer caso, para identificar el primer elemento de la cadena
                    case 0:
                        {
                            if (char.IsLetter(c))
                            {
                                estado = 1;
                                auxLex += c;
                            }
                            else if (char.IsDigit(c))
                            {
                                estado = 2;
                                auxLex += c;
                            }
                            else if(c.ToString() == "+" || c.ToString() == "-")
                            {
                                estado = 3;
                                auxLex += c;
                            }
                            else if (c.ToString() == "*" || c.ToString() == "/")
                            {
                                estado = 4;
                                auxLex += c;
                            }
                            else if (c.ToString() == "=")
                            {
                                estado = 5;
                                auxLex += c;
                            }
                            else if (c.ToString() == "<" || c.ToString() == ">")
                            {
                                estado = 6;
                                auxLex += c;
                            }
                            else if (c.ToString() == "&")
                            {
                                estado = 7;
                                auxLex += c;
                            }
                            else if (c.ToString() == "|")
                            {
                                estado = 8;
                                auxLex += c;
                            }
                            else if (c.ToString() == "!")
                            {
                                estado = 9;
                                auxLex += c;
                            }
                            else if (c.ToString() == "(" || c.ToString() == ")")
                            {
                                estado = 10;
                                auxLex += c;
                            }
                            else if (c.ToString() == "{" || c.ToString() == "}")
                            {
                                estado = 11;
                                auxLex += c;
                            }
                            else if (c.ToString() == ";")
                            {
                                estado = 12;
                                auxLex += c;
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                estado = 0;
                            }
                            else if(c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, Símbolo no identificado");
                            }
                            break;
                        }

                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            if(c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_ADD);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_ADD);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo de adición");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    case 8:
                        {
                            break;
                        }
                    case 9:
                        {
                            break;
                        }
                    case 10:
                        {
                            break;
                        }
                    case 11:
                        {
                            break;
                        }
                    case 12:
                        {
                            break;
                        }
                    case 13:
                        {
                            if (char.IsWhiteSpace(c))
                            {
                                estado = 0;
                            }
                            break;
                        }
                }
            }

            return salida;
        }
        private void addToken(Token.Tipo tipo)
        {
            salida.Add(new Token(tipo, auxLex));
            auxLex = "";
        }
    }
}
