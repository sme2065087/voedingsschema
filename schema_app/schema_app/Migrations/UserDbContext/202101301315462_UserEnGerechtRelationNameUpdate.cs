namespace schema_app.Migrations.UserDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEnGerechtRelationNameUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MaaltijdUsers", name: "AspNetUser_Id", newName: "AspNetUser_Id_Id");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "Gerecht_Id", newName: "Gerecht_Id_Id");
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_AspNetUser_Id", newName: "IX_AspNetUser_Id_Id");
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_Gerecht_Id", newName: "IX_Gerecht_Id_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_Gerecht_Id_Id", newName: "IX_Gerecht_Id");
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_AspNetUser_Id_Id", newName: "IX_AspNetUser_Id");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "Gerecht_Id_Id", newName: "Gerecht_Id");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "AspNetUser_Id_Id", newName: "AspNetUser_Id");
        }
    }
}
