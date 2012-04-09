using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BrahmiLipi
{
    class XenotypeBrahmi
    {
        public string ConvertToBrahmi(string a)
        {
            string[] syllables = ExtractSyllables(a);
            string convertedString = ConvertString(syllables);
            return convertedString;
        }

        private string ConvertString(string[] syllables)
        {
            string convertedString = "";
            foreach (string syl in syllables)
            {
                convertedString += GetSyllableCode(syl);
            }
            return convertedString;
        }

        private string[] ExtractSyllables(string a)
        {
            a = a.Replace("ṁ", "ṃ"); //cleanup

            List<string> syllables = new List<string>();
            string tmpSyl = "";
            char[] letters = a.ToCharArray();
            for(int i = 0; i < letters.Length; i++)//go through word by character
            {
                if (Char.IsWhiteSpace(letters[i]))
                {
                    if (letters[i] == '\r')
                    {
                        syllables.Add("\r");
                        tmpSyl = "";
                        continue;
                    }
                    else if (letters[i] == '\n')
                    {
                        syllables.Add("\n");
                        tmpSyl = "";
                        continue;
                    }
                    else
                    {
                        syllables.Add(" ");
                        tmpSyl = "";
                        continue;
                    }
                }
                
                tmpSyl += letters[i].ToString(); //add next char to temp. syllable
                if (IsVowel(letters[i])) //okay, we know the current one is a vowel
                {
                    if (i + 2 < letters.Length) //if there exists yet another two chars 
                    {
                        if (IsNasal(letters[i + 1], letters[i + 2])) //check if the first of those is nasal
                        {
                            //CVN (consonant+vowel+nasal)
                            tmpSyl += letters[i+1].ToString(); //if it is, store this to the syllable as well
                            i++;//increase counter again, because you added two chars to this syllable
                            syllables.Add(tmpSyl); //add syllable to list
                            tmpSyl = ""; //reset for next syllable
                        }
                        else
                        {
                            syllables.Add(tmpSyl); //not a nasal, store syllable
                            tmpSyl = ""; //reset for next syllable
                        }
                    }
                    else if (i + 1 < letters.Length) //if there exists yet another one char like aṃ 
                    {
                        if (IsNasal('ṃ', letters[i + 1])) //check if the first of those is nasal
                        {
                            tmpSyl += letters[i + 1].ToString();
                            i++;
                            syllables.Add(tmpSyl);
                            tmpSyl = "";
                        }
                    }
                    else
                    {
                        syllables.Add(tmpSyl); //not enough chars left
                        tmpSyl = ""; //store to this syllable and reset
                    }
                }
            }
            return syllables.ToArray();
        }

        private bool IsNasal(char next, char nextnext)
        {
            if (!IsVowel(nextnext))//we know that the second to come is not a vowel, so we are looking at a
            {                      //consonant cluster...that means the current is a nasal if it is one of the following chars
                if (next == 'n' || next == 'ñ' || next == 'ṇ' || next == 'ṅ'
                    || next == 'ṃ' || next == 'm' || next == 'ṁ')
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private bool IsVowel(char Ch)
        {
            if (Ch == 'a' || Ch == 'e' || Ch == 'i' || Ch == 'o' 
             || Ch == 'u' || Ch == 'A' || Ch == 'I' || Ch == 'U'
             || Ch == 'ā' || Ch == 'ī' || Ch == 'ū')
            {
                return true;
            }
            else return false;
        }

        private string GetSyllableCode(string a)
        {

            if (String.IsNullOrEmpty(a) || a.Contains(" "))
                return " ";
            if (a.Contains("\r"))
                return "\r";
            if (a.Contains("\n"))
                return "\r\n";
            string b = a;
            
            if (IsLigature(a))
            {
                b = this.resolveLigatures(a);
                return b;
            }
            string start = RemoveVowels(a);
            switch (start)
            {
                case "a": return b = determine_vowelstart(a);
                case "ā": return b = determine_vowelstart(a);
                case "i": return b = determine_vowelstart(a);
                case "ī": return b = determine_vowelstart(a);
                case "u": return b = determine_vowelstart(a);
                case "ū": return b = determine_vowelstart(a);
                case "e": return b = determine_vowelstart(a);
                case "o": return b = determine_vowelstart(a);

                case "k": return b = determine_k(a);
                case "kh": return b = determine_kh(a); 
                case "g": return b = determine_g(a); 
                case "gh": return b = determine_gh(a); 

                case "ṅ": return b = determine_NG(a); 

                case "c": return b = determine_c(a); 
                case "ch": return b = determine_ch(a); 
                case "j": return b = determine_j(a); 
                case "jh": return b = determine_jh(a); 

                case "ñ": return b = determine_NY(a); 

                case "ṭ": return b = determine_T(a); 
                case "ṭh": return b = determine_TH(a); 
                case "ḍ": return b = determine_D(a); 
                case "ḍh": return b = determine_DH(a); 

                case "ṇ": return b = determine_N(a); 

                case "t": return b = determine_t(a); 
                case "th": return b = determine_th(a); 
                case "d": return b = determine_d(a); 
                case "dh": return b = determine_dh(a); 

                case "n": return b = determine_n(a); 

                case "p": return b = determine_p(a); 
                case "ph": return b = determine_ph(a); 
                case "b": return b = determine_b(a); 
                case "bh": return b = determine_bh(a); 

                case "m": return b = determine_m(a); 
                
                case "y": return b = determine_y(a); 
                case "r": return b = determine_r(a); 
                case "l": return b = determine_l(a); 
                case "v": return b = determine_v(a); 
                case "s": return b = determine_s(a); 
                case "h": return b = determine_h(a); 

                case "ḷ": return b = determine_L(a); 
                case "ṃ": return b = determine_M(a);
                case "ṣa": return b = determine_S(a);
                case "śa": return b = determine_SH(a);

                default: return "";
            }
            return b;
        }

        private string RemoveVowels(string a)
        {
            if (String.IsNullOrEmpty(a))
                return a;
            string remain = a;
            if (Regex.IsMatch(a, "[nmñṃṇṅ]$"))
                remain = remain.Remove(remain.Length - 1);
            if (remain.Length >= 3)
                remain = remain.Substring(0, 2);
            else
                remain = remain.Substring(0, 1);

            return remain;
            //remain = Regex.Replace(a, "[aāiīuūeo]", " ");
            //remain = remain.Trim();
            //return remain;
        }

        private string determine_vowelstart(string b)
        {

            b = Regex.Replace(b, "a[nmñṃṇṅ]", "a\x00C2");
            b = Regex.Replace(b, "ā[nmñṃṇṅ]", "ā\x00C2");
            b = b.Replace("a", 'a'.ToString());
            b = b.Replace("ā", 'A'.ToString());

            b = Regex.Replace(b, "i[nmñṃṇṅ]", "i\x00C2");
            b = Regex.Replace(b, "ī[nmñṃṇṅ]", "ī\x00C2");
            b = b.Replace("i", 'i'.ToString());
            b = b.Replace("ī", 'I'.ToString());

            b = Regex.Replace(b, "u[nmñṃṇṅ]", "u\x00C2");
            b = Regex.Replace(b, "ū[nmñṃṇṅ]", "ū\x00C2");
            b = b.Replace("u", 'u'.ToString());
            b = b.Replace("ū", 'U'.ToString());

            b = Regex.Replace(b, "e[nmñṃṇṅ]", "e\x00C2");
            b = b.Replace("e", 'e'.ToString());

            b = Regex.Replace(b, "o[nmñṃṇṅ]", "o\x00C2");
            b = b.Replace("o", 'o'.ToString());

            return b;
        }

        private string determine_NG(string b)
        {
            b = Regex.Replace(b, "c.[nmñṃṇṅ]", '\x02CC'.ToString());
            b = b.Replace("ṅa", '\x00D2'.ToString());
            b = b.Replace("ṅā", '\x010F'.ToString());
            b = b.Replace("ṅi", '\x0130'.ToString());
            b = b.Replace("ṅī", '\x0151'.ToString());
            b = b.Replace("ṅu", '\x0176'.ToString());
            b = b.Replace("ṅū", '\x01D5'.ToString());
            b = b.Replace("ṅe", '\x01FA'.ToString());
            b = b.Replace("ṅo", '\x021B'.ToString());
            return b;
        }
        private string determine_c(string b)
        {
            b = Regex.Replace(b, "c.[nmñṃṇṅ]", '\x02CC'.ToString());
            b = b.Replace("ca", 'c'.ToString());
            b = b.Replace("cā", '\x0110'.ToString());
            b = b.Replace("ci", '\x0131'.ToString());
            b = b.Replace("cī", '\x0154'.ToString());
            b = b.Replace("cu", '\x0177'.ToString());
            b = b.Replace("cū", '\x01D6'.ToString());
            b = b.Replace("ce", '\x01FB'.ToString());
            b = b.Replace("co", '\x021E'.ToString());
            return b;
        }

        private string determine_ch(string b)
        {
            b = Regex.Replace(b, "ch.[nmñṃṇṅ]", '\x02CD'.ToString());
            b = b.Replace("cha", 'C'.ToString());
            b = b.Replace("chā", '\x0111'.ToString());
            b = b.Replace("chi", '\x0132'.ToString());
            b = b.Replace("chī", '\x0155'.ToString());
            b = b.Replace("chu", '\x0179'.ToString());
            b = b.Replace("chū", '\x01D7'.ToString());
            b = b.Replace("che", '\x01FC'.ToString());
            b = b.Replace("cho", '\x021F'.ToString());
            return b;
        }

        private string determine_j(string b)
        {
            b = Regex.Replace(b, "j.[nmñṃṇṅ]", '\x02CE'.ToString());
            b = b.Replace("ja", 'j'.ToString());
            b = b.Replace("jā", '\x0112'.ToString());
            b = b.Replace("ji", '\x0133'.ToString());
            b = b.Replace("jī", '\x0156'.ToString());
            b = b.Replace("ju", '\x017A'.ToString());
            b = b.Replace("jū", '\x01D8'.ToString());
            b = b.Replace("je", '\x01FD'.ToString());
            b = b.Replace("jo", '\x0226'.ToString());
            return b;
        }

        private string determine_NY(string b)
        {
            b = Regex.Replace(b, "ñ.[nmñṃṇṅ]", '\x02D8'.ToString());
            b = b.Replace("ña", '\x00D7'.ToString());
            b = b.Replace("ñā", '\x0114'.ToString());
            b = b.Replace("ñi", '\x0135'.ToString());
            b = b.Replace("ñī", '\x0158'.ToString());
            b = b.Replace("ñu", '\x017C'.ToString());
            b = b.Replace("ñū", '\x01DA'.ToString());
            b = b.Replace("ñe", '\x01FF'.ToString());
            b = b.Replace("ño", '\x0228'.ToString());
            return b;
        }

        private string determine_jh(string b)
        {
            b = Regex.Replace(b, "jh.[nmñṃṇṅ]", '\x02CF'.ToString());
            b = b.Replace("jha", 'J'.ToString());
            b = b.Replace("jhā", '\x0113'.ToString());
            b = b.Replace("jhi", '\x0134'.ToString());
            b = b.Replace("jhī", '\x0157'.ToString());
            b = b.Replace("jhu", '\x017B'.ToString());
            b = b.Replace("jhū", '\x01D9'.ToString());
            b = b.Replace("jhe", '\x01FE'.ToString());
            b = b.Replace("jho", '\x0227'.ToString());
            return b;
        }

       
        private string determine_k(string b)
        {
            b = Regex.Replace(b, "k.[nmñṃṇṅ]", '\x02C7'.ToString());
            b = b.Replace("ka", 'k'.ToString());
            b = b.Replace("kā", '\x010B'.ToString());
            b = b.Replace("ki", '\x012C'.ToString());
            b = b.Replace("kī", '\x014D'.ToString());
            b = b.Replace("ku", '\x0172'.ToString());
            b = b.Replace("kū", '\x01D1'.ToString());
            b = b.Replace("ke", '\x01F8'.ToString());
            b = b.Replace("ko", '\x0217'.ToString());
            return b;
        }

        private string determine_kh(string b)
        {
            b = Regex.Replace(b, "kh.[nmñṃṇṅ]", '\x02C8'.ToString());
            b = b.Replace("kha", 'K'.ToString());
            b = b.Replace("khā", '\x010C'.ToString());
            b = b.Replace("khi", '\x012D'.ToString());
            b = b.Replace("khī", '\x014E'.ToString());
            b = b.Replace("khu", '\x0173'.ToString());
            b = b.Replace("khū", '\x01D2'.ToString());
            b = b.Replace("khe", '\x01F5'.ToString());
            b = b.Replace("kho", '\x0218'.ToString());
            return b;
        }

        private string determine_g(string b)
        {
            b = Regex.Replace(b, "g.[nmñṃṇṅ]", '\x02C9'.ToString());
            b = b.Replace("ga", 'g'.ToString());
            b = b.Replace("gā", '\x010D'.ToString());
            b = b.Replace("gi", '\x012E'.ToString());
            b = b.Replace("gī", '\x014F'.ToString());
            b = b.Replace("gu", '\x0174'.ToString());
            b = b.Replace("gū", '\x01D3'.ToString());
            b = b.Replace("ge", '\x01F4'.ToString());
            b = b.Replace("go", '\x0219'.ToString());
            return b;
        }

        private string determine_gh(string b)
        {
            b = Regex.Replace(b, "gh.[nmñṃṇṅ]", '\x02CA'.ToString());
            b = b.Replace("gha", 'G'.ToString());
            b = b.Replace("ghā", '\x010D'.ToString());
            b = b.Replace("ghi", '\x012E'.ToString());
            b = b.Replace("ghī", '\x014F'.ToString());
            b = b.Replace("ghu", '\x0174'.ToString());
            b = b.Replace("ghū", '\x01D3'.ToString());
            b = b.Replace("ghe", '\x01F4'.ToString());
            b = b.Replace("gho", '\x0219'.ToString());
            return b;
        }

        private string determine_T(string b)
        {
            b = Regex.Replace(b, "ṭ.[nmñṃṇṅ]", '\x02D9'.ToString());
            b = b.Replace("ṭa", '\x00D8'.ToString());
            b = b.Replace("ṭā", '\x0115'.ToString());
            b = b.Replace("ṭi", '\x0136'.ToString());
            b = b.Replace("ṭī", '\x0159'.ToString());
            b = b.Replace("ṭu", '\x017F'.ToString());
            b = b.Replace("ṭū", '\x01DB'.ToString());
            b = b.Replace("ṭe", '\x0200'.ToString());
            b = b.Replace("ṭo", '\x0229'.ToString());
            return b;
        }
        private string determine_TH(string b)
        {
            b = Regex.Replace(b, "ṭh.[nmñṃṇṅ]", '\x02DA'.ToString());
            b = b.Replace("ṭha", '\x00D9'.ToString());
            b = b.Replace("ṭhā", '\x0116'.ToString());
            b = b.Replace("ṭhi", '\x0137'.ToString());
            b = b.Replace("ṭhī", '\x015A'.ToString());
            b = b.Replace("ṭhu", '\x018F'.ToString());
            b = b.Replace("ṭhū", '\x01DC'.ToString());
            b = b.Replace("ṭhe", '\x0201'.ToString());
            b = b.Replace("ṭho", '\x022A'.ToString());
            return b;
        }
        private string determine_D(string b)
        {
            b = Regex.Replace(b, "ḍ.[nmñṃṇṅ]", '\x02DB'.ToString());
            b = b.Replace("ḍa", '\x00DA'.ToString());
            b = b.Replace("ḍā", '\x0117'.ToString());
            b = b.Replace("ḍi", '\x0138'.ToString());
            b = b.Replace("ḍī", '\x015B'.ToString());
            b = b.Replace("ḍu", '\x0197'.ToString());
            b = b.Replace("ḍū", '\x03C2'.ToString());
            b = b.Replace("ḍe", '\x0202'.ToString());
            b = b.Replace("ḍo", '\x022B'.ToString());
            return b;
        }
        private string determine_DH(string b)
        {
            b = Regex.Replace(b, "ḍh.[nmñṃṇṅ]", '\x02DD'.ToString());
            b = b.Replace("ḍha", '\x00DB'.ToString());
            b = b.Replace("ḍhā", '\x0118'.ToString());
            b = b.Replace("ḍhi", '\x0139'.ToString());
            b = b.Replace("ḍhī", '\x015C'.ToString());
            b = b.Replace("ḍhu", '\x019A'.ToString());
            b = b.Replace("ḍhū", '\x01DE'.ToString());
            b = b.Replace("ḍhe", '\x0203'.ToString());
            b = b.Replace("ḍho", '\x022C'.ToString());
            return b;
        }
        private string determine_N(string b)
        {
            b = Regex.Replace(b, "ṇ.[nmñṃṇṅ]", '\x03BD'.ToString());
            b = b.Replace("ṇa", '\x00DC'.ToString());
            b = b.Replace("ṇā", '\x0119'.ToString());
            b = b.Replace("ṇi", '\x013A'.ToString());
            b = b.Replace("ṇī", '\x015D'.ToString());
            b = b.Replace("ṇu", '\x01A0'.ToString());
            b = b.Replace("ṇū", '\x01DF'.ToString());
            b = b.Replace("ṇe", '\x0204'.ToString());
            b = b.Replace("ṇo", '\x022D'.ToString());
            return b;
        }
        private string determine_t(string b)
        {
            b = Regex.Replace(b, "t.[nmñṃṇṅ]", '\x03BF'.ToString());
            b = b.Replace("ta", 't'.ToString());
            b = b.Replace("tā", '\x011A'.ToString());
            b = b.Replace("ti", '\x013B'.ToString());
            b = b.Replace("tī", '\x015E'.ToString());
            b = b.Replace("tu", '\x01A1'.ToString());
            b = b.Replace("tū", '\x01E0'.ToString());
            b = b.Replace("te", '\x0205'.ToString());
            b = b.Replace("to", '\x022E'.ToString());
            return b;
        }
        private string determine_th(string b)
        {
            b = Regex.Replace(b, "th.[nmñṃṇṅ]", '\x02F3'.ToString());
            b = b.Replace("tha", '\x00DE'.ToString());
            b = b.Replace("thā", '\x011B'.ToString());
            b = b.Replace("thi", '\x013C'.ToString());
            b = b.Replace("thī", '\x015F'.ToString());
            b = b.Replace("thu", '\x01AF'.ToString());
            b = b.Replace("thū", '\x01E1'.ToString());
            b = b.Replace("the", '\x0206'.ToString());
            b = b.Replace("tho", '\x022F'.ToString());
            return b;
        }
        private string determine_n(string b)
        {
            b = Regex.Replace(b, "n.[nmñṃṇṅ]", '\x0301'.ToString());
            b = b.Replace("na", 'n'.ToString());
            b = b.Replace("nā", '\x011E'.ToString());
            b = b.Replace("ni", '\x013F'.ToString());
            b = b.Replace("nī", '\x0164'.ToString());
            b = b.Replace("nu", '\x01B6'.ToString());
            b = b.Replace("nū", '\x01E4'.ToString());
            b = b.Replace("ne", '\x0209'.ToString());
            b = b.Replace("no", '\x0232'.ToString());
            return b;
        }
        private string determine_d(string b)
        {
            b = Regex.Replace(b, "d.[nmñṃṇṅ]", '\x02F7'.ToString());
            b = b.Replace("da", 'd'.ToString());
            b = b.Replace("dā", '\x011C'.ToString());
            b = b.Replace("di", '\x013D'.ToString());
            b = b.Replace("dī", '\x0162'.ToString());
            b = b.Replace("du", '\x01B0'.ToString());
            b = b.Replace("dū", '\x01E2'.ToString());
            b = b.Replace("de", '\x0207'.ToString());
            b = b.Replace("do", '\x0230'.ToString());
            return b;
        }
        private string determine_dh(string b)
        {
            b = Regex.Replace(b, "dh.[nmñṃṇṅ]", '\x02F7'.ToString());
            b = b.Replace("dha", 'D'.ToString());
            b = b.Replace("dhā", '\x011D'.ToString());
            b = b.Replace("dhi", '\x013E'.ToString());
            b = b.Replace("dhī", '\x0163'.ToString());
            b = b.Replace("dhu", '\x01B5'.ToString());
            b = b.Replace("dhū", '\x01E3'.ToString());
            b = b.Replace("dhe", '\x0208'.ToString());
            b = b.Replace("dho", '\x0231'.ToString());
            return b;
        }
        private string determine_p(string b)
        {
            b = Regex.Replace(b, "p.[nmñṃṇṅ]", '\x0302'.ToString());
            b = b.Replace("pa", 'p'.ToString());
            b = b.Replace("pā", '\x011F'.ToString());
            b = b.Replace("pi", '\x0140'.ToString());
            b = b.Replace("pī", '\x0165'.ToString());
            b = b.Replace("pu", '\x01B6'.ToString());
            b = b.Replace("pū", '\x01E4'.ToString());
            b = b.Replace("pe", '\x020A'.ToString());
            b = b.Replace("po", '\x0233'.ToString());
            return b;
        }
        private string determine_ph(string b)
        {
            b = Regex.Replace(b, "ph.[nmñṃṇṅ]", '\x0302'.ToString());
            b = b.Replace("pha", 'P'.ToString());
            b = b.Replace("phā", '\x0120'.ToString());
            b = b.Replace("phi", '\x0141'.ToString());
            b = b.Replace("phī", '\x0166'.ToString());
            b = b.Replace("phu", '\x01C5'.ToString());
            b = b.Replace("phū", '\x01E6'.ToString());
            b = b.Replace("phe", '\x020B'.ToString());
            b = b.Replace("pho", '\x0237'.ToString());
            return b;
        }
        private string determine_b(string b)
        {
            b = Regex.Replace(b, "b.[nmñṃṇṅ]", '\x0304'.ToString());
            b = b.Replace("ba", 'b'.ToString());
            b = b.Replace("bā", '\x0121'.ToString());
            b = b.Replace("bi", '\x0142'.ToString());
            b = b.Replace("bī", '\x0167'.ToString());
            b = b.Replace("bu", '\x01C6'.ToString());
            b = b.Replace("bū", '\x01E7'.ToString());
            b = b.Replace("be", '\x020C'.ToString());
            b = b.Replace("bo", '\x03C3'.ToString());
            return b;
        }
        private string determine_bh(string b)
        {
            b = Regex.Replace(b, "bh.[nmñṃṇṅ]", '\x0305'.ToString());
            b = b.Replace("bha", 'B'.ToString());
            b = b.Replace("bhā", '\x0122'.ToString());
            b = b.Replace("bhi", '\x0143'.ToString());
            b = b.Replace("bhī", '\x0168'.ToString());
            b = b.Replace("bhu", '\x01C7'.ToString());
            b = b.Replace("bhū", '\x01E8'.ToString());
            b = b.Replace("bhe", '\x020D'.ToString());
            b = b.Replace("bho", '\x03C4'.ToString());
            return b;
        }
        private string determine_m(string b)
        {
            b = Regex.Replace(b, "m.[nmñṃṇṅ]", '\x0306'.ToString());
            b = b.Replace("ma", 'm'.ToString());
            b = b.Replace("mā", '\x0123'.ToString());
            b = b.Replace("mi", '\x0144'.ToString());
            b = b.Replace("mī", '\x0169'.ToString());
            b = b.Replace("mu", '\x01C8'.ToString());
            b = b.Replace("mū", '\x01E9'.ToString());
            b = b.Replace("me", '\x020E'.ToString());
            b = b.Replace("mo", '\x03BB'.ToString());
            return b;
        }
        private string determine_y(string b)
        {
            b = Regex.Replace(b, "y.[nmñṃṇṅ]", '\x0307'.ToString());
            b = b.Replace("ya", 'y'.ToString());
            b = b.Replace("yā", '\x0124'.ToString());
            b = b.Replace("yi", '\x0145'.ToString());
            b = b.Replace("yī", '\x016A'.ToString());
            b = b.Replace("yu", '\x01C9'.ToString());
            b = b.Replace("yū", '\x01EA'.ToString());
            b = b.Replace("ye", '\x020F'.ToString());
            b = b.Replace("yo", '\x03BC'.ToString());
            return b;
        }
        private string determine_r(string b)
        {
            b = Regex.Replace(b, "r.[nmñṃṇṅ]", '\x0308'.ToString());
            b = b.Replace("ra", 'r'.ToString());
            b = b.Replace("rā", '\x0125'.ToString());
            b = b.Replace("ri", '\x0146'.ToString());
            b = b.Replace("rī", '\x016B'.ToString());
            b = b.Replace("ru", '\x01CA'.ToString());
            b = b.Replace("rū", '\x01EB'.ToString());
            b = b.Replace("re", '\x0210'.ToString());
            b = b.Replace("ro", '\x03BE'.ToString());
            return b;
        }
        private string determine_l(string b)
        {
            b = Regex.Replace(b, "l.[nmñṃṇṅ]", '\x0309'.ToString());
            b = b.Replace("la", 'l'.ToString());
            b = b.Replace("lā", '\x0126'.ToString());
            b = b.Replace("li", '\x0147'.ToString());
            b = b.Replace("lī", '\x016C'.ToString());
            b = b.Replace("lu", '\x01CB'.ToString());
            b = b.Replace("lū", '\x01EC'.ToString());
            b = b.Replace("le", '\x0211'.ToString());
            b = b.Replace("lo", '\x03C0'.ToString());
            return b;
        }
        private string determine_v(string b)
        {
            b = Regex.Replace(b, "v.[nmñṃṇṅ]", '\x030B'.ToString());
            b = b.Replace("va", 'v'.ToString());
            b = b.Replace("vā", '\x0127'.ToString());
            b = b.Replace("vi", '\x0148'.ToString());
            b = b.Replace("vī", '\x016D'.ToString());
            b = b.Replace("vu", '\x01CC'.ToString());
            b = b.Replace("vū", '\x01ED'.ToString());
            b = b.Replace("ve", '\x0212'.ToString());
            b = b.Replace("vo", '\x02BB'.ToString());
            return b;
        }
        private string determine_s(string b)
        {
            b = Regex.Replace(b, "s.[nmñṃṇṅ]", '\x030F'.ToString());
            b = b.Replace("sa", 's'.ToString());
            b = b.Replace("sā", '\x012A'.ToString());
            b = b.Replace("si", '\x014B'.ToString());
            b = b.Replace("sī", '\x0170'.ToString());
            b = b.Replace("su", '\x01CF'.ToString());
            b = b.Replace("sū", '\x01F2'.ToString());
            b = b.Replace("se", '\x0215'.ToString());
            b = b.Replace("so", '\x02BE'.ToString());
            return b;
        }
        private string determine_h(string b)
        {
            b = Regex.Replace(b, "h.[nmñṃṇṅ]", '\x0310'.ToString());
            b = b.Replace("ha", 'h'.ToString());
            b = b.Replace("hā", '\x012B'.ToString());
            b = b.Replace("hi", '\x014C'.ToString());
            b = b.Replace("hī", '\x0171'.ToString());
            b = b.Replace("hu", '\x01D0'.ToString());
            b = b.Replace("hū", '\x01F3'.ToString());
            b = b.Replace("he", '\x0216'.ToString());
            b = b.Replace("ho", '\x02BF'.ToString());
            return b;
        }
        private string determine_L(string b)
        {
            b = Regex.Replace(b, "ḷ.[nmñṃṇṅ]", '\x030D'.ToString());
            b = b.Replace("ḷa", 'L'.ToString());
            b = b.Replace("ḷā", '\x0128'.ToString());
            b = b.Replace("ḷi", '\x0149'.ToString());
            b = b.Replace("ḷī", '\x016E'.ToString());
            b = b.Replace("ḷu", '\x01CD'.ToString());
            b = b.Replace("ḷū", '\x01F0'.ToString());
            b = b.Replace("ḷe", '\x0213'.ToString());
            b = b.Replace("ḷo", '\x03C5'.ToString());
            return b;
        }
        private string determine_M(string b)
        {
            //b = Regex.Replace(b, "ṃ.[nmñṃṇṅ]", '\x004D'.ToString());
            b = b.Replace("ṃ", '\x004D'.ToString());
            //b = b.Replace("āṃ", '\x0128'.ToString());
            //b = b.Replace("iṃ", '\x0149'.ToString());
            //b = b.Replace("īṃ", '\x016E'.ToString());
            //b = b.Replace("uṃ", '\x01CD'.ToString());
            //b = b.Replace("ūṃ", '\x01F0'.ToString());
            //b = b.Replace("eṃ", '\x0213'.ToString());
            //b = b.Replace("oṃ", '\x03C5'.ToString());
            return b;
        }
        private string determine_S(string b)
        {
            b = Regex.Replace(b, "ṣ.[nmñṃṇṅ]", '\x030C'.ToString());
            b = b.Replace("ṣa", '\x012B'.ToString());
            //b = b.Replace("ṣā", '\x012B'.ToString());
            //b = b.Replace("ṣi", '\x014C'.ToString());
            //b = b.Replace("ṣī", '\x0171'.ToString());
            //b = b.Replace("ṣu", '\x01D0'.ToString());
            //b = b.Replace("ṣū", '\x01F3'.ToString());
            //b = b.Replace("ṣe", '\x0216'.ToString());
            //b = b.Replace("ṣo", '\x02BF'.ToString());
            return b;
        }
        private string determine_SH(string b)
        {
            b = Regex.Replace(b, "ś.[nmñṃṇṅ]", '\x030E'.ToString());
            b = b.Replace("śa", '\x00EE'.ToString());
            b = b.Replace("śā", '\x0129'.ToString());
            b = b.Replace("śi", '\x014a'.ToString());
            b = b.Replace("śī", '\x016F'.ToString());
            b = b.Replace("śu", '\x01CE'.ToString());
            b = b.Replace("śū", '\x01F1'.ToString());
            b = b.Replace("śe", '\x0214'.ToString());
            b = b.Replace("śo", '\x03C6'.ToString());
            return b;
        }

        //



        private bool IsLigature(string a)
        {
            if (String.IsNullOrEmpty(a))
                return false;
            

            char[] letters = a.ToCharArray();
            if (!IsVowel(letters[0]) && !IsVowel(letters[1]) && (letters[1] != 'h'))
                return true;
            else
                return false;
        }
       

        //if combo of consonants, need to resolve here
        private string resolveLigatures(string a)
        {
            
            a = a.Replace("kya", '\x0313'.ToString()); //
            //a = a.Replace("kva", '\x0219'.ToString());
            //a = a.Replace("khya", '\x0219'.ToString());
            //a = a.Replace("khva", '\x0219'.ToString());
            
            a = a.Replace("ghsa", '\x032E'.ToString()); //
            a = a.Replace("ghsā", '\x032F'.ToString()); //
            a = a.Replace("ghsi", '\x0330'.ToString()); //
            //... to be entered
            a = a.Replace("ghsaṃ", '\x035E'.ToString()); //

            #region cc-cch-jj-jjh

            a = a.Replace("cca", '\xF060'.ToString()); //
            a = a.Replace("ccā", '\xF061'.ToString()); //
            a = a.Replace("cci", '\xF062'.ToString()); //
            a = a.Replace("ccī", '\xF063'.ToString()); //
            a = a.Replace("ccu", '\xF064'.ToString()); //
            a = a.Replace("ccū", '\xF065'.ToString()); //
            a = a.Replace("cce", '\xF066'.ToString()); //
            a = a.Replace("cco", '\xF067'.ToString()); //
            a = Regex.Replace(a, "cc.[nmñṃṇṅ]", '\xF068'.ToString());
            
            a = a.Replace("ccha", '\x035F'.ToString()); //
            a = a.Replace("cchā", '\x0360'.ToString()); //
            a = a.Replace("cchi", '\x0361'.ToString()); //
            a = a.Replace("cchī", '\x0374'.ToString()); //
            a = a.Replace("cchu", '\x0375'.ToString()); //
            a = a.Replace("cchū", '\x037E'.ToString()); //
            a = a.Replace("cche", '\x0384'.ToString()); //
            a = a.Replace("ccho", '\x0385'.ToString()); //
            a = Regex.Replace(a, "cch.[nmñṃṇṅ]", '\x0386'.ToString());

            a = a.Replace("jja", '\xF069'.ToString()); //
            a = a.Replace("jjā", '\xF06A'.ToString()); //
            a = a.Replace("jji", '\xF06B'.ToString()); //
            a = a.Replace("jjī", '\xF06C'.ToString()); //
            a = a.Replace("jju", '\xF06D'.ToString()); //
            a = a.Replace("jjū", '\xF06E'.ToString()); //
            a = a.Replace("jje", '\xF06F'.ToString()); //
            a = a.Replace("jjo", '\xF070'.ToString()); //
            a = Regex.Replace(a, "jj.[nmñṃṇṅ]", '\xF071'.ToString());

            a = a.Replace("jjha", '\xF072'.ToString()); //
            a = a.Replace("jjhā", '\xF073'.ToString()); //
            a = a.Replace("jjhi", '\xF074'.ToString()); //
            a = a.Replace("jjhī", '\xF075'.ToString()); //
            a = a.Replace("jjhu", '\xF076'.ToString()); //
            a = a.Replace("jjhū", '\xF077'.ToString()); //
            a = a.Replace("jjhe", '\xF078'.ToString()); //
            a = a.Replace("jjho", '\xF079'.ToString()); //
            a = Regex.Replace(a, "jjh.[nmñṃṇṅ]", '\xF07A'.ToString());
            #endregion

            #region tt-tth-TT-TTH-DD-DDH-dd-ddh-tn-tm-tv
            a = a.Replace("tta", '\x0397'.ToString()); //
            a = a.Replace("ttā", '\x0398'.ToString()); //
            a = a.Replace("tti", '\x0399'.ToString()); //
            a = a.Replace("ttī", '\x039A'.ToString()); //
            a = a.Replace("ttu", '\x039B'.ToString()); //
            a = a.Replace("ttū", '\x039C'.ToString()); //
            a = a.Replace("tte", '\x039D'.ToString()); //
            a = a.Replace("tto", '\x039E'.ToString()); //
            a = Regex.Replace(a, "tt.[nmñṃṇṅ]", '\x039F'.ToString());

            a = a.Replace("ttha", '\xF024'.ToString()); //
            a = a.Replace("tthā", '\xF025'.ToString()); //
            a = a.Replace("tthi", '\xF026'.ToString()); //
            a = a.Replace("tthī", '\xF027'.ToString()); //
            a = a.Replace("tthu", '\xF028'.ToString()); //
            a = a.Replace("tthū", '\xF029'.ToString()); //
            a = a.Replace("tthe", '\xF02A'.ToString()); //
            a = a.Replace("ttho", '\xF02B'.ToString()); //
            a = Regex.Replace(a, "tth.[nmñṃṇṅ]", '\xF02C'.ToString());

            a = a.Replace("dda", '\xF02D'.ToString()); //
            a = a.Replace("ddā", '\xF02E'.ToString()); //
            a = a.Replace("ddi", '\xF02F'.ToString()); //
            a = a.Replace("ddī", '\xF030'.ToString()); //
            a = a.Replace("ddu", '\xF031'.ToString()); //
            a = a.Replace("ddū", '\xF032'.ToString()); //
            a = a.Replace("dde", '\xF033'.ToString()); //
            a = a.Replace("ddo", '\xF034'.ToString()); //
            a = Regex.Replace(a, "dd.[nmñṃṇṅ]", '\xF035'.ToString());
            
            a = a.Replace("ddha", '\x2002'.ToString()); //
            a = a.Replace("ddhā", '\x2003'.ToString()); //
            a = a.Replace("ddhi", '\x2004'.ToString()); //
            a = a.Replace("ddhī", '\x2005'.ToString()); //
            a = a.Replace("ddhu", '\x2006'.ToString()); //
            a = a.Replace("ddhū", '\x2007'.ToString()); //
            a = a.Replace("ddhe", '\x2008'.ToString()); //
            a = a.Replace("ddho", '\x2009'.ToString()); //
            a = Regex.Replace(a, "ddh.[nmñṃṇṅ]", '\x200A'.ToString());

            a = a.Replace("ṭṭa", '\xF036'.ToString()); //
            a = a.Replace("ṭṭā", '\xF037'.ToString()); //
            a = a.Replace("ṭṭi", '\xF038'.ToString()); //
            a = a.Replace("ṭṭī", '\xF039'.ToString()); //
            a = a.Replace("ṭṭu", '\xF03A'.ToString()); //
            a = a.Replace("ṭṭū", '\xF03B'.ToString()); //
            a = a.Replace("ṭṭe", '\xF03C'.ToString()); //
            a = a.Replace("ṭṭo", '\xF03D'.ToString()); //
            a = Regex.Replace(a, "ṭṭ.[nmñṃṇṅ]", '\xF03E'.ToString());

            a = a.Replace("ṭṭha", '\xF040'.ToString()); //
            a = a.Replace("ṭṭhā", '\xF041'.ToString()); //
            a = a.Replace("ṭṭhi", '\xF042'.ToString()); //
            a = a.Replace("ṭṭhī", '\xF043'.ToString()); //
            a = a.Replace("ṭṭhu", '\xF044'.ToString()); //
            a = a.Replace("ṭṭhū", '\xF045'.ToString()); //
            a = a.Replace("ṭṭhe", '\xF046'.ToString()); //
            a = a.Replace("ṭṭho", '\xF047'.ToString()); //
            a = Regex.Replace(a, "ṭṭh.[nmñṃṇṅ]", '\xF048'.ToString());
            
            a = a.Replace("ḍḍa", '\xF049'.ToString());
            a = a.Replace("ḍḍā", '\xF04A'.ToString()); //
            a = a.Replace("ḍḍi", '\xF04B'.ToString()); //
            a = a.Replace("ḍḍī", '\xF04C'.ToString()); //
            a = a.Replace("ḍḍu", '\xF04D'.ToString()); //
            a = a.Replace("ḍḍū", '\xF04E'.ToString()); //
            a = a.Replace("ḍḍe", '\xF04F'.ToString()); //
            a = a.Replace("ḍḍo", '\xF050'.ToString()); //
            a = Regex.Replace(a, "ḍḍ.[nmñṃṇṅ]", '\xF051'.ToString());

            a = a.Replace("ḍḍha", '\xF052'.ToString());
            a = a.Replace("ḍḍhā", '\xF053'.ToString()); //
            a = a.Replace("ḍḍhi", '\xF054'.ToString()); //
            a = a.Replace("ḍḍhī", '\xF055'.ToString()); //
            a = a.Replace("ḍḍhu", '\xF056'.ToString()); //
            a = a.Replace("ḍḍhū", '\xF057'.ToString()); //
            a = a.Replace("ḍḍhe", '\xF058'.ToString()); //
            a = a.Replace("ḍḍho", '\xF059'.ToString()); //
            a = Regex.Replace(a, "ḍḍh.[nmñṃṇṅ]", '\xF05A'.ToString());
            
            a = a.Replace("tna", '\x03A0'.ToString()); //
            a = a.Replace("tnā", '\x03A1'.ToString()); //
            a = a.Replace("tni", '\x03A3'.ToString()); //
            a = a.Replace("tnī", '\x03A4'.ToString()); //
            a = a.Replace("tnu", '\x03A5'.ToString()); //
            a = a.Replace("tnū", '\x03A6'.ToString()); //
            a = a.Replace("tne", '\x03A7'.ToString()); //
            a = a.Replace("tno", '\x03A8'.ToString()); //
            a = Regex.Replace(a, "tn.[nmñṃṇṅ]", '\x03A9'.ToString());

            a = a.Replace("tma", '\x03AA'.ToString()); //
            a = a.Replace("tmā", '\x03AB'.ToString()); //
            a = a.Replace("tmi", '\x03AC'.ToString()); //
            a = a.Replace("tmī", '\x03AD'.ToString()); //
            a = a.Replace("tmu", '\x03AE'.ToString()); //
            a = a.Replace("tmū", '\x03AF'.ToString()); //
            a = a.Replace("tme", '\x03B0'.ToString()); //
            a = a.Replace("tmo", '\x03B1'.ToString()); //
            a = Regex.Replace(a, "tm.[nmñṃṇṅ]", '\x03B2'.ToString());

            a = a.Replace("tva", '\xF05C'.ToString());
            a = a.Replace("tvā", '\xF05D'.ToString());
            a = a.Replace("tve", '\xF05E'.ToString());
            
            #endregion

            #region p-pph-b-bbh-dve
            a = a.Replace("pya", '\x0325'.ToString()); //
            a = a.Replace("pyi", '\x0326'.ToString()); //
            a = a.Replace("pta", '\x0323'.ToString()); //
            a = a.Replace("ptā", '\x0324'.ToString()); //
            a = a.Replace("dve", '\x0387'.ToString()); //
            a = a.Replace("dva", '\xF0B2'.ToString()); //

            a = a.Replace("ppa", '\xF07B'.ToString()); //
            a = a.Replace("ppā", '\xF07C'.ToString()); //
            a = a.Replace("ppi", '\xF07D'.ToString()); //
            a = a.Replace("ppī", '\xF07E'.ToString()); //
            a = a.Replace("ppu", '\xF07F'.ToString()); //
            a = a.Replace("ppū", '\xF080'.ToString()); //
            a = a.Replace("ppe", '\xF081'.ToString()); //
            a = a.Replace("ppo", '\xF082'.ToString()); //
            a = Regex.Replace(a, "pp.[nmñṃṇṅ]", '\xF083'.ToString());

            a = a.Replace("ppha", '\xF084'.ToString()); //
            a = a.Replace("pphā", '\xF085'.ToString()); //
            a = a.Replace("pphi", '\xF086'.ToString()); //
            a = a.Replace("pphī", '\xF087'.ToString()); //
            a = a.Replace("pphu", '\xF088'.ToString()); //
            a = a.Replace("pphū", '\xF089'.ToString()); //
            a = a.Replace("pphe", '\xF08A'.ToString()); //
            a = a.Replace("ppho", '\xF08B'.ToString()); //
            a = Regex.Replace(a, "pph.[nmñṃṇṅ]", '\xF08C'.ToString());

            a = a.Replace("bba", '\xF08D'.ToString()); //
            a = a.Replace("bbā", '\xF08E'.ToString()); //
            a = a.Replace("bbi", '\xF08F'.ToString()); //
            a = a.Replace("bbī", '\xF090'.ToString()); //
            a = a.Replace("bbu", '\xF091'.ToString()); //
            a = a.Replace("bbū", '\xF092'.ToString()); //
            a = a.Replace("bbe", '\xF093'.ToString()); //
            a = a.Replace("bbo", '\xF094'.ToString()); //
            a = Regex.Replace(a, "bb.[nmñṃṇṅ]", '\xF095'.ToString());

            a = a.Replace("bbha", '\xF096'.ToString()); //
            a = a.Replace("bbhā", '\xF097'.ToString()); //
            a = a.Replace("bbhi", '\xF098'.ToString()); //
            a = a.Replace("bbhī", '\xF099'.ToString()); //
            a = a.Replace("bbhu", '\xF09A'.ToString()); //
            a = a.Replace("bbhū", '\xF09B'.ToString()); //
            a = a.Replace("bbhe", '\xF09C'.ToString()); //
            a = a.Replace("bbho", '\xF09D'.ToString()); //
            a = Regex.Replace(a, "bbh.[nmñṃṇṅ]", '\xF09E'.ToString());
            #endregion

            a = a.Replace("mha", '\x0314'.ToString()); //
            a = a.Replace("mhi", '\x0315'.ToString()); //
            a = a.Replace("sta", '\x0389'.ToString()); //
            a = a.Replace("stā", '\x038A'.ToString()); //
            a = a.Replace("sti", '\x038C'.ToString()); //
            a = a.Replace("stī", '\x038E'.ToString()); //
            
            a = a.Replace("sva", '\x038F'.ToString()); //
            a = a.Replace("svā", '\x0390'.ToString()); //
            a = a.Replace("svi", '\x0391'.ToString()); //
            a = a.Replace("svī", '\x0392'.ToString()); //
            a = a.Replace("svu", '\x0393'.ToString()); //
            a = a.Replace("svū", '\x0394'.ToString()); //
            a = Regex.Replace(a, "sv.[nmñṃṇṅ]", '\x0395'.ToString());

            a = a.Replace("yva", '\x031B'.ToString()); //
            a = a.Replace("bra", '\xF09F'.ToString());
            

            #region kk-kkh-gg-ggh
            a = a.Replace("kkha", '\xF009'.ToString()); //
            a = a.Replace("kkhā", '\xF00A'.ToString()); //
            a = a.Replace("kkhi", '\xF00B'.ToString()); //
            a = a.Replace("kkhī", '\xF00C'.ToString()); //
            a = a.Replace("kkhu", '\xF00D'.ToString()); //
            a = a.Replace("kkhū", '\xF00E'.ToString()); //
            a = a.Replace("kkhe", '\xF00F'.ToString()); //
            a = a.Replace("kkho", '\xF010'.ToString()); //
            a = Regex.Replace(a, "kkh.[nmñṃṇṅ]", '\xF011'.ToString());
            
            a = a.Replace("kka", '\xF008'.ToString());
            a = a.Replace("kkā", '\xF000'.ToString()); //
            a = a.Replace("kki", '\xF001'.ToString()); //
            a = a.Replace("kkī", '\xF002'.ToString()); //
            a = a.Replace("kku", '\xF003'.ToString()); //
            a = a.Replace("kkū", '\xF004'.ToString()); //
            a = a.Replace("kke", '\xF005'.ToString()); //
            a = a.Replace("kko", '\xF006'.ToString()); //
            a = Regex.Replace(a, "kk.[nmñṃṇṅ]", '\xF007'.ToString());

            a = a.Replace("ggha", '\xF012'.ToString()); //
            a = a.Replace("gghā", '\xF013'.ToString()); //
            a = a.Replace("gghi", '\xF014'.ToString()); //
            a = a.Replace("gghī", '\xF015'.ToString()); //
            a = a.Replace("gghu", '\xF016'.ToString()); //
            a = a.Replace("gghū", '\xF017'.ToString()); //
            a = a.Replace("gghe", '\xF018'.ToString()); //
            a = a.Replace("ggho", '\xF019'.ToString()); //
            a = Regex.Replace(a, "ggh.[nmñṃṇṅ]", '\xF01A'.ToString());

            a = a.Replace("gga", '\xF01B'.ToString());
            a = a.Replace("ggā", '\xF01C'.ToString()); //
            a = a.Replace("ggi", '\xF01D'.ToString()); //
            a = a.Replace("ggī", '\xF01E'.ToString()); //
            a = a.Replace("ggu", '\xF01F'.ToString()); //
            a = a.Replace("ggū", '\xF020'.ToString()); //
            a = a.Replace("gge", '\xF021'.ToString()); //
            a = a.Replace("ggo", '\xF022'.ToString()); //
            a = Regex.Replace(a, "gg.[nmñṃṇṅ]", '\xF023'.ToString());
            #endregion
            
            //important missing ones...
            a = a.Replace("ssa", '\xF0A0'.ToString()); //
            a = a.Replace("ssā", '\xF0A1'.ToString()); //
            a = a.Replace("ssi", '\xF0A2'.ToString()); //
            a = a.Replace("ssī", '\xF0A3'.ToString()); //
            a = a.Replace("ssu", '\xF0A4'.ToString()); //
            a = a.Replace("ssū", '\xF0A5'.ToString()); //
            a = a.Replace("sse", '\xF0A6'.ToString()); //
            a = a.Replace("sso", '\xF0A7'.ToString()); //
            a = Regex.Replace(a, "ss.[nmñṃṇṅ]", '\xF0A8'.ToString());

            a = a.Replace("yya", '\xF0A9'.ToString()); //
            a = a.Replace("yyā", '\xF0AA'.ToString()); //
            a = a.Replace("yyi", '\xF0AB'.ToString()); //
            a = a.Replace("yyī", '\xF0AC'.ToString()); //
            a = a.Replace("yyu", '\xF0AD'.ToString()); //
            a = a.Replace("yyū", '\xF0AE'.ToString()); //
            a = a.Replace("yye", '\xF0AF'.ToString()); //
            a = a.Replace("yyo", '\xF0B0'.ToString()); //
            a = Regex.Replace(a, "yy.[nmñṃṇṅ]", '\xF0B1'.ToString());
            
            //@todo
            //need special ligature??????
            a = a.Replace("hma", "\x00F0\x00E6".ToString());
            a = a.Replace("vha", "\x00EB\x00F0".ToString());
            a = a.Replace("ḷha", "\x00EA\x00F0".ToString());
            a = a.Replace("lha", "\x00E9\x00F0".ToString());
            a = a.Replace("lla", "\x00E9\x00E9".ToString());
            a = a.Replace("lya", "\x00E9\x00E7".ToString());
            
            a = a.Replace("yha", "\x00E7\x00F0".ToString());

            a = a.Replace("mba", "\x00E6\x00E4".ToString());
            a = a.Replace("mpa", "\x00E6\x00E2".ToString());
            a = a.Replace("mpha", "\x00E6\x00E3".ToString());
            a = a.Replace("mbha", "\x00E6\x00E5".ToString());
                    
            //a = a.Replace("tra", '\x0219'.ToString());
            //a = a.Replace("dra", '\x0219'.ToString());
            //a = a.Replace("dhva", '\x0219'.ToString());
            //a = a.Replace("gra", '\x0219'.ToString());
            //a = a.Replace("kri", '\x0219'.ToString());
            
            return a;
        }
    }
}
