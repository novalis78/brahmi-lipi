using System;
using System.Collections.Generic;
using System.Text;

namespace BrahmiLipi
{
    class ImperialBrahmi
    {

        public string Replace(string a)
        {
            if (String.IsNullOrEmpty(a))
                return "";
            string b = "";
            b = this.resolveUnicodeLetters(a);
            b = this.replaceDoubleConsonants(b);
            b = this.replaceKMedials(b);
            b = this.replaceKHMedials(b);
            b = this.replaceGMedials(b);
            b = this.replaceGHMedials(b);
            b = this.replaceCMedials(b);
            b = this.replaceCHMedials(b);
            b = this.replaceJMedials(b);
            b = this.replaceJHMedials(b);
            b = this.replaceNYMedials(b);
            b = this.replaceWMedials(b);
            b = this.replaceWHMedials(b);
            b = this.replaceFMedials(b);
            b = this.replaceFHMedials(b);
            b = this.replacePNMedials(b); // .n
            b = this.replaceTMedials(b);
            b = this.replaceTHMedials(b);
            b = this.replaceDMedials(b);
            b = this.replaceDHMedials(b);

            b = this.replaceNMedials(b);
            b = this.replaceMMedials(b);
            b = this.replacePMedials(b);
            b = this.replacePHMedials(b);
            b = this.replaceBMedials(b);
            b = this.replaceBHMedials(b);
            b = this.replaceYMedials(b);
            b = this.replaceRMedials(b);
            b = this.replaceLMedials(b);
            b = this.replaceVMedials(b);
            b = this.replaceSMedials(b);
            b = this.replaceHMedials(b);

            b = this.replaceConsonantA(b);

            return b;
        }

