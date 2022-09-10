namespace TODOapp.Models
{
    public class TaskModel
    {
        public TaskModel(int taskID, string taskName,
            string taskDeadline, string isTaskDone, string taskImportance)
        {
            this.taskID = taskID;
            this.taskName = taskName;
            this.taskDeadline = taskDeadline;
            this.isTaskDone = isTaskDone;
            this.taskImportance = taskImportance;
        }

        public int taskID { get; set; }
        public string taskName { get; set; }
        public string taskDeadline { get; set; }
        public string isTaskDone { get; set; }
        public string taskImportance { get; set; }
    }
}
