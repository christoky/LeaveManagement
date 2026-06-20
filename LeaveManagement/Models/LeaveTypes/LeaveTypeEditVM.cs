using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models.LeaveTypes
{
    public class  LeaveTypeEditVM : BaseLeaveTypeVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "You have violated the lenght requirements")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 90)]
        [Display(Name = "Maximum allocation Of Days")]
        public int NumberOfDays { get; set; }
    }
}
