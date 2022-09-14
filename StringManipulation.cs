namespace TODOapp
{
    public class StringManipulation
    {
        public static string addSpaceBeforeBigLetter(string stringWithoutSpaceds)
        {
            string stringWithSpaces = stringWithoutSpaceds;

            for(int iii = 1; iii < stringWithSpaces.Length; ++iii)
            {
                if (isCharABigLetter(stringWithSpaces.ElementAt(iii)) == true)
                {
                    stringWithSpaces = stringWithSpaces.Insert(iii, " ");
                    iii = iii + 2;
                }
            }


            return stringWithSpaces;
        }

        private static bool isCharABigLetter(char input)
        {
            return SafeConversion.CharToInt(input) >= 65 &&
                SafeConversion.CharToInt(input) <= 90;
        }

        public static string removeCharFromString(string inputString, char charToRemove)
        {
            string stringWithoutSpecifiedChar = inputString;

            for (int iii = 1; iii < stringWithoutSpecifiedChar.Length; ++iii)
            {
                if (stringWithoutSpecifiedChar.ElementAt(iii) == charToRemove)
                {
                    stringWithoutSpecifiedChar = stringWithoutSpecifiedChar.Remove(iii, 1);
                    --iii;
                }
            }

            return stringWithoutSpecifiedChar;
        }
        

        
    }
}
