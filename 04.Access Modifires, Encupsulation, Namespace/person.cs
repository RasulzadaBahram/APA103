namespace _04.Access_Modifires__Encupsulation__Namespace
{
    internal class person
    {

        private string name;
        public string lastname;

        public person() 
        {
        
        }
        public person(string name) :this()
        {
            this.name = name;
        }
        public person(string name,string lastname) :this(name)
        {
            this.lastname = lastname;
        }



        public string PersonInfo()
        {
            return $"Name: {name} Lastname: {lastname}";
        }







    }





}



