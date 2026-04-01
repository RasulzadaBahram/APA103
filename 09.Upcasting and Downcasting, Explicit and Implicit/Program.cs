
using _09.Upcasting_and_Downcasting__Explicit_and_Implicit.Models;

internal class Program
{
    static void Main(string[] args)
    {

        Student student = new Student()
        {
            Id = 1,
            Class = "1B"
        };
        Teacher teacher = new Teacher()
        {
            ClassOwner = "1B",
            Salary = 1200
        };

        //Upcasting

        Person person = student;
        //Downcasting

        Student student1 = (Student)person;
        Console.WriteLine(person);




        //boxing

        int a = 5;
        Object b = a;

        //unboxing

        string c = b as string;

        Dollar dollar = new(200);
        Manat manat = new (170);

        Dollar dollar1 = (Dollar)manat;
        Console.WriteLine(dollar1.USD);

        Manat manat1 = (Manat)dollar;
        Console.WriteLine(manat1.AZN);


    }
}
