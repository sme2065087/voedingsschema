using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace schema_app.Models
{
    public class MaaltijdUser
    {
        public int Id { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public DateTime? Eetmoment { get; set; }
        public Gerecht Gerecht { get; set; }

        public bool voldaan { get; set; }
        public MaaltijdUser()
        {

        }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<MaaltijdUser> MaaltijdUsers { get; set; }
        public UserDbContext() : base("DefaultConnection")
        {
        }
    }
}