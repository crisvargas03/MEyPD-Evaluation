using AteneaBackend.Businesslayer.ViewModels.Teacher;
using AteneaBackend.Datalayer.Models;
using AutoMapper;

namespace AteneaBackend.Businesslayer.Mapping
{
    public class TeacherMap : Profile
    {
        public TeacherMap()
        {
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Teacher, TeacherRegisterInputModel>().ReverseMap();
        }
    }
}
