namespace StudentManagement.MVVM.Models.StudentList
{
    /// <summary>
    /// Data Transfer Object for a Student. Data-only, no logic.
    /// </summary>
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
