using System.Text.RegularExpressions;

namespace SearchApi.Utills
{
    public class EnglishStemmer
    {
        private static readonly Regex doubleConsonantRegex = new Regex("(bb|dd|ff|gg|mm|nn|pp|rr|tt)$");
        private static readonly Regex liEndingRegex = new Regex("eed$|ing$|ed$");
        private static readonly Regex liEndingReplacementRegex = new Regex("eed|ing|ed");
        private static readonly Regex step1bRegex = new Regex("([aeiouy].)y$");

        public static string Stem(string word)
        {
            word = word.ToLower();

            if (word.Length <= 2)
                return word;

            word = Step1a(word);
            word = Step1b(word);
            word = Step1c(word);
            word = Step2(word);
            word = Step3(word);
            word = Step4(word);
            word = Step5a(word);
            word = Step5b(word);

            return word;
        }

        private static string Step1a(string word)
        {
            if (word.EndsWith("sses"))
                word = word.Substring(0, word.Length - 2);
            else if (word.EndsWith("ies"))
                word = word.Substring(0, word.Length - 2);
            else if (word.EndsWith("ss"))
                word = word;
            else if (word.EndsWith("s"))
                word = word.Substring(0, word.Length - 1);
            return word;
        }

        private static string Step1b(string word)
        {
            if (word.EndsWith("eed"))
            {
                var stem = word.Substring(0, word.Length - 3);
                if (HasMeasure(stem) > 0)
                    word = stem + "ee";
            }
            else if (word.EndsWith("ed") && liEndingRegex.IsMatch(word))
            {
                word = liEndingReplacementRegex.Replace(word, "");
                if (word.EndsWith("at") || word.EndsWith("bl") || word.EndsWith("iz"))
                    word += "e";
                else if (doubleConsonantRegex.IsMatch(word))
                    word = word.Substring(0, word.Length - 1);
                else if (IsShort(word))
                    word += "e";
            }
            else if (word.EndsWith("ing") && liEndingRegex.IsMatch(word))
            {
                word = liEndingReplacementRegex.Replace(word, "");
                if (doubleConsonantRegex.IsMatch(word) || step1bRegex.IsMatch(word))
                    word = word.Substring(0, word.Length - 1);
                else if (IsShort(word))
                    word += "e";
            }
            return word;
        }

        private static string Step1c(string word)
        {
            if (word.EndsWith("y"))
            {
                var stem = word.Substring(0, word.Length - 1);
                if (HasMeasure(stem) > 0)
                    word = stem + "i";
            }
            return word;
        }

        private static string Step2(string word)
        {
            if (word.EndsWith("ational"))
                word = word.Substring(0, word.Length - 7) + "ate";
            else if (word.EndsWith("tional"))
                word = word.Substring(0, word.Length - 6) + "tion";
            else if (word.EndsWith("enci"))
                word = word.Substring(0, word.Length - 4) + "ence";
            else if (word.EndsWith("anci"))
                word = word.Substring(0, word.Length - 4) + "ance";
            else if (word.EndsWith("izer"))
                word = word.Substring(0, word.Length - 4) + "ize";
            else if (word.EndsWith("abli"))
                word = word.Substring(0, word.Length - 4) + "able";
            else if (word.EndsWith("alli"))
                word = word.Substring(0, word.Length - 4) + "al";
            else if (word.EndsWith("entli"))
                word = word.Substring(0, word.Length - 5) + "ent";
            else if (word.EndsWith("eli"))
                word = word.Substring(0, word.Length - 3) + "e";
            else if (word.EndsWith("ousli"))
                word = word.Substring(0, word.Length - 5) + "ous";
            else if (word.EndsWith("ization"))
                word = word.Substring(0, word.Length - 7) + "ize";
            else if (word.EndsWith("ation"))
                word = word.Substring(0, word.Length - 5) + "ate";
            else if (word.EndsWith("ator"))
                word = word.Substring(0, word.Length - 4) + "ate";
            else if (word.EndsWith("alism"))
                word = word.Substring(0, word.Length - 5) + "al";
            else if (word.EndsWith("iveness"))
                word = word.Substring(0, word.Length - 7) + "ive";
            else if (word.EndsWith("fulness"))
                word = word.Substring(0, word.Length - 7) + "ful";
            else if (word.EndsWith("ousness"))
                word = word.Substring(0, word.Length - 7) + "ous";
            else if (word.EndsWith("aliti"))
                word = word.Substring(0, word.Length - 5) + "al";
            else if (word.EndsWith("iviti"))
                word = word.Substring(0, word.Length - 5) + "ive";
            else if (word.EndsWith("biliti"))
                word = word.Substring(0, word.Length - 6) + "ble";
            else if (word.EndsWith("logi"))
                word = word.Substring(0, word.Length - 4) + "log";
            return word;
        }
        private static string Step3(string word)
        {
            if (word.EndsWith("icate"))
                word = word.Substring(0, word.Length - 5) + "ic";
            else if (word.EndsWith("ative"))
                word = word.Substring(0, word.Length - 5);
            else if (word.EndsWith("alize"))
                word = word.Substring(0, word.Length - 5) + "al";
            else if (word.EndsWith("iciti"))
                word = word.Substring(0, word.Length - 5) + "ic";
            else if (word.EndsWith("ical"))
                word = word.Substring(0, word.Length - 4) + "ic";
            else if (word.EndsWith("ful"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ness"))
                word = word.Substring(0, word.Length - 4);
            return word;
        }

        private static string Step4(string word)
        {
            if (word.EndsWith("al"))
                word = word.Substring(0, word.Length - 2);
            else if (word.EndsWith("ance"))
                word = word.Substring(0, word.Length - 4);
            else if (word.EndsWith("ence"))
                word = word.Substring(0, word.Length - 4);
            else if (word.EndsWith("er"))
                word = word.Substring(0, word.Length - 2);
            else if (word.EndsWith("ic"))
                word = word.Substring(0, word.Length - 2);
            else if (word.EndsWith("able"))
                word = word.Substring(0, word.Length - 4);
            else if (word.EndsWith("ible"))
                word = word.Substring(0, word.Length - 4);
            else if (word.EndsWith("ant"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ement"))
                word = word.Substring(0, word.Length - 5);
            else if (word.EndsWith("ment"))
                word = word.Substring(0, word.Length - 4);
            else if (word.EndsWith("ent"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ism"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ate"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("iti"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ous"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ive"))
                word = word.Substring(0, word.Length - 3);
            else if (word.EndsWith("ize"))
                word = word.Substring(0, word.Length - 3);
            return word;
        }

        private static string Step5a(string word)
        {
            if (word.EndsWith("e"))
            {
                var stem = word.Substring(0, word.Length - 1);
                if (HasMeasure(stem) > 1 || (HasMeasure(stem) == 1 && !IsShort(stem)))
                    word = stem;
            }
            return word;
        }

        private static string Step5b(string word)
        {
            if (HasMeasure(word) > 1 && word.EndsWith("ll"))
                word = word.Substring(0, word.Length - 1);
            return word;
        }

        private static int HasMeasure(string word)
        {
            word = word.ToLower();
            var measure = 0;
            var vowel = false;
            for (var i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    if (!vowel)
                    {
                        measure++;
                        vowel = true;
                    }
                }
                else
                {
                    vowel = false;
                }
            }
            return measure;
        }

        private static bool IsVowel(char c)
        {
            return "aeiou".IndexOf(c) >= 0;
        }

        private static bool IsShort(string word)
        {
            return HasMeasure(word) == 1 && !IsVowel(word[0]);
        }
    }
}
