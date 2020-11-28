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
            CADENA,
            TIPO,
            OPERADOR_ADD,
            OPERADOR_MUL,
            OPERADOR_REL,
            OPERADOR_OR,
            OPERADOR_AND,
            OPERADOR_NOT,
            OPERADOR_IGUALDAD,
            PUNTOYCOMA,
            COMA,
            PARENTESIS_AP,
            PARENTESIS_CIE,
            LLAVE_AP,
            LLAVE_CIE,
            OPERADOR_ASIG,
            IF,
            WHILE,
            RETURN,
            ELSE,
            PESOS,
            programa,
            Definiciones,
            Definicion,
            DefVar,
            ListaVar,
            DefFunc,
            Parametros,
            ListaParam,
            BloqFunc,
            DefLocales,
            DefLocal,
            Sentencias,
            Sentencia,
            Otro,
            Bloque,
            ValorRegresa,
            Argumentos,
            ListaArgumentos,
            Termino,
            LlamadaFunc,
            SentenciaBloque,
            Expresion
        }

        private Tipo tipoToken;
        private string valor;
        private int valorEntero;

        public Token(Tipo tipo, string auxLex, int valorE)
        {
            this.tipoToken = tipo;
            this.valor = auxLex;
            this.valorEntero = valorE;
        }

        public Tipo getTipo()
        {
            return tipoToken;
        }
        public string getValor()
        {
            return valor;
        }
        public int getValorEntero()
        {
            return valorEntero;
        }
    }
}
