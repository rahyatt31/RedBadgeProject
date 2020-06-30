namespace GameLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class June30thFixedForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Console", "GameID", "dbo.Game");
            DropForeignKey("dbo.Publisher", "GameID", "dbo.Game");
            DropIndex("dbo.Console", new[] { "GameID" });
            DropIndex("dbo.Publisher", new[] { "GameID" });
            RenameColumn(table: "dbo.Console", name: "GameID", newName: "Game_GameID");
            RenameColumn(table: "dbo.Publisher", name: "GameID", newName: "Game_GameID");
            AddColumn("dbo.Game", "ConsoleID", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "PublisherID", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "Publisher_PublisherID", c => c.Int());
            AddColumn("dbo.Game", "Console_ConsoleID", c => c.Int());
            AlterColumn("dbo.Console", "Game_GameID", c => c.Int());
            AlterColumn("dbo.Publisher", "Game_GameID", c => c.Int());
            CreateIndex("dbo.Console", "Game_GameID");
            CreateIndex("dbo.Game", "ConsoleID");
            CreateIndex("dbo.Game", "PublisherID");
            CreateIndex("dbo.Game", "Publisher_PublisherID");
            CreateIndex("dbo.Game", "Console_ConsoleID");
            CreateIndex("dbo.Publisher", "Game_GameID");
            AddForeignKey("dbo.Game", "ConsoleID", "dbo.Console", "ConsoleID", cascadeDelete: true);
            AddForeignKey("dbo.Game", "Publisher_PublisherID", "dbo.Publisher", "PublisherID");
            AddForeignKey("dbo.Game", "PublisherID", "dbo.Publisher", "PublisherID", cascadeDelete: true);
            AddForeignKey("dbo.Game", "Console_ConsoleID", "dbo.Console", "ConsoleID");
            AddForeignKey("dbo.Console", "Game_GameID", "dbo.Game", "GameID");
            AddForeignKey("dbo.Publisher", "Game_GameID", "dbo.Game", "GameID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publisher", "Game_GameID", "dbo.Game");
            DropForeignKey("dbo.Console", "Game_GameID", "dbo.Game");
            DropForeignKey("dbo.Game", "Console_ConsoleID", "dbo.Console");
            DropForeignKey("dbo.Game", "PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Game", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Game", "ConsoleID", "dbo.Console");
            DropIndex("dbo.Publisher", new[] { "Game_GameID" });
            DropIndex("dbo.Game", new[] { "Console_ConsoleID" });
            DropIndex("dbo.Game", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.Game", new[] { "PublisherID" });
            DropIndex("dbo.Game", new[] { "ConsoleID" });
            DropIndex("dbo.Console", new[] { "Game_GameID" });
            AlterColumn("dbo.Publisher", "Game_GameID", c => c.Int(nullable: false));
            AlterColumn("dbo.Console", "Game_GameID", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "Console_ConsoleID");
            DropColumn("dbo.Game", "Publisher_PublisherID");
            DropColumn("dbo.Game", "PublisherID");
            DropColumn("dbo.Game", "ConsoleID");
            RenameColumn(table: "dbo.Publisher", name: "Game_GameID", newName: "GameID");
            RenameColumn(table: "dbo.Console", name: "Game_GameID", newName: "GameID");
            CreateIndex("dbo.Publisher", "GameID");
            CreateIndex("dbo.Console", "GameID");
            AddForeignKey("dbo.Publisher", "GameID", "dbo.Game", "GameID", cascadeDelete: true);
            AddForeignKey("dbo.Console", "GameID", "dbo.Game", "GameID", cascadeDelete: true);
        }
    }
}
