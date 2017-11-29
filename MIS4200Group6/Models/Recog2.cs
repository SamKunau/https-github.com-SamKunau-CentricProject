using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS4200Group6.Models
{
    public class Recog2
    {
        [Key]
        public int EmployeeRecognitionID { get; set; }

        [Display(Name = "Date Recognition is Given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CurentDateTime { get; set; }


        [Display(Name = "Comments")]
        public string RecognitionComments { get; set; }

        [Display(Name = "Employee Giving Recognition")]
        [Required]
        public Guid EmployeeGivingRecog { get; set; }

        [ForeignKey("EmployeeGivingRecog")]
        public virtual userDetails Giver { get; set; }

        public enum CoreValues
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

        [ForeignKey("ID")]
        public virtual userDetails UserDetails { get; set; }


    }
}