namespace cloudrest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        LessonTitle = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.LessonId);
            
            CreateTable(
                "dbo.Selections",
                c => new
                    {
                        SelectionId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SelectionId)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 4000),
                        UserRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selections", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Selections", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Selections", "LessonId", "dbo.Lessons");
            DropIndex("dbo.Selections", new[] { "LessonId" });
            DropIndex("dbo.Selections", new[] { "StudentId" });
            DropIndex("dbo.Selections", new[] { "TeacherId" });
            DropTable("dbo.Users");
            DropTable("dbo.Selections");
            DropTable("dbo.Lessons");
        }
    }
}
