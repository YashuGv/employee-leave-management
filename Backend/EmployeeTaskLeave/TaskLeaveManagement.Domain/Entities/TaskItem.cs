namespace TaskLeaveManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AssignedToUserId { get; set; }
        public int CreatedByUserId { get; set; }
        public string Status { get; set; } = "New";
        public DateTime DueDate { get; set; }
    }
}
