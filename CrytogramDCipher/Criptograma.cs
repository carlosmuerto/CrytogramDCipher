using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Windows.Forms;

namespace CrytogramDCipher
{
	class Criptograma
	{
        

		private Dictionary<Char, Char> _IndexAlfE;
		private Dictionary<Char, Char> _IndexAlfD;

		private Dictionary<Char, Char> _AlfTryTed;
		private SortedSet<String> _SortedTxt;

		private Dictionary<Char, Char> _IndexAlfA;

		private String[] _Palabras;
		private Dictionary<Int32, Int32> _HzIndex;

		private Dictionary<Char, Char> IndexAlfE { get => this._IndexAlfE; set => this._IndexAlfE = value; }
		private Dictionary<Char, Char> IndexAlfD { get => this._IndexAlfD; set => this._IndexAlfD = value; }

		private String _AlfP;
		private String _AlfC;

		public String[] Palabras { get => this._Palabras; set => this._Palabras = value; }

		private Boolean _Brute;

		public BigInteger AlfCode
		{
			get
			{
				BigInteger Code = 0; // codigo a retornar
				BigInteger Peso = 1; // valor de la posicion

				ArrayList Alf = new ArrayList();
				ArrayList Cfr = new ArrayList();
				foreach (KeyValuePair<Char, Char> Par in this.IndexAlfE)
				{
					Alf.Add(Par.Key);
					Cfr.Add(Par.Value);
				}

				foreach (KeyValuePair<Char, Char> Par in this.IndexAlfE)
				{
					Int32 CharIndex = Alf.IndexOf(Cfr[0]);
					Cfr.RemoveAt(0);

					Code = BigInteger.Add(Peso * CharIndex, Code);
					Peso *= Alf.Count;
					Alf.RemoveAt(CharIndex);
				}


				return Code;
			}

			set
			{
				// copiar Alfabeto plano en una Arreglo dinamico
				ArrayList Alf = new ArrayList();
				Dictionary<Char, Char> TempIndexAlfP = new Dictionary<Char, Char>();
				String TempAlfC = "";
				foreach (KeyValuePair<Char, Char> par in this.IndexAlfE)
				{
					Alf.Add(par.Key);
				}

				Int32 Index;

				// divisiones consecutivas con devisores redicido
				BigInteger Dvdo = value; // Dvdo: Dividendo
				foreach (KeyValuePair<Char, Char> Par in this.IndexAlfE){
					Dvdo = BigInteger.DivRem(Dvdo, Alf.Count, out BigInteger Rst);
					Index = Int32.Parse(Rst.ToString());

					//Crear Nuevo Alfabetos
					TempIndexAlfP.Add(Par.Key, (Char)Alf[Index]);

					Alf.RemoveAt(Index);
				}

				// Actualiza La relacion entre los Alfabetos
				foreach (KeyValuePair<Char, Char> par in TempIndexAlfP){
					TempAlfC += par.Value; 
					this.IndexAlfE[par.Key] = par.Value;
					this.IndexAlfD[par.Value] = par.Key;
				}

				//Define el nuevo AlfC que corresponde a los IndexAlf
				this.AlfC = TempAlfC;
			}
		}

		public Dictionary<Int32, Int32> HzIndex { get => this._HzIndex; set => this._HzIndex = value; }

		public String AlfP { get => this._AlfP; private set => this._AlfP = value; }

		public String AlfC {
			get => this._AlfC;
			set {
				this._AlfC = "";
				String Temp = value.ToUpper() + this.AlfP; // Concatena
				foreach (Char ch in Temp){ // Elije la primera concurrecina del las letras 
				
					if (Char.IsLetter(ch) &&  !this._AlfC.Contains(ch))
					{
						this._AlfC += ch;
					}
				}

				// Actualiza La relacion entre los Alfabetos
				

				for (Int32 i = 0; i< this._AlfP.Length; ++i) {
					this.IndexAlfE[this._AlfP[i]] = this._AlfC[i];
					this.IndexAlfD[this._AlfC[i]] = this._AlfP[i];
				}
			}
		}

		public Boolean Brute { get => this._Brute; set => this._Brute = value; }
		public Dictionary<Char, Char> IndexAlfA { get => this._IndexAlfA; set => this._IndexAlfA = value; }
		public Dictionary<Char, Char> AlfTryTed { get => this._AlfTryTed; set => this._AlfTryTed = value; }
		public SortedSet<String> SortedTxt { get => this._SortedTxt; set => this._SortedTxt = value; }

