using _03.Object__Class__Constructor__Inheritance__this_vs_base_keywords.Models;

public class Program
{
    public static void Main()
    {
        Person person = new Person("Behram","Resulzade",19,"gg@gmail.com",15);
        Console.WriteLine( person.GetFullName());
        person.ShowBasicInfo();


        Student student = new Student("apa103-12","IT",88.5);
        Student student1 = new Student("apa103-10","IT",92);
        Student student2 = new Student("apa103-15","IT",68.5);

        student.ShowStudentInfo();
        student.CalculateScholarship();     //350 500 0



        Teacher teacher = new Teacher("IT", "Programming", 1200,15);
        Teacher teacher1 = new Teacher("IT", "Programming", 1200,8);

        teacher.ShowTeacherInfo();
        teacher.CalculateSalary();     //1600     4200



        Administrator administrator = new Administrator("Dekan");
        administrator.ShowAdminInfo();
        administrator.GrantAccess(student);

        //Console.WriteLine($"{student.ShowStudentInfo}{student.CalculateScholarship}");
        //Console.WriteLine($"{student1.ShowStudentInfo}{student.CalculateScholarship}");
        //Console.WriteLine($"{student2.ShowStudentInfo}{student.CalculateScholarship}");


        //Console.WriteLine($"{teacher.ShowTeacherInfo}{teacher.CalculateSalary}");
        //Console.WriteLine($"{teacher1.ShowTeacherInfo}{teacher1.CalculateSalary}");



        Console.WriteLine("umum teqaud");
        int umumTeqaud=student.CalculateScholarship()+student1.CalculateScholarship() + student2.CalculateScholarship();
        Console.WriteLine($"{umumTeqaud}");

        Console.WriteLine("umum maas");
        decimal umumMaas=teacher.CalculateSalary()+teacher1.CalculateSalary();
        Console.WriteLine($"{umumMaas}");











    }


}
