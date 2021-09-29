namespace OnBoardingProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correction3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "TaskResponsible_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "TaskResponsible_Id" });
            AlterColumn("dbo.Tasks", "TaskResponsible_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "TaskResponsible_Id");
            AddForeignKey("dbo.Tasks", "TaskResponsible_Id", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskResponsible_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "TaskResponsible_Id" });
            AlterColumn("dbo.Tasks", "TaskResponsible_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "TaskResponsible_Id");
            AddForeignKey("dbo.Tasks", "TaskResponsible_Id", "dbo.Users", "Id");
        }
    }
}
