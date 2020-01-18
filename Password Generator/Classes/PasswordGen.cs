using System;

namespace Password_Generator.Classes
{
    public class PasswordGen
    {
        PasswordGeneratorOptions Pass_Options;
        CharacterSets cs = new CharacterSets();

        public PasswordGen(PasswordGeneratorOptions inputOp)
        {
            // Init the class
            Pass_Options = inputOp;
        }

        public string GenerateAPassword()
        {
            string OutputString = string.Empty;
            // If Std
            if (Pass_Options.TypeOfGenerator == 0)
            {
                OutputString = GenerateAStdPassword();
            }
            // If Pattern
            else if (Pass_Options.TypeOfGenerator == 1)
            {
                OutputString = GenerateAPatternPassword();
            }
            return OutputString;
        }

        private string GenerateAStdPassword()
        {
            string OutputString = string.Empty;
            // setup for loop for how many to generate
            // another for loop to pick each char from set and assign to string randomly
            Random r = new Random();
            for (int i = 0; i < Pass_Options.TotalPasswords; i++)
            {
                // Each Char
                for (int j = 0; j < Pass_Options.PasswordLength; j++)
                {
                    int Selected_Index = r.Next(0, Pass_Options.CharSets.Length);
                    OutputString += Pass_Options.CharSets[Selected_Index];
                }

                // Add newlines if needed
                if (i != Pass_Options.TotalPasswords - 1)
                {
                    OutputString += Environment.NewLine;
                }
            }
            return OutputString;
        }

        private string GenerateAPatternPassword()
        {
            // TODO - MAKE THIS LOOK LESS LIKE SHIT
            string OutputString = string.Empty;
            for (int i = 0; i < Pass_Options.TotalPasswords; i++)
            {
                foreach (char c in Pass_Options.PatternString)
                {
                    switch (c)
                    {
                        case 'U':
                            OutputString += cs.GetRandomUppercaseAlph();
                            break;
                        case 'L':
                            OutputString += cs.GetRandomLowercaseAlph();
                            break;
                        case 'N':
                            OutputString += cs.GetRandomNumber();
                            break;
                        case '*':
                            OutputString += cs.GetRandomMath();
                            break;
                        case 'S':
                            OutputString += cs.GetRandomSpecial();
                            break;
                        case 'H':
                            OutputString += cs.GetRandomHexChar();
                            break;
                        case 'h':
                            OutputString += cs.GetRandomHexValue();
                            break;
                        case 'm':
                            OutputString += cs.GetRandomMixedAlph();
                            break;
                        case 'V':
                            OutputString += cs.GetRandomUpperVowel();
                            break;
                        case 'v':
                            OutputString += cs.GetRandomLowerVowel();
                            break;
                        case 'C':
                            OutputString += cs.GetRandomUpperConst();
                            break;
                        case 'c':
                            OutputString += cs.GetRandomLowerConst();
                            break;
                        case 'B':
                            OutputString += cs.GetRandomBracket();
                            break;
                        case 's':
                            OutputString += cs.GetJustASpace();
                            break;
                        default:
                            // Could make it tell the user
                            OutputString += cs.InvalidItem;
                            break;
                    }
                }
                // Add newlines if needed
                if (i != Pass_Options.TotalPasswords - 1)
                {
                    OutputString += Environment.NewLine;
                }
            }
            return OutputString;
        }
    }
}
