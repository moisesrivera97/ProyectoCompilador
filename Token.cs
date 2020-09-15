using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Token
    {
        public enum Tipo
        {
            IDENTIFICADOR,
            ENTERO,
            REAL,
            OPERADOR_ADD,
            OPERADOR_MUL,
            OPERADOR_ASIG,
            OPERADOR_REL,
            OPERADOR_AND,
            OPERADOR_OR,
            OPERADOR_NOT,
            PARENTESIS,
            LLAVE,
            PUNTOYCOMA,
            TIPO,
            IF,
            WHILE,
            RETURN,
            ELSE
        }

        private Tipo tipoToken;
        private string valor;

        public Token(Tipo tipo, string auxLex)
        {
            this.tipoToken = tipo;
            this.valor = auxLex;
        }

        public Tipo getTipo()
        {
            return tipoToken;
        }
        public string getValor()
        {
            return valor;
        }
    }
}
