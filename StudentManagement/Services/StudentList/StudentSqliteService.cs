using System.Collections.ObjectModel;
using SQLite;
using StudentManagement.MVVM.Models.StudentList;

namespace StudentManagement.Services.StudentList
{
    public class StudentSqliteService : IStudentService
    {
        private SQLiteConnection _db;//Connection to database
        private ObservableCollection<Student> _students;//List used for UI display

        public StudentSqliteService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "StudentDb.db3");
            _db = new SQLiteConnection(dbPath);//Connects your app to SQLite database
            _db.CreateTable<Student>();//Creates the Student table if it doesn't exist

            // Load initial data from database into the ObservableCollection
            var list = _db.Table<Student>().ToList();
            _students = new ObservableCollection<Student>(list);
        }

        public ObservableCollection<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(int id)
        {
            return _db.Table<Student>().FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            
            _db.Insert(student);//Save data in database
            _students.Add(student);//Add to UI list
        }

        public void Update(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));//If no student data → throw error

            _db.Update(student);
            
            // Find in current collection and update (to keep UI in sync)
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);//Find the same student in UI using Id
            if (existing != null)
            {
                var index = _students.IndexOf(existing);//replaces old data with new data
                _students[index] = student;
            }
        }

        public void Delete(int id)
        {
            _db.Delete<Student>(id);
            
            var existing = _students.FirstOrDefault(s => s.Id == id);//Find student in list
            if (existing != null)
            {
                _students.Remove(existing);//Remove from ObservableCollection
            }
        }
    }
}
