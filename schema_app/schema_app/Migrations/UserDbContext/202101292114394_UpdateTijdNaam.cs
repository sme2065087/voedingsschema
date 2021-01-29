namespace schema_app.Migrations.UserDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTijdNaam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaaltijdUsers", "Eetmoment", c => c.DateTime());
            DropColumn("dbo.MaaltijdUsers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaaltijdUsers", "DateOfBirth", c => c.DateTime());
            DropColumn("dbo.MaaltijdUsers", "Eetmoment");
        }
    }
}
