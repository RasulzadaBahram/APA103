namespace _08.Static_Class__Extension_Methods__Exceptions.Models
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }=false;
        public int FailedAttempts { get; set; } = 0;


        public User()
        {

        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;

        }


    }
}
