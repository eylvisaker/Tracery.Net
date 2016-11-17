﻿using System.Collections.Generic;

namespace Tracery.Net
{
    /// <summary>
    /// A static class containing all of the built-in ("universal") modifiers that can be applied.
    /// </summary>
    static class Modifiers
    {
        /// <summary>
        /// Punctuation used to end a sentence.
        /// </summary>
        private static List<char> sentencePunctuation = new List<char> { ',', '.', '!', '?' };

        /// <summary>
        /// List of all vowels.
        /// </summary>
        private static List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

        /// <summary>
        /// Capitalizes the given string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Capitalize(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Places a comma after the string unless it's the end of a sentence.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Comma(string str)
        {
            var lastChar = str[str.Length - 1];

            if (sentencePunctuation.Contains(lastChar))
                return str;

            return str + ",";
        }

        /// <summary>
        /// Wraps the given string in double-quotes.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string InQuotes(string str)
        {
            return "\"" + str + "\""; ;
        }

        /// <summary>
        /// Replaces all s with zzz, like how bees speak.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BeeSpeak(string str)
        {
            return str.Replace("s", "zzz");
        }

        /// <summary>
        /// Pluralises the given string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string S(string str)
        {
            var lastChar = str[str.Length - 1];
            var secondToLastChar = str[str.Length - 2];

            switch (lastChar)
            {
                case 'y':
                    // rays, convoys
                    if (!_isConsonant(secondToLastChar))
                    {
                        return str + "s";
                    }

                    // harpies, cries
                    return str.Substring(0, str.Length - 1) + "ies";
                case 'x':
                    // oxen, boxen, foxen
                    return str.Substring(0, str.Length - 1) + "xen";
                case 'z':
                    return str.Substring(0, str.Length - 1) + "zes";
                case 'h':
                    return str.Substring(0, str.Length - 1) + "hes";
                default:
                    return str + "s";
            }
        }

        /// <summary>
        /// Checks to see if the given character is a consonant.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool _isConsonant(char c)
        {
            // If the character is in the vowel list then it's not a consonant
            if(vowels.Contains(c))
            {
                return false;
            }
            
            return true;
        }
    }
}