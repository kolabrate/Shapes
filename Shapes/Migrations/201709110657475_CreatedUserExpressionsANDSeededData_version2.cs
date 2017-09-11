namespace Shapes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUserExpressionsANDSeededData_version2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserExpressions", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.UserExpressions", "IntentId", "dbo.Intents");
            DropIndex("dbo.UserExpressions", new[] { "IntentId" });
            DropIndex("dbo.UserExpressions", new[] { "EntityId" });
            AddColumn("dbo.Entities", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Intents", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Requests", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserExpressions", "CreatedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserExpressions", "CreatedTime");
            DropColumn("dbo.Requests", "CreatedTime");
            DropColumn("dbo.Intents", "CreatedTime");
            DropColumn("dbo.Entities", "CreatedTime");
            CreateIndex("dbo.UserExpressions", "EntityId");
            CreateIndex("dbo.UserExpressions", "IntentId");
            AddForeignKey("dbo.UserExpressions", "IntentId", "dbo.Intents", "IntentId", cascadeDelete: true);
            AddForeignKey("dbo.UserExpressions", "EntityId", "dbo.Entities", "EntityId", cascadeDelete: true);
        }
    }
}
