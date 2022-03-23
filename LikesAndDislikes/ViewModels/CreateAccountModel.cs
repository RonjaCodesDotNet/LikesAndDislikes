using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LikesAndDislikes.ViewModels
{
    public class CreateAccountModel
    {
        [DisplayName("Användarnamn")]
        [Required(ErrorMessage = "Vänligen välj ett användarnamn.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Användarnamnet måste vara minst 5 och max 20 tecken långt.")]
        public string Username { get; set; }

        [DisplayName("Lösenord")]
        [Required(ErrorMessage = "Vänligen välj ett lösenord.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Lösenordet måste vara minst 10 och max 50 tecken långt.")]
        public string Password { get; set; }
    }
}
