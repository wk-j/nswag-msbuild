using System;
using Microsoft.AspNetCore.Mvc;

namespace MyApi {
    public class Student {
        public string Id { set; get; }
        public string Name { set; get; }
        public float Gpa { set; get; }
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase {

        [HttpPost]
        public ActionResult<Student> Add(Student student) {
            student.Id = Guid.NewGuid().ToString("N");
            return student;
        }
    }
}