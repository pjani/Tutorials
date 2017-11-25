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
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        RhythmVersion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RhythmVersions", t => t.RhythmVersion_Id)
                .Index(t => t.RhythmVersion_Id);
            
            CreateTable(
                "dbo.RhythmVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Rhythm_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rhythms", t => t.Rhythm_Id)
                .Index(t => t.Rhythm_Id);
            
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
            DropForeignKey("dbo.RhythmVersions", "Rhythm_Id", "dbo.Rhythms");
            DropForeignKey("dbo.Memos", "RhythmVersion_Id", "dbo.RhythmVersions");
            DropIndex("dbo.RhythmVersions", new[] { "Rhythm_Id" });
            DropIndex("dbo.Memos", new[] { "RhythmVersion_Id" });
            DropTable("dbo.Rhythms");
            DropTable("dbo.RhythmVersions");
            DropTable("dbo.Memos");
        }
    }
}
