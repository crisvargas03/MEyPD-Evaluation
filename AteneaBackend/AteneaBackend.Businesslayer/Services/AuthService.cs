using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.Student;
using AteneaBackend.Businesslayer.ViewModels.Teacher;
using AteneaBackend.Datalayer.Context;
using AteneaBackend.Datalayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Businesslayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly MainBDContext _mainContext;
        private readonly IMapper _mapper;

        public AuthService(MainBDContext mainContext, IMapper mapper)
        {
            _mainContext = mainContext;
            _mapper = mapper;
        }

        public async Task<TeacherViewModel> LoginWithCreds(TeacherLoginInputModel creds)
        {
            var teacherInfo = await _mainContext.Teacher.Where(t => t.Email == creds.Email && t.Password == creds.Password)
                .FirstOrDefaultAsync();

            if (teacherInfo != null) 
                return _mapper.Map<TeacherViewModel>(teacherInfo);

            return null;
        }

        public async Task<TeacherViewModel> Register(TeacherRegisterInputModel registerModel)
        {
            if (registerModel != null)
            {
                var mappedInput = _mapper.Map<Teacher>(registerModel);
                _mainContext.Teacher.Add(mappedInput);
                var result = await _mainContext.SaveChangesAsync();
                if (result >= 1)
                {
                    var newTeacher = await GetLast();
                    return _mapper.Map<TeacherViewModel>(newTeacher);
                }
            }
            return null;
        }
        private async Task<Student> GetLast() => await _mainContext.Student.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
    } 
}
