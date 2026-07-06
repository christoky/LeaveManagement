using AutoMapper;
using LeaveManagement.Models.LeaveRequests;
using LeaveManagement.Models.LeaveTypes;

namespace LeaveManagement.MappingProfiles
{
    public class LeaveRequestAutoMapperProfile : Profile
    {
        public LeaveRequestAutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();

        }
    }
}
