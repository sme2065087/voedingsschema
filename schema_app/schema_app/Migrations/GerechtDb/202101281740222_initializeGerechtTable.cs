namespace schema_app.Migrations.GerechtDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeGerechtTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gerechts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Kcal = c.Int(nullable: false),
                        Suiker = c.Int(nullable: false),
                        Vet = c.Int(nullable: false),
                        Verzadigde_vetten = c.Int(nullable: false),
                        koolhydraten = c.Int(nullable: false),
                        eiwit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gerechts");
        }
    }
}
