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

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Phone]
        [Display(Name = "Primary Phone")]
        public string phoneNumber { get; set; }

        [Display(Name = "Office")]
        public string office { get; set; }

        [Display(Name = "Current Position")]
        public string Position { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string HireDate { get; set; }

        public string photo { get; set; }






    }
}