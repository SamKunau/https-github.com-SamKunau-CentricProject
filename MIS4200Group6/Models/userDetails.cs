using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Group6.Models
{
    public class userDetails
    {
        [Required]
        public Guid ID { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter your most frequently used email address")]
        public string email { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Employee first name is required")]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee last name is required")]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Mobile phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phoneNumber { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Employee location is required")]
        public string office { get; set; }

        [Display(Name = "Current Position")]
        [Required(ErrorMessage = "Employee position is required")]
        public string Position { get; set; }

        [Display(Name = "Centric Anniversary")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string HireDate { get; set; }

        [Display(Name ="Number of years with Centric")]
        public Int32 numberOfYears { get; set; }

        public string photo { get; set; }
    }
}