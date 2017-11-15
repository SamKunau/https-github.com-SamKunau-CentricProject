using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS4200Group6.Models
{
    public class CoreValue
    {
        public int ID {get; set;}

        [Display(Name ="Core Value Recognized")]
        public CoreValues award { get; set; }
        
        [Display(Name = "Description of Core Value")]
        public string description { get; set; }

        [Display(Name = "Person Giving the Recognition")]
        public Guid recognizer { get; set; }

        [Display(Name ="Person Receiving the Recognition")]
        public Guid recognized { get; set; }

        [Display(Name = "Date of Recognition")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime recognizationDate { get; set; }
        
        public enum CoreValues
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5,
        }
        //public enum Guid
        //{
            
        //}



    }
}