using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace schema_app.Models
{
    public class Maaltijd
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Maaltijd()
        {

        }
    }

    public class MaaltijdDb : DbContext
    {
        public DbSet<Maaltijd> Maaltijden { get; set; }
        public MaaltijdDb() : base("DefaultConnection")
        {
        }
    }
}