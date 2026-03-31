using _08.Static_Class__Extension_Methods__Exceptions.Models;
using _08.Static_Class__Extension_Methods__Exceptions.Utilities.Exceptions;

class Program
{
    public static void Main(string[] args)
    {
        LoginSystem loginSystem = new LoginSystem();
        while (true)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            try
            {
                bool result = loginSystem.Login(username, password);
                if (result = true)
                {
                    break;
                }
            }
            catch (InvalidUsernameException ex)
            {

                Console.WriteLine("ERRRO: " + ex.Message);
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                foreach (var item in loginSystem.Users)
                {
                    Console.WriteLine($"Sistemde olan istifadeciler: {item.Username}");

                }
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine("WARNING: " + ex.Message);
            }
            catch (AccountLockedException ex)
            {
                Console.WriteLine("CRITICAL:" + ex.Message+ "contact admin");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
            }




        }


    }


}
