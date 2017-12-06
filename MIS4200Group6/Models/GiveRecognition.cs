using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS4200Group6.Models
{
    public class GiveRecognition
    {
        [Key]
        public int EmployeeRecognitionID { get; set; }

        [Display(Name = "Date Recognition is Given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CurentDateTime { get; set; }
        [Display(Name = "Core value recognized")]
        public Values values{ get; set; }

        [Display(Name = "Comments")]
        public string RecognitionComments { get; set; }

        [Display(Name = "Employee Giving Recognition")]
        [Required]
        public Guid EmployeeGivingRecog { get; set; }

        [ForeignKey("EmployeeGivingRecog")]
        public virtual userDetails Giver { get; set; }

        public enum Values
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5,
        }

        [Required]

        [Display(Name = "Employee Being Recognized")]
        public Guid ID { get; set; }

        [Display(Name = "Employee Recognizing")]
        [ForeignKey("ID")]
        public virtual userDetails UserDetails { get; set; }
        


    }
}