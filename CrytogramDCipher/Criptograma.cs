using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CrytogramDCipher
{
	class Criptograma
	{
        
		private Dictionary<Char, Char> _alfP;
		private Dictionary<Char, Char> _alfC;

		private String[] _Palabras;
		private Dictionary<Int32, Int32> _hzIndex;

		private Dictionary<Char, Char> AlfP { get => _alfP; set => _alfP = value; }
		private Dictionary<Char, Char> AlfC { get => _alfC; set => _alfC = value; }

		public String[] Palabras { get => _Palabras; set => _Palabras = value; }

		public BigInteger AlfCode
		{
			get
			{
				BigInteger Code = 0; // codigo a retornar
				BigInteger Peso = 1; // valor de la posicion

				ArrayList Alf = new ArrayList();
				ArrayList Cfr = new ArrayList();
				foreach (KeyValuePair<Char, Char> Par in this.AlfP)
				{
					Alf.Add(Par.Key);
					Cfr.Add(Par.Value);
				}

				foreach (KeyValuePair<Char, Char> Par in this.AlfP)
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
				Dictionary<Char, Char> AlfTemp = new Dictionary<Char, Char>();
				foreach (KeyValuePair<Char, Char> par in AlfP)
				{
					Alf.Add(par.Key);
				}

				Int32 Index;

				// divisiones consecutivas con devisores redicido
				BigInteger Dvdo = value; // Dvdo: Dividendo
				foreach (KeyValuePair<Char, Char> Par in this.AlfP)
				{
					Dvdo = BigInteger.DivRem(Dvdo, Alf.Count, out BigInteger Rst);
					Index = Int32.Parse(Rst.ToString());

					//Crear Nuevo Alfabetos
					AlfTemp.Add(Par.Key, (Char)Alf[Index]);

					Alf.RemoveAt(Index);
				}

				foreach (KeyValuePair<Char, Char> par in AlfTemp)
				{
					this.AlfP[par.Key] = par.Value;
					this.AlfC[par.Value] = par.Key;
				}
			}
		}

		public Criptograma()
        {

			this.AlfP = new Dictionary<Char, Char>() {
				{'A','A'},{'B','B'},{'C','C'},{'D','D'},{'E','E'},{'F','F'},
				{'G','G'},{'H','H'},{'I','I'},{'J','J'},{'K','K'},{'L','L'},
				{'M','M'},{'N','N'},{'O','O'},{'P','P'},{'Q','Q'},{'R','R'},
				{'S','S'},{'T','T'},{'U','U'},{'V','V'},{'W','W'},{'X','X'},
				{'Y','Y'},{'Z','Z'}
			};

			foreach (KeyValuePair<Char, Char> Par in this.AlfP)
			{
				this.AlfC.Add(Par.Value,Par.Key);
			}

			String[] hzWords = System.IO.File.ReadAllLines(@"105words.txt");

			this.Palabras = (String[]) hzWords.Clone();
			Array.Sort(this.Palabras);

			this._hzIndex = new Dictionary<Int32, Int32>();
			Int32 i = 0;
			foreach (String line in hzWords)
			{
				this._hzIndex.Add(i++, Array.BinarySearch(this.Palabras,line));
			}

		}
    }
}


