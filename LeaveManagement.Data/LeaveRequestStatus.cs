namespace LeaveManagement.Data
{
    //[EntityTypeConfiguration(typeof(LeaveRequestStatusConfiguration))]
    public class LeaveRequestStatus : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}