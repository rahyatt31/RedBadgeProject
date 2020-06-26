namespace GameLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class June26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameMultiplayer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "GameOnline", c => c.Boolean(nullable: false));
            DropColumn("dbo.Game", "Multiplayer");
            DropColumn("dbo.Game", "Online");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Online", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "Multiplayer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Game", "GameOnline");
            DropColumn("dbo.Game", "GameMultiplayer");
        }
    }
}
