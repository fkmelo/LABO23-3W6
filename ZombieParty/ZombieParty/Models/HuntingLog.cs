using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "StringLengthValidation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ValidationRequired")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "StringLengthValidation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ValidationRequired")]
        public string Description { get; set; }

        [Display(Name = "AdventureDate")]
        [DataType(DataType.DateTime, ErrorMessage ="ValidDateRequired")]
        public DateTime AdventureDate { get; set; }

        [ValidateNever]
        [Display(Name = "Zombies")]
        public virtual List<Zombie> Zombies { get; set; }
    }
}
