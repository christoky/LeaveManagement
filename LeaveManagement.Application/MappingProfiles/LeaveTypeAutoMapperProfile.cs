using AutoMapper;
using LeaveManagement.Application.Models.LeaveTypes;

namespace LeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();

            //Use this if the property names are different in source and destination
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));

            CreateMap<LeaveTypeCreateVM, LeaveType>();
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }
    }
}
