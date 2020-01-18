using System;

namespace Password_Generator.Classes
{
    public class CharacterSets
    {
        Random r = new Random();

        // U
        public readonly string Uppercase_Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string GetRandomUppercaseAlph()
        {
            int index = r.Next(0, Uppercase_Alphabet.Length);
            return Uppercase_Alphabet[index].ToString();
        }

        // L
        public readonly string Lowercase_Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string GetRandomLowercaseAlph()
        {
            int index = r.Next(0, Lowercase_Alphabet.Length);
            return Lowercase_Alphabet[index].ToString();
        }

        // N
        public readonly string Numbers = "0123456789";
        public string GetRandomNumber()
        {
            int index = r.Next(0, Numbers.Length);
            return Numbers[index].ToString();
        }
        // *
        public readonly string Maths = @" /*-+()\";
        public string GetRandomMath()
        {
            int index = r.Next(0, Maths.Length);
            return Maths[index].ToString();
        }
        // S
        public readonly string Special = "`~!@#$%^&_[]{}|;:'\",<.>/?";
        public string GetRandomSpecial()
        {
            int index = r.Next(0, Special.Length);
            return Special[index].ToString();
        }
        // H
        public readonly string HexChars = "0123456789ABCDEF";
        public string GetRandomHexChar()
        {
            int index = r.Next(0, HexChars.Length);
            return HexChars[index].ToString();
        }
        // Special one
        // h
        public string GetRandomHexValue()
        {
            string s = string.Empty;
            int first_index = r.Next(0, HexChars.Length);
            int second_index = r.Next(0, HexChars.Length);
            s = $@"0x{HexChars[first_index]}{HexChars[second_index]}";
            return s;
        }

        // m
        public readonly string MixCaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string GetRandomMixedAlph()
        {
            int index = r.Next(0, MixCaseAlphabet.Length);
            return MixCaseAlphabet[index].ToString();
        }
        // V
        public readonly string Uppercase_Vowels = "AEIOU";
        public string GetRandomUpperVowel()
        {
            int index = r.Next(0, Uppercase_Vowels.Length);
            return Uppercase_Vowels[index].ToString();
        }
        // v
        public readonly string Lowercase_Vowels = "aeiou";
        public string GetRandomLowerVowel()
        {
            int index = r.Next(0, Lowercase_Vowels.Length);
            return Lowercase_Vowels[index].ToString();
        }
        // C
        public readonly string Uppercase_Consonant = "BCDFGHJKLMNPQRSTVWXYZ";
        public string GetRandomUpperConst()
        {
            int index = r.Next(0, Uppercase_Consonant.Length);
            return Uppercase_Consonant[index].ToString();
        }
        // c
        public readonly string Lowercase_Consonant = "bcdfghjklmnpqrstvwxyz";
        public string GetRandomLowerConst()
        {
            int index = r.Next(0, Lowercase_Consonant.Length);
            return Lowercase_Consonant[index].ToString();
        }
        // B
        public readonly string Brackets = "()[]{}<>";
        public string GetRandomBracket()
        {
            int index = r.Next(0, Brackets.Length);
            return Brackets[index].ToString();
        }
        // s
        public readonly string Space = " ";
        public string GetJustASpace()
        {
            int index = r.Next(0, Space.Length);
            return Space[index].ToString();
        }

        public readonly string InvalidItem = "^^InVaLiD^^";
    }
}
