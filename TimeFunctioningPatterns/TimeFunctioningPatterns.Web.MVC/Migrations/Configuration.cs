namespace TimeFunctioningPatterns.Web.MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TimeFunctioningPatterns.Web.MVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TfplDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TfplDbContext ctx)
        {
            ctx.Seed();
        }
    }
}
