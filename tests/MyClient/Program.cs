using System;
using System.Threading.Tasks;

namespace MyClient {
    class Program {
        static async Task Main(string[] args) {
            var client = new StudentClient("http://localhost:5000");
            var student = await client.AddAsync(new Student { Name = "A", Gpa = 4.0 });
            Console.WriteLine(student.Id);
        }
    }
}
