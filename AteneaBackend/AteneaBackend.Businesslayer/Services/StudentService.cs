using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.Student;
using AteneaBackend.Datalayer.Context;
using AteneaBackend.Datalayer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Businesslayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly MainBDContext _mainContext;
        private readonly IMapper _mapper;
        public StudentService(MainBDContext mainContext, IMapper mapper)
        {
            _mainContext = mainContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAll()
        {
            var students = _mainContext.Student.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
            return await students.ToListAsync();
        }

        public async Task<StudentViewModel> GetById(int code)
        {
            var student = await _mainContext.Student.Where(x => x.Id == code).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            if (student != null)
            {
                return student;
            }
            return null;
        }

        public async Task<IEnumerable<StudentViewModel>> GetByTeacher(int teacherId)
        {
            var students = _mainContext.Student.Where(x => x.TeacherId == teacherId).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
            return await students.ToListAsync();
        }

        public async Task<StudentViewModel> Create(StudentInputModel inputModel)
        {
            if (inputModel != null)
            {
                var mappedInput = _mapper.Map<Student>(inputModel);
                //TODO: method for generate carnet number
                mappedInput.CardnetNumber = "23-" + new Random().Next(1000,9999).ToString();
                mappedInput.Codition = "NORMAL";
                _mainContext.Student.Add(mappedInput);
                var result = await _mainContext.SaveChangesAsync();
                if (result >= 1)
                {
                    var newStudent = await GetLast();
                    return _mapper.Map<StudentViewModel>(newStudent);
                }
            }
            return null;
        }

        public async Task<StudentViewModel> Update(StudentInputModel inputModel, int id)
        {
            if (id != 0 && inputModel != null)
            {
                var studentToEdit = await _mainContext.Student.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (studentToEdit != null)
                {
                    _mapper.Map(inputModel, studentToEdit);
                    
                    _mainContext.Student.Update(studentToEdit);
                    var result = await _mainContext.SaveChangesAsync();
                    if (result >= 1)
                    {
                        return _mapper.Map<StudentViewModel>(studentToEdit);
                    }
                }
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var student = await _mainContext.Student.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (student != null)
                {
                    student.IsDeleted = true;

                   _mainContext.Student.Update(student);
                    var result = await _mainContext.SaveChangesAsync();
                    if (result >= 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<Student> GetLast() => await _mainContext.Student.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
    }
}
