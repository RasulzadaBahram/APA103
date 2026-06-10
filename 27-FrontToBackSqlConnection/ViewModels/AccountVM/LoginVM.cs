using System.ComponentModel.DataAnnotations;

namespace FrontToBackSqlConnection.ViewModels.AccountVM
{
    public class LoginVM
    {
        [MaxLength(30, ErrorMessage = "Username or email cannot exceed 30 characters.")]
        [MinLength(3, ErrorMessage = "Username or email must be at least 3 characters long.")]
        public string UserNameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }

}

