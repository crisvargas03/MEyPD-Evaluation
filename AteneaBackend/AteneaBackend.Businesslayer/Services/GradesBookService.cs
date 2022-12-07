using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.GradeBooks;
using AteneaBackend.Businesslayer.ViewModels.Student;
using AteneaBackend.Datalayer.Context;
using AteneaBackend.Datalayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Businesslayer.Services
{
    public class GradesBookService : IGradesBookService
    {
        private readonly MainBDContext _mainContext;
        private readonly IMapper _mapper;
        public GradesBookService(MainBDContext mainContext, IMapper mapper)
        {
            _mainContext = mainContext;
            _mapper = mapper;
        }

        public async Task<GradesBookViewModels> SaveGrade(GradesBookInputModel inputModel)
        {
            if (inputModel != null)
            {
                var mappedInput = _mapper.Map<GradesBook>(inputModel);
                //TODO: method for generate carnet number
                _mainContext.GradesBook.Add(mappedInput);
                var result = await _mainContext.SaveChangesAsync();
                if (result >= 1)
                {
                    var newGradesBook = await GetLast();
                    return _mapper.Map<GradesBookViewModels>(newGradesBook);
                }
            }
            return null;
        }

        private async Task<GradesBook> GetLast() => await _mainContext.GradesBook.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
    }
}
