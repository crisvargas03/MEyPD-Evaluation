using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.Attendance;
using AteneaBackend.Datalayer.Context;
using AteneaBackend.Datalayer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Businesslayer.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly MainBDContext _mainContext;
        private readonly IMapper _mapper;

        public AttendanceService(MainBDContext mainContext, IMapper mapper)
        {
            _mainContext = mainContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceViewModel>> GetAll()
        {
            var attendances = _mainContext.Attendance.ProjectTo<AttendanceViewModel>(_mapper.ConfigurationProvider);
            return await attendances.ToListAsync();
        }

        public async Task<List<int>> GetTodayId(DateTime date)
        {
            var ids = await _mainContext.Attendance.Where(x => x.CreationDate.Date == date.Date).Select(x => x.Id).ToListAsync();
            return ids;
        } 

        public async Task<AttendanceViewModel> Save(AttendanceInputModel inputModel)
        {
            if (inputModel != null)
            {
                var mappedInput = _mapper.Map<Attendance>(inputModel);
                _mainContext.Attendance.Add(mappedInput);
                var result = await _mainContext.SaveChangesAsync();
                if (result >= 1)
                {
                    var newAttendance = await GetLast();
                    return _mapper.Map<AttendanceViewModel>(newAttendance);
                }
            }
            return null;
        }

        private async Task<Attendance> GetLast() => await _mainContext.Attendance.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
    }
}
