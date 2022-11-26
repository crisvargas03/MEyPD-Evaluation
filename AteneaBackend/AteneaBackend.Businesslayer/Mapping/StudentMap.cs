using AteneaBackend.Businesslayer.ViewModels.Student;
using AteneaBackend.Datalayer.Models;
using AutoMapper;

namespace AteneaBackend.Businesslayer.Mapping
{
    public class StudentMap : Profile
    {
        public StudentMap()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<Student, StudentInputModel>().ReverseMap();
        }
    }
}
