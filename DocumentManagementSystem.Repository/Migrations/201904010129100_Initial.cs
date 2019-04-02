namespace DocumentManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Size = c.Int(nullable: false),
                        Data = c.Binary(),
                        Username = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        LastDownloadDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
