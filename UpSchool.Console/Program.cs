using UpSchool.Console.Domain;
using UpSchool.Console.FirstExample;

Student student = new Student();

student.FirstName = "Alper";

student.LastName = "Tunga";

student.TCID = "33377788999111";

Console.WriteLine(student.FullName);

student.FullName = "Alper Tunga";

Teacher teacher = new Teacher();

teacher.FirstName = "Arman";

teacher.LastName = "Tunga";

Console.WriteLine(student.FullName);

var alper = "";
var colour = Colour.Blue;

if (colour == Colour.Red)
{
    Console.WriteLine("Red");
}

Console.WriteLine(student.FinalNotes);

Console.WriteLine(student.FullName);

Console.ReadLine();