namespace schema_app.Migrations.UserDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIdType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaaltijdUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MaaltijdUsers", new[] { "AspNetUser_Id" });
            DropColumn("dbo.MaaltijdUsers", "AspNetUser_Id");
            /*DropTable("dbo.AspNetUsers");*/
        }
        
        public override void Down()
        {
            /*CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);*/
            
            AddColumn("dbo.MaaltijdUsers", "AspNetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MaaltijdUsers", "AspNetUser_Id");
            AddForeignKey("dbo.MaaltijdUsers", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
