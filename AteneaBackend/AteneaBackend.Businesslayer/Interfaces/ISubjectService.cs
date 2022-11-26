using AteneaBackend.Businesslayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectViewModel>> GetAll();
        Task<SubjectViewModel> GetbById(int id);
    }
}
