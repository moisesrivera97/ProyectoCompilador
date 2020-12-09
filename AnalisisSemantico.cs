using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Compilador
{
    class AnalisisSemantico
    {
        public void analizar(string arbol, List<Token> tablaSimbolos) {
            declaracionesPrevias(arbol, tablaSimbolos);
            asignacionDeValor(arbol, tablaSimbolos);
            tiposDeDatos(arbol, tablaSimbolos);
            existeFuncion(arbol, tablaSimbolos);
        }

        private void declaracionesPrevias(string arbol, List<Token> tablaSimbolos)
        {
            Regex variables = new Regex(@"[int|float][a-zA-Z0-9]+;+");
            if (variables.IsMatch(arbol))
            {
                MessageBox.Show("Hay variables");
            }
        }

        private void asignacionDeValor(string arbol, List<Token> tablaSimbolos)
        {

        }

        private void tiposDeDatos(string arbol, List<Token> tablaSimbolos)
        {

        }

        private void existeFuncion(string arbol, List<Token> tablaSimbolos)
        {

        }

        private void paramCorrectos(string arbol, List<Token> tablaSimbolos)
        {

        }

        private void existeReturn(string arbol, List<Token> tablaSimbolos)
        {

        }
    }
}
