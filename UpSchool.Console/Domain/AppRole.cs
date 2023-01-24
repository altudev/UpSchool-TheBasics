using Microsoft.AspNetCore.Identity;
using UpSchool.Console.Common;
using UpSchool.Console.FirstExample;

namespace UpSchool.Console.Domain
{
    public class AppRole:IdentityRole<string>,IEntity
    {

        public AppRole()
        {
            Student student = new Student();

            System.Console.WriteLine(student.GetFullName());
        }
    }
}