		public String Cifrar(String TextoPlano)
		{
			String TextoCrifrado = "";
			for (Int32 i = 0; i < TextoPlano.Length; ++i)
			{
				if (this.IndexAlfE.TryGetValue(Char.ToUpper(TextoPlano[i]), out Char temp)) {
					TextoCrifrado += temp;
				} else {
					TextoCrifrado += TextoPlano[i];
				}
			}
			return TextoCrifrado;
		}

		public String Decifrar(String TextoCrifrado)
		{
			String TextoPlano = "";
			for (Int32 i = 0; i < TextoCrifrado.Length; ++i)
			{
				if (this.IndexAlfD.TryGetValue(Char.ToUpper(TextoCrifrado[i]), out Char temp)) {
					TextoPlano += temp;
				} else {
					TextoPlano += TextoCrifrado[i];
				}
			}
			return TextoPlano;

		}

		public Criptograma()
		{

			this.IndexAlfE = new Dictionary<Char, Char>() {
				{'A','A'},{'B','B'},{'C','C'},{'D','D'},{'E','E'},{'F','F'},
				{'G','G'},{'H','H'},{'I','I'},{'J','J'},{'K','K'},{'L','L'},
				{'M','M'},{'N','N'},{'O','O'},{'P','P'},{'Q','Q'},{'R','R'},
				{'S','S'},{'T','T'},{'U','U'},{'V','V'},{'W','W'},{'X','X'},
				{'Y','Y'},{'Z','Z'}
			};
			this.IndexAlfD = new Dictionary<Char, Char>();

			this.AlfP = "";

			this.AlfTryTed = new Dictionary<Char, Char>();
			this.SortedTxt = new SortedSet<String>();

			this.Brute = true;

			foreach (KeyValuePair<Char, Char> Par in this.IndexAlfE) {
				this.AlfP += Par.Key;
			}
			this.AlfC = this.AlfP;

			String[] hzWords = Properties.Resources.w20k.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

			for (Int32 i =0;i<hzWords.Length;++i) {
				hzWords[i] = hzWords[i].ToUpper();
			}

			this.Palabras = (String[])hzWords.Clone();
			Array.Sort(this.Palabras);

			this.HzIndex = new Dictionary<Int32, Int32>();

			for (Int32 i = 0; i < hzWords.Length; ++i) {
				this.HzIndex.Add(i, Array.BinarySearch(this.Palabras, hzWords[i]));
			}
		}


		private Boolean TyInSortedTxt()
		{
			while (false) {

			}
			if (true) {
				return true;
			} else {
				// return false;
			}
		}

		public String Analist( String TxtIn)
		//public Task<String> Analist(String TxtIn)
		{
			// 	tryInSordTxt (iST){
			// 		iDc = 0;
			// 		While(tr = BuscarPalabra(iST,iDc)){
			// 			si(Confirmar(tr)){
			// 				UpAlfTryed(iST,tr);
			// 				tryInSordTxt(++iTP);
			// 			} else {
			// 				iDc++;
			// 			}
			// 		}
			// 		si ( iST>=SordTxt.lenght ){
			// 			return true;
			// 		} else {
			// 			Descartar(Alf);
			// 			return false;
			// 		}
			// 	}		
			//return Task.Run(() => {
				if (this.Brute) {
					return BruteStr(TxtIn);
				} else {
					return TxtIn;
				}
			//});
		}

			

		private String BruteStr(String TxtIn)
		{
			this.AlfCode = 0;
			
			String TxtOut = "";
			for (Int32 i = 0; i < TxtIn.Length; ++i) {
				if (this.IndexAlfE.TryGetValue(Char.ToUpper(TxtIn[i]), out Char temp)) {
					TxtOut += temp;
				} else {
					TxtOut += " ";
				}
			}

			String[] TxtOutSplited = TxtOut.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

			for (Int32 i = 0; i < TxtOutSplited.Length; ++i) {
				this.SortedTxt.Add(TxtOutSplited[i]);
			}

			BigInteger Code;
			for (Code = 0; Code < BigInteger.Parse("403291461126605635584000000") ; Code = BigInteger.Add(Code,BigInteger.One)) {
				this.AlfCode = Code;
				Int32 Count = 0;
				for (Int32 pl = 0, c = this.SortedTxt.Count; pl < c; ++pl) {
					if (this.Palabras.Contains(this.Decifrar(this.SortedTxt.ElementAt(pl))) ) {
						Count++;
					}
				}
				if (Count == this.SortedTxt.Count) {
					break;
				}
			}
			TxtOut = this.Decifrar(TxtIn);

			return TxtOut;
		}
		

	}
}


