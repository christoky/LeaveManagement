using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data
{
    public class LeaveType : BaseEntity
    {
        [MaxLength(150)] //or [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; }
    }
}
