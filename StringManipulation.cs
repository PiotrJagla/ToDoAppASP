

using System.Runtime.CompilerServices;

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

        public static List<string> extractStrinsSeparatedByChar(string stringToSeparate, char charToSeparateBy)
        {
            List<string> extractedStrings = new List<string>();
            List<int> indexesOfCharToSeparateBy = getIndexesOfCharToSeparateBy(stringToSeparate, charToSeparateBy);

            for(int iii = 0; iii < indexesOfCharToSeparateBy.Count - 1; ++iii)
            {
                extractedStrings.Add(stringToSeparate.Substring(
                    indexesOfCharToSeparateBy[iii] + 1,
                    indexesOfCharToSeparateBy[iii+1] - indexesOfCharToSeparateBy[iii] - 1
                    )
                );
            }
            extractedStrings.RemoveAll(removeEmptyStrings => string.IsNullOrEmpty(removeEmptyStrings));

            return extractedStrings;
        }

        private static List<int> getIndexesOfCharToSeparateBy(string stringToDivide, char charToSeparateBy)
        {
            List<int> indexesOfCharToSeparateBy = new List<int>();

            indexesOfCharToSeparateBy.Add(-1);
            for(int iii = 0; iii<stringToDivide.Length; ++iii)
            {
                if (stringToDivide.ElementAt(iii) == charToSeparateBy)
                    indexesOfCharToSeparateBy.Add(iii);
            }
            indexesOfCharToSeparateBy.Add(stringToDivide.Length);

            return indexesOfCharToSeparateBy;
        }




    }
}
