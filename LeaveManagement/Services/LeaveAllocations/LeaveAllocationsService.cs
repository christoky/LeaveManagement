
using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models.LeaveAllocations;
using LeaveManagement.Services.Periods;
using LeaveManagement.Services.Users;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace LeaveManagement.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IUserService _userService, IMapper _mapper, IPeriodsService _periodsService) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            //get all leave types that have no allocation relative to this employee
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
                .ToListAsync();

            //get current period based on the year
            var period = await _periodsService.GetCurrentPeriod();
            var monthsRemaining = period.EndDate.Month - DateTime.Now.Month;

            //for each leave type, create an allocation antry and //calculate leave based on number of months left in the year
            foreach (var leaveType in leaveTypes)
            {
                //This works but not best practice, because it request database at each leaveType
                /*var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);
                if (allocationExists)
                {
                    continue;
                }
                */

                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                //if (accuralRate > 0)
                //{
                    var leaveAllocation = new LeaveAllocation
                    {
                        EmployeeId = employeeId,
                        LeaveTypeId = leaveType.Id,
                        PeriodId = period.Id,
                        Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                    };
                    _context.Add(leaveAllocation);
                //}               
            }

            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userService.GetLoggedInUser()
                : await _userService.GetUserById(userId);

            var allocations = await GetAllocations(user.Id);
            var allocationVmList =_mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);

            var leaveTypesCount = await _context.LeaveTypes.CountAsync();

            var employeeVm = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count()
            };

            return employeeVm;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userService.GetEmployees();
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }

        public async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
        {
            /*var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id) ?? throw new Exception("Leave allocation record does not exist."); */

            //Same as commented line above
            //var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id);
            //if (leaveAllocation == null)
            //{
            //    throw new Exception("Leave allocation record does not exist.");
            //}
            //leaveAllocation.Days = allocationEditVM.Days;
            // option 1 : _context.Update(leaveAllocation); ==> update all lines even not modified
            /*option 2 : _context.Entry(leaveAllocation).State = EntityState.Modified; ==> Update only modifed lines */
            // With these 2 option, we have to include: await _context.SaveChangesAsync();

            //Other Method to update
            await _context.LeaveAllocations
                .Where(q => q.Id == allocationEditVM.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));
        }

        public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
        {
            var period = await _periodsService.GetCurrentPeriod();
            var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == leaveTypeId
                && q.EmployeeId == employeeId
                && q.PeriodId == period.Id);

            return allocation;
        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {
            /*
            string employeeId = string.Empty;
            if (!string.IsNullOrEmpty(userId))
            {
                employeeId = userId;
            }
            else
            {
                //var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
                employeeId = user.Id;
            }*/


            var period = await _periodsService.GetCurrentPeriod();

            var leaveAllocations = await _context.LeaveAllocations
               .Include(q => q.LeaveType)
               .Include(q => q.Period)
               .Where(q => q.EmployeeId == userId && q.Period.Id == period.Id)
               .ToListAsync();

            return leaveAllocations;
        }

        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(l =>
            l.EmployeeId == userId
            && l.LeaveTypeId == leaveTypeId
            && l.PeriodId == periodId);

            return exists;
        }

    }
}
