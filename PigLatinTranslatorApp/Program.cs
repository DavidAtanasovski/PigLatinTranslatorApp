using System;
using System.Collections.Generic;
using System.Linq;

namespace PigLatinTranslatorApp
{
    /*
             English to Pig Latin Translator
                Pig latin has two very simple rules:

                If a word starts with a consonant move the first letter(s) of the word, till you reach a vowel, to the end of the word and add "ay" to the end.
                have ➞ avehay
                cram ➞ amcray
                take ➞ aketay
                cat ➞ atcay
                shrimp ➞ impshray
                trebuchet ➞ ebuchettray
				
                If a word starts with a vowel add "yay" to the end of the word.
                ate ➞ ateyay
                apple ➞ appleyay
                oaken ➞ oakenyay
                eagle ➞ eagleyay
                Write two functions to make an English to pig latin translator. The first function TranslateWord(word) takes a single word and returns that word translated into pig latin. The second function TranslateSentence(sentence) takes an English sentince and returns that sentence translated into pig latin.
                             
    */
    class Program
    {
        static void Main(string[] args)
        {
            var temp = TranslateWord("have?\"");
        }

        public static string TranslateWord(string word)
        {
            return StripFrotWord(word);
        }

        public static string Translate(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            const string vowels = "aeiou";

            if (vowels.Contains(char.ToLower(word[0])))
            {
                return string.Concat(word, "yay");
            }

            var makeUpper = false;
            var toTransfer = new List<char>();
            foreach (var w in word)
            {
                if (vowels.Contains(char.ToLower(w)))
                {
                    break;
                }
                toTransfer.Add(char.ToLower(w));
                if (char.IsUpper(w))
                {
                    makeUpper = true;
                }
            }

            var result = string.Concat(word.Substring(toTransfer.Count, word.Length - toTransfer.Count), string.Concat(toTransfer), "ay");
            return makeUpper ? char.ToUpper(result[0]) + result.Substring(1) : result;
        }

        static string StripFrotWord(string word)
        {
            if (word.Length == 0)
                return word;

            var f = word.First();
            if (!char.IsLetter(f))
            {
                return string.Concat(f, StripFrotWord(word.Remove(0, 1)));
            }

            return StripBackWord(word);
        }

        static string StripBackWord(string word)
        {
            if (word.Length == 0)
                return word;

            var l = word.Last();
            if (!char.IsLetter(l))
            {
                var temp = StripBackWord(word.Remove(word.Length - 1));
                return string.Concat(temp, l);
            }

            return Translate(word);
        }

        public static string TranslateSentence(string sentence)
        {
            var translation = new List<string>();
            foreach (var word in sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                translation.Add(TranslateWord(word));
            }

            return string.Join(" ", translation);
        }
    }
}
