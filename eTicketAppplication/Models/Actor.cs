using eTicketAppplication.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicketAppplication.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture Required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3 , ErrorMessage = "Full Name must be between 3 & 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        // Relationships 

        public List<Actor_Movie> ? Actors_Movies { get; set; }

    }
}
