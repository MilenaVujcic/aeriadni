namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Name_Properties : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Participants");
            DropColumn("dbo.Participants", "Id");
            AddColumn("dbo.Participants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Participants", "Id");
            DropColumn("dbo.Participants", "FirstName");
            DropColumn("dbo.Participants", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "LastName", c => c.String());
            AddColumn("dbo.Participants", "FirstName", c => c.String());
            DropPrimaryKey("dbo.Participants");
            AlterColumn("dbo.Participants", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Participants", "Id");
        }
    }
}
