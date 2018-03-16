namespace TimeFunctioningPatterns.Web.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 200),
                        Created = c.DateTime(nullable: false),
                        Tempo = c.Int(nullable: false),
                        OverallRating = c.String(nullable: false, maxLength: 30),
                        RhythmVersionId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RhythmVersions", t => t.RhythmVersionId, cascadeDelete: true)
                .Index(t => t.RhythmVersionId);
            
            CreateTable(
                "dbo.RhythmVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 2000),
                        RhythmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rhythms", t => t.RhythmId, cascadeDelete: true)
                .Index(t => t.RhythmId);
            
            CreateTable(
                "dbo.Rhythms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RhythmVersions", "RhythmId", "dbo.Rhythms");
            DropForeignKey("dbo.Memos", "RhythmVersionId", "dbo.RhythmVersions");
            DropIndex("dbo.RhythmVersions", new[] { "RhythmId" });
            DropIndex("dbo.Memos", new[] { "RhythmVersionId" });
            DropTable("dbo.Rhythms");
            DropTable("dbo.RhythmVersions");
            DropTable("dbo.Memos");
        }
    }
}
