namespace LeaveManagement.Application.Models.LeaveAllocations;

public class EmployeeAllocationVM : EmployeeListVM
{
    [Display(Name = "Date Of Birth")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }
    public bool IsCompletedAllocation { get; set; }

    //View Models should only reference View Models
    //You should never reference Data Model from inside the View Modal
    public List<LeaveAllocationVM> LeaveAllocations { get; set; }
}
