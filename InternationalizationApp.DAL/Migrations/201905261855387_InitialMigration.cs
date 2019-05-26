namespace InternationalizationApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Repositories",
                c => new
                {
                    RepositoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Link = c.String(),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.RepositoryId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Email = c.String(),
                    Login = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Repositories", "UserId", "dbo.Users");
            DropIndex("dbo.Repositories", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Repositories");
        }
    }
}
