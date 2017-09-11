using Shapes.Models.Parser;

namespace Shapes
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    public class ShapeDbContext : DbContext
    {
        //The default connection string points to local shapes mdf file.
        public ShapeDbContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ShapeDbContext, Migrations.Configuration>(
                    "DefaultConnection"));
        }
        public virtual DbSet<Entity>  Entities { get; set; }
        public virtual DbSet<Intent>  Intents { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<UserExpression> UserExpressions { get; set; }
    }

    
}