using AteneaBackend.Businesslayer.ViewModels.GradeBooks;
using AteneaBackend.Datalayer.Models;
using AutoMapper;

namespace AteneaBackend.Businesslayer.Mapping
{
    public class GradesBookMap : Profile
    {
        public GradesBookMap()
        {
            CreateMap<GradesBook, GradesBookViewModels>();
            CreateMap<GradesBook, GradesBookInputModel>().ReverseMap();
        }
    }
}