        private string replaceKMedials(string b)
        {
            b = b.Replace("kA", '\x0421'.ToString());
            b = b.Replace("ke", '\x0422'.ToString());
            b = b.Replace("ko", '\x0423'.ToString());
            b = b.Replace("ki", '\x0424'.ToString());
            b = b.Replace("kI", '\x0425'.ToString());
            b = b.Replace("ku", '\x0426'.ToString());
            b = b.Replace("kU", '\x0427'.ToString());
            return b;
        }
        //fertig 1A
        private string replaceKHMedials(string b)
        {
            b = b.Replace("khA", '\x043D'.ToString());
            b = b.Replace("khe", '\x043E'.ToString());
            b = b.Replace("kho", '\x043F'.ToString());
            b = b.Replace("khi", '\x0440'.ToString());
            b = b.Replace("khI", '\x0441'.ToString());
            b = b.Replace("khu", '\x0442'.ToString());
            b = b.Replace("khU", '\x0443'.ToString());
            return b;
        }
        //fertig 1A
        private string replaceGMedials(string b)
        {
            b = b.Replace("gA", '\x0428'.ToString());
            b = b.Replace("ge", '\x0429'.ToString());
            b = b.Replace("go", '\x042A'.ToString());
            b = b.Replace("gi", '\x042B'.ToString());
            b = b.Replace("gI", '\x042C'.ToString());
            b = b.Replace("gu", '\x042D'.ToString());
            b = b.Replace("gU", '\x042E'.ToString());
            return b;
        }
        private string replaceGHMedials(string b)
        {
            b = b.Replace("ghA", '\x2022'.ToString());
            b = b.Replace("ghe", '\x2013'.ToString());
            b = b.Replace("gho", '\x2014'.ToString());
            b = b.Replace("ghi", '\x02DC'.ToString());
            b = b.Replace("ghI", '\x2122'.ToString());
            b = b.Replace("ghu", '\x0161'.ToString());
            b = b.Replace("ghU", '\x203A'.ToString());
            return b;
        }
        //fertig
        private string replaceCMedials(string b)
        {
            b = b.Replace("cA", '\x042F'.ToString());
            b = b.Replace("ce", '\x0430'.ToString());
            b = b.Replace("co", '\x0431'.ToString());
            b = b.Replace("ci", '\x0432'.ToString());
            b = b.Replace("cI", '\x0433'.ToString());
            b = b.Replace("cu", '\x0434'.ToString());
            b = b.Replace("cU", '\x0435'.ToString());
            return b;
        }
        //fertig 1A
        private string replaceCHMedials(string b)
        {
            b = b.Replace("chA", '\x00A3'.ToString());
            b = b.Replace("che", '\x00A4'.ToString());
            b = b.Replace("cho", '\x00A5'.ToString());
            b = b.Replace("chi", '\x00A6'.ToString());
            b = b.Replace("chI", '\x00A7'.ToString());
            b = b.Replace("chu", '\x00A8'.ToString());
            b = b.Replace("chU", '\x00A9'.ToString());
            return b;
        }
        //fertig 1A
        private string replaceJMedials(string b)
        {
            b = b.Replace("jA", '\x00AA'.ToString());
            b = b.Replace("je", '\x00AC'.ToString());
            b = b.Replace("jo", '\x00AB'.ToString());
            b = b.Replace("ji", '\x00B0'.ToString());
            b = b.Replace("jI", '\x0444'.ToString());
            b = b.Replace("ju", '\x00AE'.ToString());
            b = b.Replace("jU", '\x00AF'.ToString());
            return b;
        }
        private string replaceJHMedials(string b)
        {
            b = b.Replace("jhA", '\x00B1'.ToString());
            b = b.Replace("jhe", '\x00B5'.ToString());
            b = b.Replace("jho", '\x00B6'.ToString());
            b = b.Replace("jhi", '\x00B7'.ToString());
            b = b.Replace("jhI", '\x00B2'.ToString());
            b = b.Replace("jhu", '\x00B3'.ToString());
            b = b.Replace("jhU", '\x00B4'.ToString());
            return b;
        }
        private string replaceNYMedials(string b)
        {
            b = b.Replace("zA", '\x00BB'.ToString());
            b = b.Replace("ze", '\x00BD'.ToString());
            b = b.Replace("zo", '\x00BC'.ToString());
            b = b.Replace("zi", '\x00B8'.ToString());
            b = b.Replace("zI", '\x00B9'.ToString());
            b = b.Replace("zu", '\x00BA'.ToString());
            b = b.Replace("zU", '\x00BE'.ToString());
            return b;
        }
        private string replaceWMedials(string b)
        {
            b = b.Replace("wA", '\x00C1'.ToString());
            b = b.Replace("we", '\x00C0'.ToString());
            b = b.Replace("wo", '\x00C5'.ToString());
            b = b.Replace("wi", '\x00BF'.ToString());
            b = b.Replace("wI", '\x00C2'.ToString());
            b = b.Replace("wu", '\x00C4'.ToString());
            b = b.Replace("wU", '\x00C3'.ToString());
            return b;
        }
        private string replaceWHMedials(string b)
        {
            b = b.Replace("whA", '\x00CC'.ToString());
            b = b.Replace("whe", '\x00C7'.ToString());
            b = b.Replace("who", '\x00C8'.ToString());
            b = b.Replace("whi", '\x00C6'.ToString());
            b = b.Replace("whI", '\x00C9'.ToString());
            b = b.Replace("whu", '\x00CA'.ToString());
            b = b.Replace("whU", '\x00CB'.ToString());
            return b;
        }
        private string replaceFMedials(string b)
        {
            b = b.Replace("fA", '\x00CD'.ToString());
            b = b.Replace("fe", '\x00D2'.ToString());
            b = b.Replace("fo", '\x00D0'.ToString());
            b = b.Replace("fi", '\x00D1'.ToString());
            b = b.Replace("fI", '\x00D3'.ToString());
            b = b.Replace("fu", '\x00CF'.ToString());
            b = b.Replace("fU", '\x00CE'.ToString());
            return b;
        }
        private string replaceFHMedials(string b)
        {
            b = b.Replace("fhA", '\x00D4'.ToString());
            b = b.Replace("fhe", '\x00D5'.ToString());
            b = b.Replace("fho", '\x00D6'.ToString());
            b = b.Replace("fhi", '\x00D7'.ToString());
            b = b.Replace("fhI", '\x00D8'.ToString());
            b = b.Replace("fhu", '\x00D9'.ToString());
            b = b.Replace("fhU", '\x00DA'.ToString());
            return b;
        }
        private string replacePNMedials(string b)
        {
            b = b.Replace("NA", '\x00DB'.ToString());
            b = b.Replace("Ne", '\x00DC'.ToString());
            b = b.Replace("No", '\x00DD'.ToString());
            b = b.Replace("Ni", '\x00DE'.ToString());
            b = b.Replace("NI", '\x00DF'.ToString());
            b = b.Replace("Nu", '\x00E0'.ToString());
            b = b.Replace("NU", '\x00E1'.ToString());
            return b;
        }
        private string replaceTMedials(string b)
        {
            b = b.Replace("tA", '\x00E2'.ToString());
            b = b.Replace("te", '\x00E8'.ToString());
            b = b.Replace("to", '\x00E4'.ToString());
            b = b.Replace("ti", '\x00E6'.ToString());
            b = b.Replace("tI", '\x00E3'.ToString());
            b = b.Replace("tu", '\x00E7'.ToString());
            b = b.Replace("tU", '\x00E5'.ToString());
            return b;
        }
        private string replaceTHMedials(string b)
        {
            b = b.Replace("thA", '\x00EA'.ToString());
            b = b.Replace("the", '\x00EB'.ToString());
            b = b.Replace("tho", '\x00EC'.ToString());
            b = b.Replace("thi", '\x00E9'.ToString());
            b = b.Replace("thI", '\x00EE'.ToString());
            b = b.Replace("thu", '\x00EF'.ToString());
            b = b.Replace("thU", '\x00ED'.ToString());
            return b;
        }
        private string replaceDMedials(string b)
        {
            b = b.Replace("dA", '\x00F1'.ToString());
            b = b.Replace("de", '\x00F2'.ToString());
            b = b.Replace("do", '\x00F0'.ToString());
            b = b.Replace("di", '\x00F3'.ToString());
            b = b.Replace("dI", '\x00F5'.ToString());
            b = b.Replace("du", '\x00F6'.ToString());
            b = b.Replace("dU", '\x00F4'.ToString());
            return b;
        }
        private string replaceDHMedials(string b)
        {
            b = b.Replace("dhA", '\x0451'.ToString());
            b = b.Replace("dhe", '\x00F8'.ToString());
            b = b.Replace("dho", '\x00F9'.ToString());
            b = b.Replace("dhi", '\x00FC'.ToString());
            b = b.Replace("dhI", '\x00FB'.ToString());
            b = b.Replace("dhu", '\x00FA'.ToString());
            b = b.Replace("dhU", '\x00F7'.ToString());
            return b;
        }
        private string replaceNMedials(string b)
        {
            b = b.Replace("nA", '\x0388'.ToString());
            b = b.Replace("ne", '\x0389'.ToString());
            b = b.Replace("no", '\x00FD'.ToString());
            b = b.Replace("ni", '\x00FE'.ToString());
            b = b.Replace("nI", '\x038A'.ToString());
            b = b.Replace("nu", '\x00F6'.ToString());
            b = b.Replace("nU", '\x0387'.ToString());
            return b;
        }
        private string replacePMedials(string b)
        {
            b = b.Replace("pA", '\x038C'.ToString());
            b = b.Replace("pe", '\x0390'.ToString());
            b = b.Replace("po", '\x038E'.ToString());
            b = b.Replace("pi", '\x0391'.ToString());
            b = b.Replace("pI", '\x038F'.ToString());
            b = b.Replace("pu", '\x0392'.ToString());
            b = b.Replace("pU", '\x0393'.ToString());
            return b;
        }
        private string replacePHMedials(string b)
        {
            b = b.Replace("phA", '\x0399'.ToString());
            b = b.Replace("phe", '\x0396'.ToString());
            b = b.Replace("pho", '\x0394'.ToString());
            b = b.Replace("phi", '\x0395'.ToString());
            b = b.Replace("phI", '\x0397'.ToString());
            b = b.Replace("phu", '\x039A'.ToString());
            b = b.Replace("phU", '\x0398'.ToString());
            return b;
        }
        private string replaceBMedials(string b)
        {
            b = b.Replace("bA", '\x03A1'.ToString());
            b = b.Replace("be", '\x039C'.ToString());
            b = b.Replace("bo", '\x039D'.ToString());
            b = b.Replace("bi", '\x039E'.ToString());
            b = b.Replace("bI", '\x039F'.ToString());
            b = b.Replace("bu", '\x03A0'.ToString());
            b = b.Replace("bU", '\x039B'.ToString());
            return b;
        }
        private string replaceBHMedials(string b)
        {
            b = b.Replace("bhA", '\x03A6'.ToString());
            b = b.Replace("bhe", '\x03A7'.ToString());
            b = b.Replace("bho", '\x03A8'.ToString());
            b = b.Replace("bhi", '\x03A9'.ToString());
            b = b.Replace("bhI", '\x03A3'.ToString());
            b = b.Replace("bhu", '\x03A4'.ToString());
            b = b.Replace("bhU", '\x03A5'.ToString());
            return b;
        }
        private string replaceMMedials(string b)
        {
            b = b.Replace("mA", '\x03AA'.ToString());
            b = b.Replace("me", '\x03AB'.ToString());
            b = b.Replace("mo", '\x03AC'.ToString());
            b = b.Replace("mi", '\x03AD'.ToString());
            b = b.Replace("mI", '\x03AE'.ToString());
            b = b.Replace("mu", '\x03AF'.ToString());
            b = b.Replace("mU", '\x03B0'.ToString());
            return b;
        }
        private string replaceYMedials(string b)
        {
            b = b.Replace("yA", '\x03B1'.ToString());
            b = b.Replace("ye", '\x03B2'.ToString());
            b = b.Replace("yo", '\x03B3'.ToString());
            b = b.Replace("yi", '\x03B4'.ToString());
            b = b.Replace("yI", '\x03B5'.ToString());
            b = b.Replace("yu", '\x03B6'.ToString());
            b = b.Replace("yU", '\x03B7'.ToString());
            return b;
        }
        private string replaceRMedials(string b)
        {
            b = b.Replace("rA", '\x03B8'.ToString());
            b = b.Replace("re", '\x03B9'.ToString());
            b = b.Replace("ro", '\x03BA'.ToString());
            b = b.Replace("ri", '\x03BB'.ToString());
            b = b.Replace("rI", '\x03BC'.ToString());
            b = b.Replace("ru", '\x03BD'.ToString());
            b = b.Replace("rU", '\x03BE'.ToString());
            return b;
        }
        private string replaceLMedials(string b)
        {
            b = b.Replace("lA", '\x03BF'.ToString());
            b = b.Replace("le", '\x03C0'.ToString());
            b = b.Replace("lo", '\x03C1'.ToString());
            b = b.Replace("li", '\x03C2'.ToString());
            b = b.Replace("lI", '\x03C3'.ToString());
            b = b.Replace("lu", '\x03C4'.ToString());
            b = b.Replace("lU", '\x03C5'.ToString());
            return b;
        }
        private string replaceVMedials(string b)
        {
            b = b.Replace("vA", '\x03C6'.ToString());
            b = b.Replace("ve", '\x03C7'.ToString());
            b = b.Replace("vo", '\x03C8'.ToString());
            b = b.Replace("vi", '\x03C9'.ToString());
            b = b.Replace("vI", '\x03CA'.ToString());
            b = b.Replace("vu", '\x03CB'.ToString());
            b = b.Replace("vU", '\x03CC'.ToString());
            return b;
        }
        private string replaceSMedials(string b)
        {
            b = b.Replace("sA", '\x040E'.ToString());
            b = b.Replace("se", '\x040F'.ToString());
            b = b.Replace("so", '\x0410'.ToString());
            b = b.Replace("si", '\x0411'.ToString());
            b = b.Replace("sI", '\x0412'.ToString());
            b = b.Replace("su", '\x0413'.ToString());
            b = b.Replace("sU", '\x0414'.ToString());
            return b;
        }
        private string replaceHMedials(string b)
        {
            b = b.Replace("hA", '\x0415'.ToString());
            b = b.Replace("he", '\x0416'.ToString());
            b = b.Replace("ho", '\x0417'.ToString());
            b = b.Replace("hi", '\x0418'.ToString());
            b = b.Replace("hI", '\x0419'.ToString());
            b = b.Replace("hu", '\x041A'.ToString());
            b = b.Replace("hU", '\x041B'.ToString());
            return b;
        }
        private string replaceConsonantA(string b)
        {
            b = b.Replace("ba", "b"); b = b.Replace("bha", "B"); b = b.Replace("bh", "B");
            b = b.Replace("ca", "c"); b = b.Replace("cha", "C"); b = b.Replace("ch", "C");
            b = b.Replace("da", "d"); b = b.Replace("dha", "D"); b = b.Replace("dh", "D");
            b = b.Replace("fa", "f"); b = b.Replace("fha", "F"); b = b.Replace("fh", "F");
            b = b.Replace("ga", "g"); b = b.Replace("gha", "G"); b = b.Replace("gh", "G");
            b = b.Replace("ha", "h");
            b = b.Replace("ja", "j"); b = b.Replace("jha", "J"); b = b.Replace("jh", "J");
            b = b.Replace("ka", "k"); b = b.Replace("kha", "K"); b = b.Replace("kh", "K");
            b = b.Replace("la", "l");
            b = b.Replace("ma", "m"); b = b.Replace("Ma", "M");
            b = b.Replace("na", "n"); b = b.Replace("Na", "N");
            b = b.Replace("pa", "p"); b = b.Replace("pha", "P"); b = b.Replace("ph", "P");
            b = b.Replace("qa", "q");
            b = b.Replace("ra", "r"); b = b.Replace("Ra", "R");
            b = b.Replace("sa", "s");
            b = b.Replace("ta", "t"); b = b.Replace("tha", "T"); b = b.Replace("th", "T");
            b = b.Replace("va", "v");
            b = b.Replace("wa", "w"); b = b.Replace("Wa", "W");
            b = b.Replace("xa", "x");
            b = b.Replace("ya", "y");
            b = b.Replace("za", "z");
            return b;
        }


