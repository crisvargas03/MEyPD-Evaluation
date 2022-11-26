using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels;
using AteneaBackend.Datalayer.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Businesslayer.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly MainBDContext _mainContext;
        private readonly IMapper _mapper;
        public SubjectService(MainBDContext mainContext, IMapper mapper)
        {
            _mainContext = mainContext;
            _mapper = mapper;
        }

        public async Task<List<SubjectViewModel>> GetAll()
        {
            var subjects = _mainContext.Subject.ProjectTo<SubjectViewModel>(_mapper.ConfigurationProvider);
            return await subjects.ToListAsync();
        }

        public async Task<SubjectViewModel> GetbById(int id)
        {
            var subject = await _mainContext.Subject.Where(x => x.Id == id).ProjectTo<SubjectViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            if (subject != null)
                return subject;

            return null;
        }
    }
}
