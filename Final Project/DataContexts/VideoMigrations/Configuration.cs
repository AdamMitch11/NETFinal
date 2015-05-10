namespace Final_Project.DataContexts.VideoMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Final_Project.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Project.DataContexts.VideoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\VideoMigrations";
        }

        protected override void Seed(Final_Project.DataContexts.VideoDb context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Gaming"},
                new Category { Name = "Comedy"},
                new Category { Name = "Music"},
                new Category { Name = "Autos and Vehicle"},
                new Category { Name = "Education"},
                new Category { Name = "Film and Animation"},
                new Category { Name = "News and Politics"},
                new Category { Name = "People and Blogs"},
                new Category { Name = "Sports"},
                new Category { Name = "Science and Technology"},
                new Category { Name = "Pets and Animals"}
            };

            var authors = new List<Author> {
                new Author {Username = "Logic Breach"},
                new Author {Username = "The Mighty Jingles"}
            };

            //If something goes wrong with the database, try to use "Update-Database -TargetMigration:0"
            //Followed by "update-database -ConfigurationTypeName Final_Project.DataContexts.VideoMigrations.Configuration"
            context.Videos.AddOrUpdate(
                a => a.Title,
                new Video {Title = "World of Tanks | Episode 5: The AFK Strikes Back", Category = categories.Single(g=> g.Name == "Gaming"), Author = authors.Single(a => a.Username == "Logic Breach"), VideoUrl = "wUK2v4C7lAk" }
                );
        }
    }
}
