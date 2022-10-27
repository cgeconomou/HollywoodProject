using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entities.CustomValidations;

namespace Entities
{
    public class Actor : HollywoodEntity
    {
        public int ActorId { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Image")]
        public string PhotoUrl { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date of Death")]
        public DateTime? DateOfDeath { get; set; }
        [Display(Name = "Phone Number")]
        public string Telephone { get; set; }
        [CustomValidation(typeof(MyValidationMethods), "ValidateGreaterOrEqualToZero")]
        [Display(Name = "Annual Salary")]
        public double Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [NotMapped]
        public int Age
        {
            get {
                if (DateOfDeath.HasValue)
                {
                    return DateOfDeath.Value.Year - DateOfBirth.Year;
                }
                else
                {
                    return DateTime.Now.Year - DateOfBirth.Year;
                }
            }
        }



        //Navigation Properties
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
