﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;


namespace TimeFunctioningPatterns.Web.MVC.Models
{
    public class TfplDbContext : DbContext
    {
        public TfplDbContext() : base()
        {
            Database.SetInitializer(new TfplDBInitializer());
        }

        public DbSet<Rhythm> Rhythms { get; set; }
        public DbSet<RhythmVersion> RhythmVariants { get; set; }
        public DbSet<Memo> Memos { get; set; }
        
        public void Seed()
        {
            var memos1 = new List<Memo>()
            {
                new FatBackMemo(){Id = 1, Description = "OK", Created = DateTime.Now, OverallRating = "OK", Tempo = 80 },
                new SnareAndBassMemo(){Id = 2, Description = "Needs work", Created = DateTime.Now, OverallRating = "Good", Tempo = 70 },
            };

            var memos2 = new List<Memo>()
            {
                new FatBackMemo(){Id = 3, Description = "Slow, should practice more",
                    Created = DateTime.Now.AddDays(-5), OverallRating = "OK", Tempo = 55 },
                new FatBackMemo(){Id = 5, Description = "Slow, should practice more",
                    Created = DateTime.Now.AddDays(-3), OverallRating = "OK", Tempo = 55 },
                new FatBackMemo(){Id = 6, Description = "Slow, should practice more",
                    Created = DateTime.Now.AddDays(-1), OverallRating = "OK", Tempo = 55 },
                new SnareAndBassMemo(){Id = 4, Description = "Needs work",
                    Created = DateTime.Now.AddDays(-5), OverallRating = "Not bad", Tempo = 60 },
                new SnareAndBassMemo(){Id = 7, Description = "Needs work",
                    Created = DateTime.Now.AddDays(-3), OverallRating = "Good", Tempo = 70 },
                new SnareAndBassMemo(){Id = 8, Description = "Needs work",
                    Created = DateTime.Now.AddDays(-2), OverallRating = "Good", Tempo = 70 },
                new HiHatMemo(){Id = 9, Description = "Needs work",
                    Created = DateTime.Now, OverallRating = "Good", Tempo = 60 }
            };

            var variants = new List<RhythmVersion>()
            { new RhythmVersion(){
                Id = 1,
                Description = "On closed hihat.",
                Memos = memos1 },
            new RhythmVersion(){
                Id = 2,
                Description = "On ride bell.",
                Memos = memos2 }};

            this.Rhythms.AddOrUpdate(
                new Rhythm()
                {
                    Id = 1,
                    Description = "Quarter notes.",
                    Variants = variants
                },
                new Rhythm()
                {
                    Id = 2,
                    Description = "Eight notes."
                });
        }
    }

    public class TfplDBInitializer : DropCreateDatabaseIfModelChanges<TfplDbContext>
    {
        protected override void Seed(TfplDbContext context)
        {
            context.Seed();

            base.Seed(context);
        }
    }
}