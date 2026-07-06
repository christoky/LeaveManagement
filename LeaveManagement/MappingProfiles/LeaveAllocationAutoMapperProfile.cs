using AutoMapper;
using LeaveManagement.Models.LeaveAllocations;
using LeaveManagement.Models.LeaveTypes;
using LeaveManagement.Models.Periods;

namespace LeaveManagement.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<Period, PeriodVM>();        }
    }
}
