namespace TODOapp
{
    public class SafeConversion
    {
        public static int StringToInt(string stringToConvert)
        {
            try
            {
                return Convert.ToInt32(stringToConvert);
            }
            catch
            {
                return 0;
            }
        }

        public static int CharToInt(char charToConvert)
        {
            try
            {
                return Convert.ToInt32(charToConvert);
            }
            catch
            {
                return 0;
            }
        }
    }
}
