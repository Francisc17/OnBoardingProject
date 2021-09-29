namespace OnBoardingProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correction5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "ProjectManager_Id" });
            AlterColumn("dbo.Projects", "ProjectManager_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ProjectManager_Id");
            AddForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "ProjectManager_Id" });
            AlterColumn("dbo.Projects", "ProjectManager_Id", c => c.Int());
            CreateIndex("dbo.Projects", "ProjectManager_Id");
            AddForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.Users", "Id");
        }
    }
}
