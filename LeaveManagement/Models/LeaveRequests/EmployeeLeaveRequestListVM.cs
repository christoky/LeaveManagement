namespace LeaveManagement.Models.LeaveRequests
{
    public class EmployeeLeaveRequestListVM
    {
        [Display(Name = "Total Number of Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pendind Requests")]
        public int PendindRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int DeclinedRequests { get; set; }

        //public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = new List<LeaveRequestReadOnlyVM>();
        //This is a simplified code
        public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = [];
    }
}