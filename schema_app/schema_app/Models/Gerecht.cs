using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace schema_app.Models
{
    public class Gerecht
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Gerecht()
        {

        }
    }

    public class GerechtDb : DbContext
    {
        public DbSet<Gerecht> Gerechten { get; set; }
        public GerechtDb() : base("DefaultConnection")
        {
        }
    }
}