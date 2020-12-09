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
            /*
            //Validar sumas, restas, multiplicacion, division, and y or
            Regex suma = new Regex(@"[+]+");
            if (suma.IsMatch(arbol))
            {
                MessageBox.Show("Hay suma");
            }
            Regex resta = new Regex(@"[-]+");
            if (resta.IsMatch(arbol))
            {
                MessageBox.Show("Hay resta");
            }
            Regex multi = new Regex(@"[*]+");
            if (multi.IsMatch(arbol))
            {
                MessageBox.Show("Hay multiplicacion");
            }
            Regex div = new Regex(@"[/]+");
            if (div.IsMatch(arbol))
            {
                MessageBox.Show("Hay division");
            }
            Regex andS = new Regex(@"[&&]+");
            if (andS.IsMatch(arbol))
            {
                MessageBox.Show("Hay and");
            }
            Regex orS = new Regex(@"[||]+");
            if (orS.IsMatch(arbol))
            {
                MessageBox.Show("Hay or");
            }*/
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
