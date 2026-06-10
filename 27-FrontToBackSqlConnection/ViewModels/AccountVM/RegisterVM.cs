using System.ComponentModel.DataAnnotations;

namespace FrontToBackSqlConnection.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "Surname cannot exceed 20 characters.")]
        [MinLength(3, ErrorMessage = "Surname must be at least 3 characters long.")]
        public string Surname { get; set; }
        [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
