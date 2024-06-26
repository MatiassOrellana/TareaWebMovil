using courses_dotnet_api.Src.Models;

namespace courses_dotnet_api.Src.Interfaces;

public interface IStudentRepository
{
    Task<bool> SaveChangesAsync();
    Task AddStudentAsync(Student student);
    Task<Student?> GetStudentByIdAsync(int id);
    Task<bool> GetStudentByRutAsync(string rut);
    //added
    Task<bool> GetStudentByEmailAsync(string email);

    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<bool> UpdateStudentByIdAsync(int id, Student updateStudent);
    Task<bool> DeleteStudentByIdAsync(int id);
}
