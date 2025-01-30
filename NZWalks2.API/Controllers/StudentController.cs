using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks2.API.Controllers
{
    //https://localhost:portnumber/api/Student
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        //GET : https://localhost:portnumber/api/Student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] StudentNames = { "Moataz", "Mariem", "Ali", "Omar", "Samir", "Amin" };

            return Ok(StudentNames);
        }
    }
}
