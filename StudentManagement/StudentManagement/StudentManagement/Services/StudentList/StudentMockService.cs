using System.Collections.ObjectModel;
using StudentManagement.MVVM.Models.StudentList;

namespace StudentManagement.Services.StudentList
{
    /// <summary>
    /// In-memory implementation of IStudentService using ObservableCollection so
    /// any CollectionView bound to GetAll() reacts to Add/Remove automatically.
    /// No business logic lives here — just data management.
    /// </summary>
    public class MockStudentService : IStudentService
    {
        private readonly ObservableCollection<StudentDTO> _students;
        private int _nextId;

        public MockStudentService()
        {
            _students = new ObservableCollection<StudentDTO>
            {
                new StudentDTO { Id = 1, Name = "Alice Johnson",  Email = "alice@example.com",   Department = "Computer Science" },
                new StudentDTO { Id = 2, Name = "Bob Smith",      Email = "bob@example.com",     Department = "Electrical Engineering" },
                new StudentDTO { Id = 3, Name = "Charlie Brown",  Email = "charlie@example.com", Department = "Physics" }
            };
            _nextId = _students.Max(s => s.Id) + 1;
        }

        // ── Read ────────────────────────────────────────────────────────────────

        public ObservableCollection<StudentDTO> GetAll() => _students;

        public StudentDTO? GetById(int id) =>
            _students.FirstOrDefault(s => s.Id == id);

        // ── Create ──────────────────────────────────────────────────────────────

        public void Add(StudentDTO student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            student.Id = _nextId++;
            _students.Add(student);
        }

        // ── Update ──────────────────────────────────────────────────────────────

        public void Update(StudentDTO student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));

            var index = IndexOf(student.Id);
            if (index < 0) return;

            // Replace the item so the ObservableCollection raises CollectionChanged
            _students[index] = student;
        }

        // ── Delete ──────────────────────────────────────────────────────────────

        public void Delete(int id)
        {
            var index = IndexOf(id);
            if (index >= 0)
                _students.RemoveAt(index);
        }

        // ── Helpers ─────────────────────────────────────────────────────────────

        private int IndexOf(int id)
        {
            for (int i = 0; i < _students.Count; i++)
                if (_students[i].Id == id) return i;
            return -1;
        }
    }
}
