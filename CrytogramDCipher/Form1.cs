using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;

namespace CrytogramDCipher
{
    public partial class MainWin : Form
    {
		private Criptograma Diccionario;

        public MainWin()
        {
			this.Diccionario = new Criptograma();
            InitializeComponent();

			this.textBoxAlfP.Text = this.Diccionario.AlfP;
			this.textBoxAlfC.Text = this.Diccionario.AlfC;

			this.textBoxCodNum.Text = this.Diccionario.AlfCode.ToString();
		}

		private void TextBoxAlfC_TextChanged(Object sender, EventArgs e)
		{
			this.textBoxCodNum.TextChanged -= new System.EventHandler(this.TextBoxCodNum_TextChanged);
			this.textBoxAlfC.TextChanged -= new System.EventHandler(this.TextBoxAlfC_TextChanged);

			this.Diccionario.AlfC = this.textBoxAlfC.Text;
			Int32 stick = this.textBoxAlfC.SelectionStart;
			// !!! AlfC no es el mismo al que se le untroduce
			this.textBoxAlfC.Text = this.Diccionario.AlfC;
			this.textBoxAlfC.SelectionStart = stick;

			this.textBoxCodNum.Text = this.Diccionario.AlfCode.ToString();

			this.textBoxAlfC.TextChanged += new System.EventHandler(this.TextBoxAlfC_TextChanged);
			this.textBoxCodNum.TextChanged += new System.EventHandler(this.TextBoxCodNum_TextChanged);
		}

		private void TextBoxCodNum_TextChanged(Object sender, EventArgs e)
		{
			this.textBoxCodNum.TextChanged -= new System.EventHandler(this.TextBoxCodNum_TextChanged);
			this.textBoxAlfC.TextChanged -= new System.EventHandler(this.TextBoxAlfC_TextChanged);

			if (BigInteger.TryParse(this.textBoxCodNum.Text, out BigInteger result)) {
				this.Diccionario.AlfCode = result;

				this.textBoxAlfC.Text = "";
				this.textBoxAlfC.Text = this.Diccionario.AlfC;
			} else {
				if (this.textBoxCodNum.Text == "") {
					this.Diccionario.AlfCode = 0;
				}
				this.textBoxAlfC.Text = this.Diccionario.AlfC;
			}

			this.textBoxAlfC.TextChanged += new System.EventHandler(this.TextBoxAlfC_TextChanged);
			this.textBoxCodNum.TextChanged += new System.EventHandler(this.TextBoxCodNum_TextChanged);
		}

		private void ButtonCifrado_Click(Object sender, EventArgs e)
		{
			this.textBoxOut.Text = this.Diccionario.Cifrar(this.textBoxIn.Text);
		}

		private void ButtonDecifrado_Click(Object sender, EventArgs e)
		{
			this.textBoxOut.Text = this.Diccionario.Decifrar(this.textBoxIn.Text);
		}
	}
}
