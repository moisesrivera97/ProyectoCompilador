using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxEntrada.Text = "";
            dataGridViewTokens.Rows.Clear();
        }

        private void ButtonAnalizar_Click(object sender, EventArgs e)
        {
            dataGridViewTokens.Rows.Clear();

            AnalizadorLexico anaLex = new AnalizadorLexico();
            List<Token> listaTokens = anaLex.escanear(textBoxEntrada.Text);

            foreach (Token t in listaTokens)
            {
                dataGridViewTokens.Rows.Add(t.getTipo().ToString(), t.getValor().ToString());
            }
        }
    }
}
