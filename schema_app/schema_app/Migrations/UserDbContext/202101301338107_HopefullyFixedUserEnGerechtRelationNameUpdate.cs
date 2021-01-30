namespace schema_app.Migrations.UserDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HopefullyFixedUserEnGerechtRelationNameUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaaltijdUsers", "Gerecht_Id", "dbo.Gerechts");
            DropIndex("dbo.MaaltijdUsers", new[] { "Gerecht_Id" });
            RenameColumn(table: "dbo.MaaltijdUsers", name: "AspNetUser_Id", newName: "AspNetUserRefId");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "Gerecht_Id", newName: "GerechtRefId");
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_AspNetUser_Id", newName: "IX_AspNetUserRefId");
            AlterColumn("dbo.MaaltijdUsers", "GerechtRefId", c => c.Int(nullable: true));
            CreateIndex("dbo.MaaltijdUsers", "GerechtRefId");
            AddForeignKey("dbo.MaaltijdUsers", "GerechtRefId", "dbo.Gerechts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaaltijdUsers", "GerechtRefId", "dbo.Gerechts");
            DropIndex("dbo.MaaltijdUsers", new[] { "GerechtRefId" });
            AlterColumn("dbo.MaaltijdUsers", "GerechtRefId", c => c.Int());
            RenameIndex(table: "dbo.MaaltijdUsers", name: "IX_AspNetUserRefId", newName: "IX_AspNetUser_Id");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "GerechtRefId", newName: "Gerecht_Id");
            RenameColumn(table: "dbo.MaaltijdUsers", name: "AspNetUserRefId", newName: "AspNetUser_Id");
            CreateIndex("dbo.MaaltijdUsers", "Gerecht_Id");
            AddForeignKey("dbo.MaaltijdUsers", "Gerecht_Id", "dbo.Gerechts", "Id");
        }
    }
}
