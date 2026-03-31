using _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions;

namespace _08.Static_Class__Extension_Methods__Exceptions.Models
{
    internal class LoginSystem
    {
        User user = new();
        User[] users;
        const int MaxAttemps = 3;


        public User[] Users
        {
            get
            {
                return users;
            }
        }

        public LoginSystem()
        {
            users = new User[]
            {
                new User("admin","admin123" ),
                new User("student","studen123"),
                new User("teacher","teacher123")

            };
        }
        public void ValidateUsername(string username)
        {
            if (username.Length < 3 || username.Length == 0)
            {
                throw new InvalidUsernameException("3den az ve ya simvol yoxdur");
            }

        }
        public void ValidatePassword(string password)
        {
            if (password.Length < 6 || password.Length == 0)
            {
                throw new InvalidPasswordException("6den az ve ya simvol yoxdur");
            }
        }
        User FindUser(string username)
        {
            foreach (var item in users)
            {
                if (item.Username.ToLower() == username.ToLower())
                {
                    return item;
                }
            }
            throw new UserNotFoundException("Bele bir istifadeci yoxdur");

        }
        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            FindUser(username);

            if (username == null)
            {
                throw new UserNotFoundException();
            }

            if (user.IsLocked == true) 
            {
                throw new AccountLockedException("Hesab bloklandi");
            }


            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else 
            {
                user.FailedAttempts++;
                int attemptsLeft=MaxAttemps-user.FailedAttempts;
                if (attemptsLeft > 0)
                {

                    throw new IncorrectPasswordException();

                }
                else 
                {
                    user.IsLocked = true;
                    throw new AccountLockedException("Hesab baglidir");
                }

            }


        }













    }
}
