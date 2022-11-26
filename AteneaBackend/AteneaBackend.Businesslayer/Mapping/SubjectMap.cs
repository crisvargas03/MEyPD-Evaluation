using AteneaBackend.Businesslayer.ViewModels;
using AteneaBackend.Datalayer.Models;
using AutoMapper;

namespace AteneaBackend.Businesslayer.Mapping
{
    public class SubjectMap : Profile
    {
        public SubjectMap()
        {
            CreateMap<Subject, SubjectViewModel>();
        }
    }
}
