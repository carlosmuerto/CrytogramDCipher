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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;

namespace CrytogramDCipher
{
	public static class Utiles // Copiado de https://geeks.ms/jvelasco/2011/01/23/c-implementar-la-interface-icloneable/
	{
		/// <summary>
		/// Permite una clonación en profundidad de origen
		/// </summary>
		/// <param name="origen">Objeto serializable</param>
		/// <exception cref="ArgumentExcepcion">
		/// Se produce cuando el objeto no es serializable.
		/// </exception>
		/// <remarks>Extraido de 
		/// http://es.debugmodeon.com/articulo/clonar-objetos-de-estructura-compleja
		/// </remarks>
		public static T Copia<T>(T origen)
		{
			// Verificamos que sea serializable antes de hacer la copia            
			if (!typeof(T).IsSerializable)
				throw new ArgumentException("La clase " + typeof(T).ToString() + " no es serializable");

			// En caso de ser nulo el objeto, se devuelve tal cual
			if (Object.ReferenceEquals(origen, null))
				return default(T);

			//Creamos un stream en memoria            
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new MemoryStream();
			using (stream) {
				try {
					formatter.Serialize(stream, origen);
					stream.Seek(0, SeekOrigin.Begin);
					//Deserializamos la porcón de memoria en el nuevo objeto                
					return (T)formatter.Deserialize(stream);
				} catch (SerializationException ex) { throw new ArgumentException(ex.Message, ex); } catch { throw; }
			}
		}
	}

	[Serializable()]
	public class Criptograma : ICloneable
	{

		private Boolean MonoCore;

		private Dictionary<Char, Char> _IndexAlfE;
		private Dictionary<Char, Char> _IndexAlfD;

		private Dictionary<Char, Char> _AlfTryTed;
		private SortedSet<String> _SortedTxt;

		private Dictionary<Char, Char> _IndexAlfA; // para uso del analyst

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
			
			this.MonoCore = true;
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

			//PruebaExterna();
		}

		public async Task<String> AnalistAsync(String TxtIn)
		{

			if (this.Brute) {
				List<Task<BigInteger>> TaskList = new List<Task<BigInteger>>();
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				Int32 Core;
				if (this.MonoCore) {
					Core = 1;
				} else {
					Core = Environment.ProcessorCount;
				}
				for (Int32 i=0;i< Core; ++i) {
					TaskList.Add(BruteStrAsync(TxtIn, i, Core, tokenSource.Token));
				}


				Task<BigInteger> resultTask = await Task.WhenAny(TaskList.ToArray());
				tokenSource.Cancel();

				this.AlfCode = resultTask.Result;
				GC.Collect();
				return this.Decifrar(TxtIn);
			} else {
				if (this.MonoCore) {
					throw new NotImplementedException();
					//return await HzAttack(TxtIn);
				} else {
					throw new NotImplementedException();
				}
			}
		}

		//// 	tryInSordTxt (iST){
		//// 		iDc = 0;
		//// 		While(tr = BuscarPalabra(iST,iDc)){
		//// 			si(Confirmar(tr)){
		//// 				UpAlfTryed(iST,tr);
		//// 				tryInSordTxt(++iTP);
		//// 			} else {
		//// 				iDc++;
		//// 			}
		//// 		}
		//// 		si ( iST>=SordTxt.lenght ){
		//// 			return true;
		//// 		} else {
		//// 			Descartar(Alf);
		//// 			return false;
		//// 		}
		//// 	}

		//private Boolean TyInSortedTxt(Int32 iST)
		//{
		//	Int32 iDc = 0;
		//	String tr;
		//	while (""!=(tr = BuscarPalabra(iST, iDc)) ) {

		//	}
		//	if (true) {
		//		return true;
		//	} else {
		//		// return false;
		//	}
		//}


		//private async Task<String> HzAttack(String TxtIn)
		//{
		//	return await Task.Run(() => {
		//		this.AlfCode = 0;
		//		String TxtOut = "";
		//		for (Int32 i = 0; i < TxtIn.Length; ++i) {
		//			if (this.IndexAlfE.TryGetValue(Char.ToUpper(TxtIn[i]), out Char temp)) {
		//				TxtOut += temp;
		//			} else {
		//				TxtOut += " ";
		//			}
		//		}
		//		String[] TxtOutSplited = TxtOut.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

		//		for (Int32 i = 0; i < TxtOutSplited.Length; ++i) {
		//			this.SortedTxt.Add(TxtOutSplited[i]);
		//		}

		//		Int32 iST = 0;

		//		TyInSortedTxt(iST);

		//		return this.Decifrar(TxtIn);
		//	});
		//}

