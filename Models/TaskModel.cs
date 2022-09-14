namespace TODOapp.Models
{
    public class TaskModel
    {
        public TaskModel(int taskID, string taskName,
            string taskDeadline, string isTaskDone, string taskImportance)
        {
            this.ID = taskID;
            this.Name = taskName;
            this.Deadline = taskDeadline;
            this.IsDone = isTaskDone;
            this.Importance = taskImportance;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Deadline { get; set; }
        public string IsDone { get; set; }
        public string Importance { get; set; }
    }
}
