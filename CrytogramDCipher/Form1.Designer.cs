namespace CrytogramDCipher
{
    partial class MainWin
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
			this.textBoxIn = new System.Windows.Forms.TextBox();
			this.textBoxOut = new System.Windows.Forms.TextBox();
			this.textBoxAlfP = new System.Windows.Forms.TextBox();
			this.textBoxAlfC = new System.Windows.Forms.TextBox();
			this.textBoxCodNum = new System.Windows.Forms.TextBox();
			this.labelAlfabeto = new System.Windows.Forms.Label();
			this.labelAlfCifrado = new System.Windows.Forms.Label();
			this.labelCodigoNum = new System.Windows.Forms.Label();
			this.buttonPistaAdd = new System.Windows.Forms.Button();
			this.comboBoxPista = new System.Windows.Forms.ComboBox();
			this.buttonPistaDelete = new System.Windows.Forms.Button();
			this.labelPista = new System.Windows.Forms.Label();
			this.buttonCifrado = new System.Windows.Forms.Button();
			this.buttonDecifrado = new System.Windows.Forms.Button();
			this.buttonCriptoAnal = new System.Windows.Forms.Button();
			this.checkBoxBrute = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// textBoxIn
			// 
			this.textBoxIn.Location = new System.Drawing.Point(12, 12);
			this.textBoxIn.Multiline = true;
			this.textBoxIn.Name = "textBoxIn";
			this.textBoxIn.Size = new System.Drawing.Size(354, 272);
			this.textBoxIn.TabIndex = 0;
			// 
			// textBoxOut
			// 
			this.textBoxOut.Location = new System.Drawing.Point(373, 12);
			this.textBoxOut.Multiline = true;
			this.textBoxOut.Name = "textBoxOut";
			this.textBoxOut.ReadOnly = true;
			this.textBoxOut.Size = new System.Drawing.Size(354, 272);
			this.textBoxOut.TabIndex = 1;
			// 
			// textBoxAlfP
			// 
			this.textBoxAlfP.Location = new System.Drawing.Point(80, 290);
			this.textBoxAlfP.Name = "textBoxAlfP";
			this.textBoxAlfP.ReadOnly = true;
			this.textBoxAlfP.Size = new System.Drawing.Size(286, 20);
			this.textBoxAlfP.TabIndex = 2;
			// 
			// textBoxAlfC
			// 
			this.textBoxAlfC.Location = new System.Drawing.Point(80, 316);
			this.textBoxAlfC.Name = "textBoxAlfC";
			this.textBoxAlfC.Size = new System.Drawing.Size(286, 20);
			this.textBoxAlfC.TabIndex = 3;
			this.textBoxAlfC.TextChanged += new System.EventHandler(this.TextBoxAlfC_TextChanged);
			// 
			// textBoxCodNum
			// 
			this.textBoxCodNum.Location = new System.Drawing.Point(80, 343);
			this.textBoxCodNum.Name = "textBoxCodNum";
			this.textBoxCodNum.Size = new System.Drawing.Size(286, 20);
			this.textBoxCodNum.TabIndex = 6;
			this.textBoxCodNum.TextChanged += new System.EventHandler(this.TextBoxCodNum_TextChanged);
			// 
			// labelAlfabeto
			// 
			this.labelAlfabeto.AutoSize = true;
			this.labelAlfabeto.Location = new System.Drawing.Point(28, 293);
			this.labelAlfabeto.Name = "labelAlfabeto";
			this.labelAlfabeto.Size = new System.Drawing.Size(46, 13);
			this.labelAlfabeto.TabIndex = 7;
			this.labelAlfabeto.Text = "Alfabeto";
			// 
			// labelAlfCifrado
			// 
			this.labelAlfCifrado.AutoSize = true;
			this.labelAlfCifrado.Location = new System.Drawing.Point(16, 319);
			this.labelAlfCifrado.Name = "labelAlfCifrado";
			this.labelAlfCifrado.Size = new System.Drawing.Size(58, 13);
			this.labelAlfCifrado.TabIndex = 8;
			this.labelAlfCifrado.Text = "Alf. Cifrado";
			// 
			// labelCodigoNum
			// 
			this.labelCodigoNum.AutoSize = true;
			this.labelCodigoNum.Location = new System.Drawing.Point(9, 346);
			this.labelCodigoNum.Name = "labelCodigoNum";
			this.labelCodigoNum.Size = new System.Drawing.Size(65, 13);
			this.labelCodigoNum.TabIndex = 9;
			this.labelCodigoNum.Text = "Codigo Num";
			// 
			// buttonPistaAdd
			// 
			this.buttonPistaAdd.Location = new System.Drawing.Point(313, 368);
			this.buttonPistaAdd.Name = "buttonPistaAdd";
			this.buttonPistaAdd.Size = new System.Drawing.Size(27, 21);
			this.buttonPistaAdd.TabIndex = 11;
			this.buttonPistaAdd.Text = ">>";
			this.buttonPistaAdd.UseVisualStyleBackColor = true;
			// 
			// comboBoxPista
			// 
			this.comboBoxPista.FormattingEnabled = true;
			this.comboBoxPista.Location = new System.Drawing.Point(80, 369);
			this.comboBoxPista.Name = "comboBoxPista";
			this.comboBoxPista.Size = new System.Drawing.Size(227, 21);
			this.comboBoxPista.TabIndex = 12;
			// 
			// buttonPistaDelete
			// 
			this.buttonPistaDelete.Location = new System.Drawing.Point(346, 368);
			this.buttonPistaDelete.Name = "buttonPistaDelete";
			this.buttonPistaDelete.Size = new System.Drawing.Size(20, 21);
			this.buttonPistaDelete.TabIndex = 13;
			this.buttonPistaDelete.Text = "X";
			this.buttonPistaDelete.UseVisualStyleBackColor = true;
			// 
			// labelPista
			// 
			this.labelPista.AutoSize = true;
			this.labelPista.Location = new System.Drawing.Point(44, 372);
			this.labelPista.Name = "labelPista";
			this.labelPista.Size = new System.Drawing.Size(30, 13);
			this.labelPista.TabIndex = 14;
			this.labelPista.Text = "Pista";
			// 
			// buttonCifrado
			// 
			this.buttonCifrado.Location = new System.Drawing.Point(128, 396);
			this.buttonCifrado.Name = "buttonCifrado";
			this.buttonCifrado.Size = new System.Drawing.Size(75, 20);
			this.buttonCifrado.TabIndex = 15;
			this.buttonCifrado.Text = "Cifrado";
			this.buttonCifrado.UseVisualStyleBackColor = true;
			this.buttonCifrado.Click += new System.EventHandler(this.ButtonCifrado_Click);
			// 
			// buttonDecifrado
			// 
			this.buttonDecifrado.Location = new System.Drawing.Point(209, 396);
			this.buttonDecifrado.Name = "buttonDecifrado";
			this.buttonDecifrado.Size = new System.Drawing.Size(75, 20);
			this.buttonDecifrado.TabIndex = 16;
			this.buttonDecifrado.Text = "Decifrado";
			this.buttonDecifrado.UseVisualStyleBackColor = true;
			this.buttonDecifrado.Click += new System.EventHandler(this.ButtonDecifrado_Click);
			// 
			// buttonCriptoAnal
			// 
			this.buttonCriptoAnal.Location = new System.Drawing.Point(290, 396);
			this.buttonCriptoAnal.Name = "buttonCriptoAnal";
			this.buttonCriptoAnal.Size = new System.Drawing.Size(76, 20);
			this.buttonCriptoAnal.TabIndex = 17;
			this.buttonCriptoAnal.Text = "Criptoanálisis";
			this.buttonCriptoAnal.UseVisualStyleBackColor = true;
			this.buttonCriptoAnal.Click += new System.EventHandler(this.ButtonCriptoAnal_ClickAsync);
			// 
			// checkBoxBrute
			// 
			this.checkBoxBrute.AutoSize = true;
			this.checkBoxBrute.Location = new System.Drawing.Point(373, 399);
			this.checkBoxBrute.Name = "checkBoxBrute";
			this.checkBoxBrute.Size = new System.Drawing.Size(86, 17);
			this.checkBoxBrute.TabIndex = 18;
			this.checkBoxBrute.Text = "Fuerza Bruta";
			this.checkBoxBrute.UseVisualStyleBackColor = true;
			this.checkBoxBrute.CheckedChanged += new System.EventHandler(this.CheckBoxBrute_CheckedChanged);
			// 
			// MainWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(739, 423);
			this.Controls.Add(this.checkBoxBrute);
			this.Controls.Add(this.buttonCriptoAnal);
			this.Controls.Add(this.buttonDecifrado);
			this.Controls.Add(this.buttonCifrado);
			this.Controls.Add(this.labelPista);
			this.Controls.Add(this.buttonPistaDelete);
			this.Controls.Add(this.comboBoxPista);
			this.Controls.Add(this.buttonPistaAdd);
			this.Controls.Add(this.labelCodigoNum);
			this.Controls.Add(this.labelAlfCifrado);
			this.Controls.Add(this.labelAlfabeto);
			this.Controls.Add(this.textBoxCodNum);
			this.Controls.Add(this.textBoxAlfC);
			this.Controls.Add(this.textBoxAlfP);
			this.Controls.Add(this.textBoxOut);
			this.Controls.Add(this.textBoxIn);
			this.Name = "MainWin";
			this.Text = "CrytogramDCipher";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.TextBox textBoxAlfP;
        private System.Windows.Forms.TextBox textBoxAlfC;
        private System.Windows.Forms.TextBox textBoxCodNum;
        private System.Windows.Forms.Label labelAlfabeto;
        private System.Windows.Forms.Label labelAlfCifrado;
        private System.Windows.Forms.Label labelCodigoNum;
        private System.Windows.Forms.Button buttonPistaAdd;
        private System.Windows.Forms.ComboBox comboBoxPista;
        private System.Windows.Forms.Button buttonPistaDelete;
        private System.Windows.Forms.Label labelPista;
        private System.Windows.Forms.Button buttonCifrado;
        private System.Windows.Forms.Button buttonDecifrado;
        private System.Windows.Forms.Button buttonCriptoAnal;
		private System.Windows.Forms.CheckBox checkBoxBrute;
	}
}

