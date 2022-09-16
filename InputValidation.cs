namespace TODOapp
{
    public class InputValidation
    {
        private static int daysInFebruary = 0;

        public static bool isInputCorrect(string taskName, string taskDeadline, string taskImportance)
        {
            return isTaskNameCorrect(taskName) &&
                   isTaskImportanceCorrect(taskImportance) &&
                   isTaskDeadlineCorrect(taskDeadline);
        }

        private static bool isTaskNameCorrect(string taskName)
        {
            return taskName.Length <= 50;
        }

        private static bool isTaskImportanceCorrect(string taskImportance)
        {
            return taskImportance.ToLower() == "not important" ||
                taskImportance.ToLower() == "important" ||
                taskImportance.ToLower() == "very important";
        }

        private static bool isTaskDeadlineCorrect(string taskDeadline)
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
            List<string> date_time = StringManipulation.extractStrinsSeparatedByChar(taskDeadline, ' ');

            return isDateInCorrectFormat(date_time[0]) == true &&
                   isTimeInCorrectFormat(date_time[1]) == true;
        }

        private static bool isDateInCorrectFormat(string date)
        {
            List<string> year_month_day = StringManipulation.extractStrinsSeparatedByChar(date, '-');

            isLeapYear(SafeConversion.StringToInt(year_month_day[0]));
            return isCorrectDayOfMonth(SafeConversion.StringToInt(year_month_day[1]),SafeConversion.StringToInt(year_month_day[2])) == true &&
                SafeConversion.StringToInt(year_month_day[0]) <= 9999 &&
                SafeConversion.StringToInt(year_month_day[0]) >= 1000;
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
            List<string> hours_minutes_secounds = StringManipulation.extractStrinsSeparatedByChar(time, '-');

            return SafeConversion.StringToInt(hours_minutes_secounds[0]) <= 23 &&
                   SafeConversion.StringToInt(hours_minutes_secounds[1]) <= 59 &&
                   SafeConversion.StringToInt(hours_minutes_secounds[2]) <= 59;
        }

    }

}
