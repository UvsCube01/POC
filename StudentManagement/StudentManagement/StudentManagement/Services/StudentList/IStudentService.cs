using System.Collections.ObjectModel;
using StudentManagement.MVVM.Models.StudentList;

namespace StudentManagement.Services.StudentList
{
    /// <summary>
    /// Contract for all student data operations.
    /// All ViewModels consume this interface — never the concrete implementation.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>Returns the live collection bound to the UI.</summary>
        ObservableCollection<StudentDTO> GetAll();

        /// <summary>Returns a single student by Id, or null if not found.</summary>
        StudentDTO? GetById(int id);

        /// <summary>Adds a new student. Id is assigned internally.</summary>
        void Add(StudentDTO student);

        /// <summary>Updates an existing student matched by Id.</summary>
        void Update(StudentDTO student);

        /// <summary>Removes the student with the given Id.</summary>
        void Delete(int id);
    }
}
