using System.Collections.ObjectModel;
using StudentManagement.MVVM.Models.StudentList;

namespace StudentManagement.Services.StudentList
{
    public class MockStudentService : IStudentService
    {
        private readonly ObservableCollection<Student> _students;
        private int _nextId;

        public MockStudentService()
        {
            _students = new ObservableCollection<Student>
            {
                new Student { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Department = "Computer Science" },
                new Student { Id = 2, Name = "Bob Smith", Email = "bob@example.com", Department = "Electrical Engineering" },
                new Student { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com", Department = "Physics" }
            };
            _nextId = _students.Max(s => s.Id) + 1;
        }


        public ObservableCollection<Student> GetAll() => _students;

        public Student? GetById(int id) =>
            _students.FirstOrDefault(s => s.Id == id);


        public void Add(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            student.Id = _nextId++;
            _students.Add(student);
        }


        public void Update(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));

            var index = IndexOf(student.Id);
            if (index < 0) return;

            // Replace the item so the ObservableCollection raises CollectionChanged
            _students[index] = student;
        }


        public void Delete(int id)
        {
            var index = IndexOf(id);
            if (index >= 0)
                _students.RemoveAt(index);
        }


        private int IndexOf(int id)
        {
            for (int i = 0; i < _students.Count; i++)
                if (_students[i].Id == id) return i;
            return -1;
        }
    }
}
