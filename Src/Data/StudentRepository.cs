using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace courses_dotnet_api.Src.Data;

//estos repositorios van dentro de data (recomendado por el profe)
public class StudentRepository : IStudentRepository
{
    private readonly DataContext _dataContext;

    public StudentRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> SaveChangesAsync()
    {
        //retorna true si hay 1 o más cambios, de lo contrario retornará falso
        return 0 < await _dataContext.SaveChangesAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _dataContext.Students.AddAsync(student);
    }

    //El "?" indica que el estudiante puede ser nulo
    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _dataContext.Students.FindAsync(id);//Find sirve para solamnte para claves prmarias
    }

    public async Task<Student?> GetStudentByRutAsync(string rut)
    {
        //FirstOrDefault sirve para encontrar estudiantes por un atributo en especifico
        return await _dataContext.Students.FirstOrDefaultAsync(s => s.Rut == rut);
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _dataContext.Students.ToListAsync();
    }

    public async Task<bool> UpdateStudentByIdAsync(int id, Student updateStudent)
    {
        var student = await GetStudentByIdAsync(id);
        if(student == null){
            return false;
        }
        student.Name = updateStudent.Name;
        student.Email = updateStudent.Email;

        return true;

    }

    public async Task<bool> DeleteStudentByIdAsync(int id)
    {
        var student = await GetStudentByIdAsync(id);
        if(student == null){
            return false;
        }
        _dataContext.Students.Remove(student);

        return true;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(string Name){

        return await _dataContext.Students.Where(x => x.Name.Contains(Name)).ToListAsync();;

    }
}
