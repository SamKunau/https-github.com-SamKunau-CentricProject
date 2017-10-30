using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Group6.Models
{
    public class CoreValue
    {
        public int ID { get; set; }
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "Person giving the recognition")]
        public string recognizor { get; set; }
        [Display(Name = "Person receiving the recognition")]
        public string recognized { get; set; }
        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balnce = 5

        }

    }
    }