using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models.LeaveTypes;

namespace LeaveManagement.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
            public AutoMapperProfile()
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
