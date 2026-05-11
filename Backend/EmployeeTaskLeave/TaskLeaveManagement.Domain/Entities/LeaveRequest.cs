namespace TaskLeaveManagement.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public int? ApprovedByUserId { get; set; }
    }
}
