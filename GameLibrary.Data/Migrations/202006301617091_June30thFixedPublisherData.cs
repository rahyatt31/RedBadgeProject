namespace GameLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class June30thFixedPublisherData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publisher", "PublisherMostPopularGame", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publisher", "PublisherMostPopularGame", c => c.Int(nullable: false));
        }
    }
}