        //makes for the asokan magadhi touch
        //if used, start as first replacement...
        private string replaceDoubleConsonants(string dd)
        {
            //dd = dd.Replace("ss", "s");
            //dd = dd.Replace("cc", "c");
            //dd = dd.Replace("dd", "d"); //leave doubling
            dd = dd.Replace("mm", "Mm");
            dd = dd.Replace("nn", "Mn");
            dd = dd.Replace("zz", "Mz");
            dd = dd.Replace("NN", "MN");
            dd = dd.Replace("mb", "Mb");
            dd = dd.Replace("mB", "MB");
            dd = dd.Replace("mp", "Mp");
            dd = dd.Replace("mP", "MP");
            dd = dd.Replace("nt", "Mt");
            dd = dd.Replace("zc", "Mc");
            dd = dd.Replace("zj", "Mj");
            return dd;
        }

        private string resolveUnicodeLetters(string b)
        {
            b = b.Replace("ṃ", "M");
            b = b.Replace("ā", "A");
            b = b.Replace("ī", "I");
            b = b.Replace("ū", "U");
            b = b.Replace("ḍ", "f");
            b = b.Replace("ṭ", "w");
            b = b.Replace("ḷ", "l");//no letter!
            b = b.Replace("ṅ", "M");
            b = b.Replace("ṇ", "N");
            b = b.Replace("ñ", "y");
            return b;
        }

    }
}
