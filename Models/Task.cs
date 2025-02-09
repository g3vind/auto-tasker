using auto_tasker.Models.Enums;
using TaskStatus = auto_tasker.Models.Enums.TaskStatus;

namespace auto_tasker.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityLevel Priority { get; set; }  // Enum (Low, Medium, High)
        public TaskStatus Status { get; set; }  // Enum (Pending, InProgress, Completed)
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    


}
