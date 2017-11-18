namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFiledError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Errors", "StackTrace", c => c.String());
            AddColumn("dbo.Errors", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Errors", "StackTrac");
            DropColumn("dbo.Errors", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Errors", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Errors", "StackTrac", c => c.String());
            DropColumn("dbo.Errors", "CreatedDate");
            DropColumn("dbo.Errors", "StackTrace");
        }
    }
}
