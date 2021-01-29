namespace schema_app.Migrations.GerechtDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeyupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaaltijdUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Eetmoment = c.DateTime(),
                        voldaan = c.Boolean(nullable: false),
                        AspNetUser_Id = c.String(maxLength: 128),
                        Gerecht_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .ForeignKey("dbo.Gerechts", t => t.Gerecht_Id)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.Gerecht_Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaaltijdUsers", "Gerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.MaaltijdUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MaaltijdUsers", new[] { "Gerecht_Id" });
            DropIndex("dbo.MaaltijdUsers", new[] { "AspNetUser_Id" });
            //DropTable("dbo.AspNetUsers");
            DropTable("dbo.MaaltijdUsers");
        }
    }
}
