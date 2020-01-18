using System;
using System.Linq;

namespace Password_Generator.Classes
{
    public class PasswordGeneratorOptions
    {
        // IMPORTANT - Applies to both pattern and std
        public int TotalPasswords { get; set; } = 1;

        public int PasswordLength { get; set; } = 1;
        public int TypeOfGenerator { get; set; }
        public bool Numbers { get; set; }
        public bool Special { get; set; }
        public bool Misc { get; set; }
        public bool Uppercase { get; set; }
        public bool Lowercase { get; set; }
        public string CharSets = string.Empty;
        public string PatternString = string.Empty;

        public void PasswordGenerationOptions()
        {
            TypeOfGenerator = (int)GenerationType.Standard;
            Numbers = false;
            Special = false;
            Misc = false;
            Uppercase = false;
            Lowercase = false;
        }

        public enum GenerationType
        {
            Standard = 0,
            Pattern = 1
        }

        public void SetStandardGeneration()
        {
            TypeOfGenerator = (int)GenerationType.Standard;
        }
        public void SetPatternGeneration()
        {
            TypeOfGenerator = (int)GenerationType.Pattern;
        }

        public bool CanGeneratePassword()
        {
            // These should never happen, but should check
            if(PasswordLength < 1) { return false; }
            if(TotalPasswords < 1) { return false; }
            if(TypeOfGenerator == 0)
            {
                if (Numbers == false && Special == false && Misc == false && Uppercase == false && Lowercase == false)
                { return false; }
                else
                { return true; }
            }
            else if(TypeOfGenerator == 1)
            {
                if (PatternString.Length < 1)
                { return false; }
                else
                { return true; }
            }
            return true;
        }

        public void Std_GenerateCharSets()
        {
            // Reset the string before anything
            CharSets = string.Empty;
            CharacterSets cs = new CharacterSets();

            if (Numbers == true)
            {
                CharSets += cs.Numbers;
            }
            if(Uppercase == true)
            {
                CharSets += cs.Uppercase_Alphabet;
            }
            if (Lowercase == true)
            {
                CharSets += cs.Lowercase_Alphabet;
            }
            if (Special == true)
            {
                CharSets += cs.Special;
            }
            if (Misc == true)
            {
                CharSets += cs.Maths;
            }
        }

        public void StorePatternString(string Pattern)
        {
            PatternString = Pattern;
        }
    }
}
