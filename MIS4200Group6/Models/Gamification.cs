using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS4200Group6.Models
{
    public class Gamification
    {
        public int gamificationId { get; set; }

        [Display(Name = "RecognizedEmployee")]
        public virtual GiveRecognition GiveRecogniton { get; set; }

        [Display(Name = "Employee")]
        public Guid ID { get; set; }
    }
}