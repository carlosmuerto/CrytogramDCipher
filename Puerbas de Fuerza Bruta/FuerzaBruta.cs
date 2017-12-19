using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puerbas_de_Fuerza_Bruta
{
	[TestClass]
	public class FuerzaBruta
	{
		String Encriptado = "DNR CXMKPJC, GD YNU MRC ACSGELGLE M ORMLA LCW WCOSGTC DNR SNKCNLC, KNST TGKCS YNU WGJJ FMVC TN KMIC SURC TFC PRNTNTYPC JNNIS DGLGSFCA OY GLSCRTGLE TCXT NR PFNTNS NR WFMT FMVC YNU. TFC PURPNSC ND TFGS GS SN TFC PCRSNL VGCWGLE TFC PRNTNTYPC FMS M BFMLBC TN MBTUMJJY DCCJ MLA ULACRSTMLA TFC GACM OCFGLA WFMT YNU FMVC BRCMTCA.";
		String DesEncrtdo = "FOR EXAMPLE, IF YOU ARE DESIGNING A BRAND NEW WEBSITE FOR SOMEONE, MOST TIMES YOU WILL HAVE TO MAKE SURE THE PROTOTYPE LOOKS FINISHED BY INSERTING TEXT OR PHOTOS OR WHAT HAVE YOU. THE PURPOSE OF THIS IS SO THE PERSON VIEWING THE PROTOTYPE HAS A CHANCE TO ACTUALLY FEEL AND UNDERSTAND THE IDEA BEHIND WHAT YOU HAVE CREATED.";

		CrytogramDCipher.Criptograma Dicc = new CrytogramDCipher.Criptograma();

		[TestMethod]
		public void ForExampleTestAnalistAsync()
		{
			String ResurtAnalistAsync = this.Dicc.AnalistAsync(Encriptado).Result;
			Assert.AreEqual(this.DesEncrtdo, ResurtAnalistAsync);
		}

		[TestMethod]
		public void ForExampleTestDecifrar()
		{
			this.Dicc.AlfCode = BigInteger.Parse("1000");
			String ResurtDesEncriptado = this.Dicc.Decifrar(Encriptado);
			Assert.AreEqual(DesEncrtdo, ResurtDesEncriptado);
		}

		[TestMethod]
		public void ForExampleTestCifrar()
		{
			this.Dicc.AlfCode = BigInteger.Parse("1000");
			String ResurtEncriptado = this.Dicc.Cifrar(DesEncrtdo);
			Assert.AreEqual(Encriptado, ResurtEncriptado);
		}
	}
}
