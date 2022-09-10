namespace TODOapp
{
    public class InputValidation
    {
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
                areDashesInCorrectPlacec(taskDeadline) == true ;
        }

        private static bool areThereLettersInTaskDeadline(string taskDeadline)
        {
            for(int iii = 0; iii < taskDeadline.Length; ++iii)
            { 

                if ((Convert.ToInt32(taskDeadline.ElementAt(iii)) < 48 ||
                    Convert.ToInt32(taskDeadline.ElementAt(iii)) > 57) &&
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
            string date = taskDeadline.Substring(0, indexOfSpace-1);
            string time = taskDeadline.Substring(indexOfSpace + 1, taskDeadline.Length - 1 - indexOfSpace);


            return false;
        }

        private static bool isDateInCorrectFormat(string date)
        {
            return false;
        }

        private static bool isTimeInCorrectFormat(string time)
        {
            return false;
        }

    }

}
