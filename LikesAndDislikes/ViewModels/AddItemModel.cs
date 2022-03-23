using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LikesAndDislikes.ViewModels
{
    public class AddItemModel
    {
        [DisplayName("Vad önskar du göra?")]
        [Required(ErrorMessage = "Vänligen välj ett av alternativen.")]
        public string Action { get; set; }

        [DisplayName("Tillgängliga alternativ")]
        [Required(ErrorMessage = "Vänligen välj ett av alternativen.")]
        public string Option { get; set; }

        [DisplayName("Ditt val")]
        [Required(ErrorMessage = "Vänligen fyll i ditt val.")]
        public string Choice { get; set; }
        [DisplayName("Profilen detta ska skickas till")]
        [Required(ErrorMessage = "Vänligen fyll i ditt användarnamn.")]
        public string Username { get; set; }

        [DisplayName("Bekräfta att du äger profilen")]
        [Required(ErrorMessage = "Vänligen fyll i ditt lösenord.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
