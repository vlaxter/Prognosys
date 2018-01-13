namespace Prognosys.Repository.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Week = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ClientId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectStages", t => t.StageId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Capacity = c.Int(nullable: false),
                        RoldeId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResourceRoles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.ResourceRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Abbreviation = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectStages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectResources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResourceId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StageId", "dbo.ProjectStages");
            DropForeignKey("dbo.ProjectResources", "ProjectId", "dbo.Resources");
            DropForeignKey("dbo.ProjectResources", "ResourceId", "dbo.Projects");
            DropForeignKey("dbo.Resources", "Role_Id", "dbo.ResourceRoles");
            DropForeignKey("dbo.Allocations", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Allocations", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectResources", new[] { "ProjectId" });
            DropIndex("dbo.ProjectResources", new[] { "ResourceId" });
            DropIndex("dbo.Resources", new[] { "Role_Id" });
            DropIndex("dbo.Projects", new[] { "StageId" });
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.Allocations", new[] { "ResourceId" });
            DropIndex("dbo.Allocations", new[] { "ProjectId" });
            DropTable("dbo.ProjectResources");
            DropTable("dbo.ProjectStages");
            DropTable("dbo.ResourceRoles");
            DropTable("dbo.Resources");
            DropTable("dbo.Clients");
            DropTable("dbo.Projects");
            DropTable("dbo.Allocations");
        }
    }
}
