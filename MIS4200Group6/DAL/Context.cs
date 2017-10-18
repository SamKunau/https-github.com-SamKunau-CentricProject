using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MIS4200Group6.Models;
using System.Data.Entity;

namespace MIS4200Group6.DAL
{
    public class CentricContext : DbContext
    {
        public CentricContext() : base ("name=csCentric")
        {
        }

        public DbSet<userDetails> UserDetails { get; set; }
    }
}