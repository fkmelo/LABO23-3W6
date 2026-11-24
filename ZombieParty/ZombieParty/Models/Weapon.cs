using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        public int WeaponId { get; set; }

        [Display(Name = "Name")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "ValidationStringMinMax")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ValidationRequired")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(2500, ErrorMessage = "ValidationStringMax")]
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ValidationRequired")]
        public string? Description { get; set; }

        [Display(Name = "Force")]
        [Range(0, Double.MaxValue, ErrorMessage = "ValidationRange")]
        public decimal Force { get; set; }

        [Display(Name = "Price")]
        [Range(0, 100000, ErrorMessage = "ValidationRange")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "ValidDateRequired")]
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl, ErrorMessage = "ImageRequired")]
        public string? Image { get; set; }

        [Display(Name = "Qty")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ValidationRequired")]
        [Range(0, int.MaxValue, ErrorMessage = "ValidationRange")]
        public int Qty { get; set; }

        [Display(Name = "QtyBought")]
        [Range(0,int.MaxValue , ErrorMessage = "ValidationRange")]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }
    }
}
