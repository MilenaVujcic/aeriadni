namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_NumberCombiation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "FormatedNumberCombination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "FormatedNumberCombination");
        }
    }
}
