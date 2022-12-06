using AteneaBackend.Businesslayer.ViewModels.Attendance;
using AteneaBackend.Datalayer.Models;
using AutoMapper;

namespace AteneaBackend.Businesslayer.Mapping
{
    public class AttendanceMap : Profile
    {
        public AttendanceMap()
        {
            CreateMap<Attendance, AttendanceViewModel>();
            CreateMap<Attendance, AttendanceInputModel>().ReverseMap();
        }
    }
}
