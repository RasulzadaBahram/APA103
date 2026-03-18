using _04.Access_Modifires__Encupsulation__Namespace;

public class Program 
{
    public static void Main() 
    {

        person person=new person("Beh","sel");



        teacher teacher=new teacher("sa","salm");


        string person1=person.PersonInfo();
        string teacher1= teacher.TeacherInfo();

        Console.WriteLine(person1);
        Console.WriteLine(teacher1);

    }
}