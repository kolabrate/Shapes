namespace Shapes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        EntityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId);
            
            CreateTable(
                "dbo.Intents",
                c => new
                    {
                        IntentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Synonyms = c.String(),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IntentId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        ModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
            DropTable("dbo.Intents");
            DropTable("dbo.Entities");
        }
    }
}
