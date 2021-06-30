namespace DbmsSims.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAspnetuserTableToDbmssimsuser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "DbmsSimsUser");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DbmsSimsUser", newName: "AspNetUsers");
        }
    }
}
