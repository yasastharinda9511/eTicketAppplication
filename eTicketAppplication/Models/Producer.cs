using eTicketAppplication.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicketAppplication.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picure is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 & 50")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage ="Bio is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set;}

    }
}
