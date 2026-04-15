using System.Collections.ObjectModel;
using StudentManagement.MVVM.Models.StudentList;

namespace StudentManagement.Services.StudentList
{
    public interface IStudentService
    {
        //ObservableCollection<Student> GetAll();

        //Student? GetById(int id);

        //void Add(Student student);

        //void Update(Student student);

        //void Delete(int id);
        Task<List<Student>> GetAll();
        Task<Student> GetById(string id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<bool> Delete(string id);
    }
}
