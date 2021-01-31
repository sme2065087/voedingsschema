using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace schema_app.Models
{
    public class MaaltijdUser
    {
        public int Id { get; set; }


        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }

        public DateTime? Eetmoment { get; set; }

        public int GerechtRefId { get; set; }

        [ForeignKey("GerechtRefId")]
        public Gerecht Gerecht { get; set; }

        public bool voldaan { get; set; }
        public MaaltijdUser()
        {

        }
    }

    //public class UserDbContext : DbContext
    //{
    //    public DbSet<MaaltijdUser> MaaltijdUsers { get; set; }
    //    public UserDbContext() : base("DefaultConnection")
    //    {
    //    }

    //    public System.Data.Entity.DbSet<schema_app.Models.AspNetUser> AspNetUsers { get; set; }

    //    public System.Data.Entity.DbSet<schema_app.Models.Gerecht> Gerechts { get; set; }
    //}
}