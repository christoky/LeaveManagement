using LeaveManagement.Models.LeaveRequests;

namespace LeaveManagement.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();
        Task CancelLeaveRequest(int leaveRequestId);
        Task    ReviewLeaveRequest(int leaveRequestId, bool approved);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);

        /*       
        Task UpdateAllocationDays(LeaveRequest leaveRequest, bool deductDays);
         Task<LeaveRequestReadOnlyVM> GetAllLeaveRequests();
         */
    }
}