using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Group6.Models
{
    public class FullName
    {
        public int ID { get; set; }
        public virtual userDetails fullName { get; set; }
    }
}