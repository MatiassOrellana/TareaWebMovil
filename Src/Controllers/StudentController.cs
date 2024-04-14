using courses_dotnet_api.Src.Interfaces;
using courses_dotnet_api.Src.Models;
using Microsoft.AspNetCore.Mvc;

namespace courses_dotnet_api.Src.Controllers;

public class StudentController : BaseApiController
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpPost]
    public async Task<IResult> CreateStudent(Student student)
    {
        Student? result = await _studentRepository.GetStudentByRutAsync(student.Rut);
        if(result is not null){

            return TypedResults.BadRequest("Student already exists");

        }

        await _studentRepository.AddStudentAsync(student);
        bool SaveChangesAsync = await _studentRepository.SaveChangesAsync();

        //si hubo un problema con la base de datos, en caso de los servicios
        if(SaveChangesAsync){

            return TypedResults.BadRequest("Hubo un error mientras se agrega al estudiante");

        }
        return TypedResults.Ok("El estudiante se agregó de manera exitosa");
    }

    [HttpGet]
    public async Task<IResult> GetStudents()
    {
        return TypedResults.Ok();
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetStudentById(int id)
    {
        return TypedResults.Ok();
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateStudent(int id, Student student)
    {
        return TypedResults.Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteStudent(int id)
    {
        return TypedResults.Ok();
    }
}
