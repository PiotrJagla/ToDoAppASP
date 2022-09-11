namespace TODOapp
{
    public class InputValidation
    {
        private static int daysInFebruary = 0;

        public static bool isTaskNameCorrect(string taskName)
        {
            return taskName.Length <= 50;
        }

        public static bool isTaskImportanceCorrect(string taskImportance)
        {
            return taskImportance.ToLower() == "not important" ||
                taskImportance.ToLower() == "important" ||
                taskImportance.ToLower() == "very important";
        }

        public static bool isTaskDeadlineCorrect(string taskDeadline)
        {
            return areThereLettersInTaskDeadline(taskDeadline) == false &&
                areDashesInCorrectPlacec(taskDeadline) == true &&
                isDateAndTimeInCorrectFormat(taskDeadline) == true;
        }

        private static bool areThereLettersInTaskDeadline(string taskDeadline)
        {
            for(int iii = 0; iii < taskDeadline.Length; ++iii)
            { 

                if ((SafeConversion.CharToInt(taskDeadline.ElementAt(iii)) < 48 ||
                    SafeConversion.CharToInt(taskDeadline.ElementAt(iii)) > 57) &&
                    (taskDeadline.ElementAt(iii) != ' ' && taskDeadline.ElementAt(iii) != '-'))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool areDashesInCorrectPlacec(string taskDeadline)
        {
            List<int> dashesCorrectIndexesInString = new List<int>();
            dashesCorrectIndexesInString.Add(4);
            dashesCorrectIndexesInString.Add(7);
            dashesCorrectIndexesInString.Add(13);
            dashesCorrectIndexesInString.Add(16);

            for(int iii = 0; iii < dashesCorrectIndexesInString.Count; ++iii)
            {
                if (taskDeadline.ElementAt(dashesCorrectIndexesInString[iii]) != '-')
                    return false;
            }

            return true;
        }

        private static bool isDateAndTimeInCorrectFormat(string taskDeadline)
        {
            int indexOfSpace = taskDeadline.IndexOf(' ');
            string date = taskDeadline.Substring(0, indexOfSpace);
            string time = taskDeadline.Substring(indexOfSpace + 1, taskDeadline.Length - 1 - indexOfSpace);


            return isDateInCorrectFormat(date) == true && isTimeInCorrectFormat(time) == true;
        }

        private static bool isDateInCorrectFormat(string date)
        {
            //YYYY-MM-DD
            int[] dashesIndexes = new int[2] { 4, 7 };

            int year = SafeConversion.StringToInt(
                date.Substring(0, dashesIndexes[0])
            );

            int month = SafeConversion.StringToInt(
                date.Substring(dashesIndexes[0] + 1, dashesIndexes[1] - dashesIndexes[0] - 1)
            );

            int day = SafeConversion.StringToInt(
                date.Substring(dashesIndexes[1] + 1 , date.Length - dashesIndexes[1] - 1)
            );

            isLeapYear(year);
            return isCorrectDayOfMonth(month,day) == true && year <= 9999 && year >= 1000;
        }

        private static void isLeapYear(int year)
        {
            if (year % 4 == 0)
                daysInFebruary = 29;
            else
                daysInFebruary = 28;
        }

        private static bool isCorrectDayOfMonth(int month, int day)
        {
            if (month > 12)
                return false;

            int[] lastDayInMonths = new int[] 
            {0, 31, daysInFebruary, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return day <= lastDayInMonths[month];
        }

        private static bool isTimeInCorrectFormat(string time)
        {
            //HH-MM-SS
            int[] dashesIndexes = new int[2] { 2, 5 };

            int hours = SafeConversion.StringToInt(
                time.Substring(0, dashesIndexes[0])
            );

            int minutes =  SafeConversion.StringToInt(
                    time.Substring(dashesIndexes[0]+1, dashesIndexes[1] - dashesIndexes[0] - 1)
            );

            int secounds = SafeConversion.StringToInt(
                time.Substring(dashesIndexes[1] + 1, time.Length - dashesIndexes[1] - 1)
            ); 

            return hours <= 23 && minutes <= 59 && secounds <= 59;
        }

    }

}
