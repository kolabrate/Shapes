namespace Shapes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUserExpressionsANDSeededData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserExpressions",
                c => new
                    {
                        UserExpressionId = c.Int(nullable: false, identity: true),
                        Expression = c.String(),
                        IntentId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserExpressionId)
                .ForeignKey("dbo.Entities", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Intents", t => t.IntentId, cascadeDelete: true)
                .Index(t => t.IntentId)
                .Index(t => t.EntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExpressions", "IntentId", "dbo.Intents");
            DropForeignKey("dbo.UserExpressions", "EntityId", "dbo.Entities");
            DropIndex("dbo.UserExpressions", new[] { "EntityId" });
            DropIndex("dbo.UserExpressions", new[] { "IntentId" });
            DropTable("dbo.UserExpressions");
        }
    }
}
