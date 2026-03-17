namespace _03.Object__Class__Constructor__Inheritance__this_vs_base_keywords.Models
{
    class Student : Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;



        public Student()
        {

        }
        public Student(string studentnumber) : this()
        {
            StudentNumber = studentnumber;
        }
        public Student(string studentnumber, string faculty) : this(studentnumber)
        {
            Faculty = faculty;
        }
        public Student(string studentnumber, string faculty, double gpa) : this(studentnumber, faculty)
        {
            GPA = gpa;
        }
        public Student(string studentnumber, string faculty, double gpa, int year)
        {
            Year = year;
        }


        public Student(string firstname,string lastname,int age, string email,int id):base(firstname,lastname,age,email,id)
        {

        }




        public void ShowStudentInfo()
        {
            Console.WriteLine($"{StudentNumber} {Faculty} {GPA} {Year}");
        }

        public int CalculateScholarship()
        {
            if (GPA >= 90)
            {
                return 500;
            }
            else if (GPA >= 80)
            {
                return 350;
            }
            else if (GPA >= 70)
            {
                return 200;
            }
            else
            {
                return 0;
            }


        }




    }
}
