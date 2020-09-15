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
            this.buttonAnalizar = new System.Windows.Forms.Button();
            this.textBoxEntrada = new System.Windows.Forms.TextBox();
            this.LabelEntrada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Valor});
            this.dataGridViewTokens.Location = new System.Drawing.Point(12, 120);
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            this.dataGridViewTokens.RowHeadersVisible = false;
            this.dataGridViewTokens.Size = new System.Drawing.Size(505, 215);
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
            // buttonAnalizar
            // 
            this.buttonAnalizar.Font = new System.Drawing.Font("Chiller", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnalizar.Location = new System.Drawing.Point(556, 120);
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
            this.textBoxEntrada.Name = "textBoxEntrada";
            this.textBoxEntrada.Size = new System.Drawing.Size(776, 38);
            this.textBoxEntrada.TabIndex = 2;
            // 
            // LabelEntrada
            // 
            this.LabelEntrada.AutoSize = true;
            this.LabelEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEntrada.Location = new System.Drawing.Point(382, 13);
            this.LabelEntrada.Name = "LabelEntrada";
            this.LabelEntrada.Size = new System.Drawing.Size(88, 26);
            this.LabelEntrada.TabIndex = 3;
            this.LabelEntrada.Text = "Entrada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 349);
            this.Controls.Add(this.LabelEntrada);
            this.Controls.Add(this.textBoxEntrada);
            this.Controls.Add(this.buttonAnalizar);
            this.Controls.Add(this.dataGridViewTokens);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
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
    }
}

