using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MIS4200Group6.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MIS4200Group6.DAL
{
    public class CentricContext : DbContext
    {
        public CentricContext() : base ("name=csCentric")
        {
        }

        public DbSet<userDetails> UserDetails { get; set; }
        public DbSet<Recog2> Recog2 { get; set; }
        public System.Data.Entity.DbSet<MIS4200Group6.Models.CoreValue> CoreValues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}