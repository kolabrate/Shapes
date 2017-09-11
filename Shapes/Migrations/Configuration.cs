using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Shapes.Models.Parser;

namespace Shapes.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShapeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShapeDbContext context)
        {
           //Fill Entities
           context.Entities.AddOrUpdate(x => x.EntityId,new Entity() {Name="circle",ModifiedTime = DateTime.UtcNow,CreatedTime = DateTime.UtcNow},
               new Entity() { Name = "rectangle", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "square", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "octagon", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "isoceles triangle", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "equilateral triangle", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "scalene triangle", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow },
               new Entity() { Name = "oval", ModifiedTime = DateTime.UtcNow, CreatedTime = DateTime.UtcNow }
               );

            //Fill Intents
            context.Intents.AddOrUpdate(x=> x.IntentId, new Intent() {Name="draw",Synonyms = "draw|create|sketch|illustrate|outline",CreatedTime = DateTime.UtcNow,ModifiedTime = DateTime.UtcNow});

           //Fill user expressions
           context.UserExpressions.AddOrUpdate(x=> x.UserExpressionId,new UserExpression() {Expression = "draw a circle with radius 100px",
               EntityId = context.Entities.Where(x => x.Name == "circle").Select(x => x.EntityId).FirstOrDefault(),
               IntentId = context.Intents.Where(x => x.Name == "draw").Select(x => x.IntentId).FirstOrDefault(),
               ModifiedTime = DateTime.UtcNow,
               CreatedTime = DateTime.UtcNow
           });
       
        }
    }
}
