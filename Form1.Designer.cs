namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewTokens = new System.Windows.Forms.DataGridView();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAnalizar = new System.Windows.Forms.Button();
            this.textBoxEntrada = new System.Windows.Forms.TextBox();
            this.LabelEntrada = new System.Windows.Forms.Label();
            this.labelTabla = new System.Windows.Forms.Label();
            this.dataGridViewSintactico = new System.Windows.Forms.DataGridView();
            this.Pila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSintactico = new System.Windows.Forms.Label();
            this.richTextBoxArbol = new System.Windows.Forms.RichTextBox();
            this.labelArbol = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSintactico)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Valor,
            this.Tipo});
            this.dataGridViewTokens.Location = new System.Drawing.Point(425, 152);
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            this.dataGridViewTokens.RowHeadersVisible = false;
            this.dataGridViewTokens.Size = new System.Drawing.Size(303, 215);
            this.dataGridViewTokens.TabIndex = 0;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // buttonAnalizar
            // 
            this.buttonAnalizar.Font = new System.Drawing.Font("Chiller", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnalizar.Location = new System.Drawing.Point(452, 46);
            this.buttonAnalizar.Name = "buttonAnalizar";
            this.buttonAnalizar.Size = new System.Drawing.Size(232, 40);
            this.buttonAnalizar.TabIndex = 1;
            this.buttonAnalizar.Text = "ANALIZAR";
            this.buttonAnalizar.UseVisualStyleBackColor = true;
            this.buttonAnalizar.Click += new System.EventHandler(this.ButtonAnalizar_Click);
            // 
            // textBoxEntrada
            // 
            this.textBoxEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEntrada.Location = new System.Drawing.Point(12, 46);
            this.textBoxEntrada.Multiline = true;
            this.textBoxEntrada.Name = "textBoxEntrada";
            this.textBoxEntrada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEntrada.Size = new System.Drawing.Size(407, 294);
            this.textBoxEntrada.TabIndex = 2;
            // 
            // LabelEntrada
            // 
            this.LabelEntrada.AutoSize = true;
            this.LabelEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEntrada.Location = new System.Drawing.Point(182, 9);
            this.LabelEntrada.Name = "LabelEntrada";
            this.LabelEntrada.Size = new System.Drawing.Size(88, 26);
            this.LabelEntrada.TabIndex = 3;
            this.LabelEntrada.Text = "Entrada";
            // 
            // labelTabla
            // 
            this.labelTabla.AutoSize = true;
            this.labelTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTabla.Location = new System.Drawing.Point(470, 123);
            this.labelTabla.Name = "labelTabla";
            this.labelTabla.Size = new System.Drawing.Size(188, 26);
            this.labelTabla.TabIndex = 4;
            this.labelTabla.Text = "Tabla de símbolos";
            // 
            // dataGridViewSintactico
            // 
            this.dataGridViewSintactico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSintactico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pila,
            this.Entrada,
            this.Salida,
            this.Reduccion});
            this.dataGridViewSintactico.Location = new System.Drawing.Point(737, 37);
            this.dataGridViewSintactico.Name = "dataGridViewSintactico";
            this.dataGridViewSintactico.RowHeadersVisible = false;
            this.dataGridViewSintactico.Size = new System.Drawing.Size(403, 330);
            this.dataGridViewSintactico.TabIndex = 5;
            // 
            // Pila
            // 
            this.Pila.HeaderText = "Pila";
            this.Pila.Name = "Pila";
            // 
            // Entrada
            // 
            this.Entrada.HeaderText = "Entrada";
            this.Entrada.Name = "Entrada";
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            // 
            // Reduccion
            // 
            this.Reduccion.HeaderText = "Reducción";
            this.Reduccion.Name = "Reduccion";
            // 
            // labelSintactico
            // 
            this.labelSintactico.AutoSize = true;
            this.labelSintactico.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSintactico.Location = new System.Drawing.Point(855, 9);
            this.labelSintactico.Name = "labelSintactico";
            this.labelSintactico.Size = new System.Drawing.Size(185, 26);
            this.labelSintactico.TabIndex = 6;
            this.labelSintactico.Text = "Análisis sintáctico";
            // 
            // richTextBoxArbol
            // 
            this.richTextBoxArbol.Location = new System.Drawing.Point(12, 373);
            this.richTextBoxArbol.Name = "richTextBoxArbol";
            this.richTextBoxArbol.Size = new System.Drawing.Size(716, 276);
            this.richTextBoxArbol.TabIndex = 7;
            this.richTextBoxArbol.Text = "";
            // 
            // labelArbol
            // 
            this.labelArbol.AutoSize = true;
            this.labelArbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArbol.Location = new System.Drawing.Point(135, 343);
            this.labelArbol.Name = "labelArbol";
            this.labelArbol.Size = new System.Drawing.Size(160, 26);
            this.labelArbol.TabIndex = 8;
            this.labelArbol.Text = "Árbol sintáctico";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 661);
            this.Controls.Add(this.labelArbol);
            this.Controls.Add(this.richTextBoxArbol);
            this.Controls.Add(this.labelSintactico);
            this.Controls.Add(this.dataGridViewSintactico);
            this.Controls.Add(this.labelTabla);
            this.Controls.Add(this.LabelEntrada);
            this.Controls.Add(this.textBoxEntrada);
            this.Controls.Add(this.buttonAnalizar);
            this.Controls.Add(this.dataGridViewTokens);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSintactico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Button buttonAnalizar;
        private System.Windows.Forms.TextBox textBoxEntrada;
        private System.Windows.Forms.Label LabelEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.Label labelTabla;
        private System.Windows.Forms.DataGridView dataGridViewSintactico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reduccion;
        private System.Windows.Forms.Label labelSintactico;
        private System.Windows.Forms.RichTextBox richTextBoxArbol;
        private System.Windows.Forms.Label labelArbol;
    }
}

