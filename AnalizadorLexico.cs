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
                            else if (c.ToString() == "(")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.PARENTESIS_AP);
                                estado = 0;
                            }
                            else if(c.ToString() == ")")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.PARENTESIS_CIE);
                                estado = 0;
                            }
                            else if (c.ToString() == "{")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.LLAVE_AP);
                                estado = 0;
                            }
                            else if (c.ToString() == "}")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.LLAVE_CIE);
                                estado = 0;
                            }
                            else if (c.ToString() == ";")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.PUNTOYCOMA);
                                estado = 0;
                            }
                            else if(c.ToString() == ",")
                            {
                                auxLex += c;
                                addToken(Token.Tipo.COMA);
                                estado = 0;
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
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                if(auxLex == "if")
                                    addToken(Token.Tipo.IF);
                                else if(auxLex == "while")
                                    addToken(Token.Tipo.WHILE);
                                else if (auxLex == "return")
                                    addToken(Token.Tipo.RETURN);
                                else if (auxLex == "else")
                                    addToken(Token.Tipo.ELSE);
                                else if (auxLex == "int" || auxLex == "float" || auxLex == "void")
                                    addToken(Token.Tipo.TIPO);
                                else
                                    addToken(Token.Tipo.IDENTIFICADOR);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                if (auxLex == "if")
                                    addToken(Token.Tipo.IF);
                                else if (auxLex == "while")
                                    addToken(Token.Tipo.WHILE);
                                else if (auxLex == "return")
                                    addToken(Token.Tipo.RETURN);
                                else if (auxLex == "else")
                                    addToken(Token.Tipo.ELSE);
                                else if (auxLex == "int" || auxLex == "float" || auxLex == "void")
                                    addToken(Token.Tipo.TIPO);
                                else
                                    addToken(Token.Tipo.IDENTIFICADOR);

                                estado = 0;
                            }
                            else if(char.IsLetter(c) || char.IsDigit(c))
                            {
                                auxLex += c;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce el identificador o palabra reservada");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.ENTERO);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.ENTERO);
                                estado = 0;
                            }
                            else if (char.IsDigit(c))
                            {
                                auxLex += c; 
                            }
                            else if (c.ToString() == ".")
                            {
                                auxLex += c;
                                estado = 10;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce número");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso para los operadores  "+" y "-"
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
                    //Caso para los operadores  "*" y "/"
                    case 4:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_MUL);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_MUL);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo de multiplicación");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso para determinar si es símbolo "=" o "=="
                    case 5:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_ASIG);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_ASIG);
                                estado = 0;
                            }
                            else if (c.ToString() == "=")
                            {
                                auxLex += c;
                                estado = 17;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo de asignación");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso de valida los símbolos "<" ">" "<=" ">="
                    case 6:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_REL);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_REL);
                                estado = 0;
                            }
                            else if (c.ToString() == "=")
                            {
                                auxLex += c;
                                estado = 14;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo relacional");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que valida el operador "&&"
                    case 7:
                        {
                            if(c.ToString() == "&")
                            {
                                auxLex += c;
                                estado = 15;
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo AND");
                                auxLex = "";
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo AND");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que analiza el operador "||"
                    case 8:
                        {
                            if (c.ToString() == "|")
                            {
                                auxLex += c;
                                estado = 16;
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo OR");
                                auxLex = "";
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo OR");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que analiza el símbolo "!" y determina si es "!" o "!="
                    case 9:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_NOT);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_NOT);
                                estado = 0;
                            }
                            else if (c.ToString() == "=")
                            {
                                auxLex += c;
                                estado = 17;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo relacional");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que valida los números reales
                    case 10:
                        {
                            if (char.IsDigit(c))
                            {
                                auxLex += c;
                                estado = 11;
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                MessageBox.Show("Error léxico, no se reconoce número real");
                                auxLex = "";
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce número real");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que valida números reales #2
                    case 11:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.REAL);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsDigit(c))
                            {
                                auxLex += c;
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.REAL);
                                estado = 0;
                            }
                            break;
                        }
                    case 12:
                        {
                            break;
                        }
                    //Caso que hace que en caso que se detecte un error léxico se salto todos los
                    //caracteres erroneos hasta el siguiente lexema a analizar
                    case 13:
                        {
                            if (char.IsWhiteSpace(c))
                            {
                                estado = 0;
                            }
                            break;
                        }
                    // Caso que valide que los operadores "==" "!=" "<=" ">=" "&&" sean correctos
                    case 14:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_REL);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_REL);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo relacional");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que valida que el símbolo && sea correcto
                    case 15:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_AND);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_AND);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo AND");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                    //Caso que valida que el símbolo || sea correcto
                    case 16:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_OR);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_OR);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo OR");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                        // Caso que valida los símbolos == y !=
                    case 17:
                        {
                            if (c.ToString() == "#" && i == entrada.Length - 1)
                            {
                                addToken(Token.Tipo.OPERADOR_IGUALDAD);
                                MessageBox.Show("Análisis léxico terminado");
                            }
                            else if (char.IsWhiteSpace(c))
                            {
                                addToken(Token.Tipo.OPERADOR_IGUALDAD);
                                estado = 0;
                            }
                            else
                            {
                                MessageBox.Show("Error léxico, no se reconoce símbolo relacional");
                                auxLex = "";
                                estado = 13;
                            }
                            break;
                        }
                }
            }

            salida.Add(new Token(Token.Tipo.FIN_PILA, "$", (int)Token.Tipo.FIN_PILA));
            return salida;
        }
        private void addToken(Token.Tipo tipo)
        {
            salida.Add(new Token(tipo, auxLex, (int)tipo));
            auxLex = "";
        }
    }
}
