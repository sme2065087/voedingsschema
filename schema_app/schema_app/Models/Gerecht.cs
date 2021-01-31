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
        public int Kcal { get; set; }
        public int Suiker { get; set; }
        public int Vet { get; set; }
        public int Verzadigde_vetten { get; set; }
        public int koolhydraten { get; set; }
        public int eiwit { get; set; }
        public ICollection<MaaltijdUser> MaaltijdUsers { get; set; }
        public Gerecht()
        {

        }
    }

    //public class GerechtDb : DbContext
    //{
    //    public DbSet<Gerecht> Gerechten { get; set; }
    //    public GerechtDb() : base("DefaultConnection")
    //    {
    //    }
    //}
}