		private async Task<BigInteger> BruteStrAsync(String TxtIn, BigInteger start,BigInteger Steps, CancellationToken token)
		{
			return await Task.Run(() => {
				Criptograma Fork;
				if (!this.MonoCore) {
					Fork = (Criptograma)this.Clone();
				} else {
					Fork = this;
				}

				Fork.AlfCode = 0;

				String TxtOut = "";
				for (Int32 i = 0; i < TxtIn.Length; ++i) {
					if (Fork.IndexAlfE.TryGetValue(Char.ToUpper(TxtIn[i]), out Char temp)) {
						TxtOut += temp;
					} else {
						TxtOut += " ";
					}
				}

				String[] TxtOutSplited = TxtOut.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

				for (Int32 i = 0; i < TxtOutSplited.Length; ++i) {
					Fork.SortedTxt.Add(TxtOutSplited[i]);
				}

				
				for (BigInteger Code = start; Code < BigInteger.Parse("403291461126605635584000000"); Code = BigInteger.Add(Code, Steps)) {
					try {
						if (token.IsCancellationRequested) {
							token.ThrowIfCancellationRequested();
						}
					} catch (OperationCanceledException) {
						break;
					}

					Fork.AlfCode = Code;
					Int32 Count = 0;
					for (Int32 pl = 0, c = Fork.SortedTxt.Count; pl < c; ++pl) {
						if (Fork.Palabras.Contains(Fork.Decifrar(Fork.SortedTxt.ElementAt(pl)))) {
							Count++;
						}
					}
					if (Count == Fork.SortedTxt.Count) {
						break;
					}
				}
				TxtOut = Fork.Decifrar(TxtIn);
				//Console.WriteLine("task " + Steps.ToString());
				return Fork.AlfCode;
			}, token);
		}

		public Object Clone()
		{
			return CrytogramDCipher.Utiles.Copia(this);
		}

		/*
		 * 
		 * 
		 * 
		 */



		//public void PruebaExterna()
		//{
			
		//	//List<String> dict = new List<String> { "AAA","BBB","CCC","ABC"};
		//	List<String> listEncryptedSentences = new List<String> { "BEST PEOPLE GO HOME" };
		//	List<String> dict = this.Palabras.ToList<String>();
		//	IEnumerable<String[]> listListWords = listEncryptedSentences.Select(encryptedSentence => encryptedSentence.Split(' '));

		//	foreach (String[] listWords in listListWords) {
		//		SolveAndPrint(dict, listWords);
		//	}
			
		//}

		//private static void SolveAndPrint(IEnumerable<String> dict, IEnumerable<String> encodedWords)
		//{
		//	IEnumerable<String> previousSolutions = new List<String>();
		//	IList<String> totalSolutions = null;
		//	String totalWordTillNow = String.Empty;

		//	foreach (String encodedWord in encodedWords) {
		//		IList<String> currentSolutions = GetMatchingStrings(dict, encodedWord);

		//		totalWordTillNow += encodedWord;
		//		totalSolutions = GetMatchingStrings(CrossJoin(previousSolutions, currentSolutions), totalWordTillNow);
		//		previousSolutions = totalSolutions;
		//	}

		//	if (totalSolutions == null) {
		//		totalSolutions = new List<String>();
		//	}

		//	String encodedString = String.Empty;
		//	List<String> decodedStrings = totalSolutions.Select(solution => String.Empty).ToList();

		//	foreach (String encodedWord in encodedWords) {
		//		encodedString += encodedWord + " ";
		//		for (Int32 i = 0; i < totalSolutions.Count; i++) {
		//			decodedStrings[i] += " " + totalSolutions[i].Substring(0, encodedWord.Length);
		//			totalSolutions[i] = totalSolutions[i].Substring(encodedWord.Length, totalSolutions[i].Length - encodedWord.Length);
		//		}
		//	}

		//	foreach (String decodedString in decodedStrings) {
		//		Console.WriteLine(encodedString + "=" + decodedString);
		//	}
		//}

		//private static IList<String> GetMatchingStrings(IEnumerable<String> possibleWords, String word)
		//{
		//	IList<IEnumerable<Int32>> wordPattern = GetWordLettersPattern(word);

		//	return possibleWords
		//		.Where(possibleWord => CompareCounts(wordPattern, GetWordLettersPattern(possibleWord)))
		//		.ToList();
		//}

		//private static IList<IEnumerable<Int32>> GetWordLettersPattern(String word)
		//{
		//	return word
		//		.ToCharArray()
		//		.Distinct()
		//		.Select(letter => GetPositions(word, letter.ToString(CultureInfo.InvariantCulture)))
		//		.ToList();
		//}

		//public static IEnumerable<Int32> GetPositions(String source, String searchString)
		//{
		//	List<Int32> ret = new List<Int32>();
		//	Int32 len = searchString.Length;
		//	Int32 start = -len;

		//	while (true) {
		//		start = source.IndexOf(searchString, start + len, StringComparison.InvariantCulture);
		//		if (start == -1) {
		//			return ret;
		//		}

		//		ret.Add(start);
		//	}
		//}

		//public static Boolean CompareCounts(IList<IEnumerable<Int32>> left, IList<IEnumerable<Int32>> right)
		//{
		//	Boolean returnVal = true;

		//	returnVal &= left.Count() == right.Count();
		//	if (returnVal) {
		//		for (Int32 i = 0; i < left.Count(); i++) {
		//			returnVal &= left[i].Count() == right[i].Count();
		//			if (!returnVal) {
		//				return false;
		//			}
		//		}
		//	}

		//	return returnVal;
		//}

		//public static List<String> CrossJoin(IEnumerable<String> left, IEnumerable<String> right)
		//{
		//	List<String> returnVal = new List<String>();

		//	if (!left.Any()) {
		//		returnVal.AddRange(right);
		//	} else if (!right.Any()) {
		//		returnVal.AddRange(left);
		//	} else {
		//		foreach (String leftItem in left) {
		//			String item = leftItem;

		//			returnVal.AddRange(right.Select(rightItem => item + rightItem));
		//		}
		//	}

		//	return returnVal;
		//}
	}
}


