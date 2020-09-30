namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "Andra", LastName = "Bakabon" },
                new Friend { FirstName = "Bagus", LastName = "Sukaraja" },
                new Friend { FirstName = "Canda", LastName = "Bebong" },
                new Friend { FirstName = "Denis", LastName = "Vina" }
            );
            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "F#" },
                new ProgrammingLanguage { Name = "Java" },
                new ProgrammingLanguage { Name = "Python" });

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+49 123456578", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(
                m => m.Title,
                new Meeting
                {
                    Title = "Watching Soccer",
                    DateFrom = new DateTime(2018, 5, 26),
                    DateTo = new DateTime(2018, 5, 26),
                    Friends = new List<Friend>
                    {
                        context.Friends.Single(f=> f.FirstName == "Julia" && f.LastName == "Bakabon"),
                        context.Friends.Single(f=> f.FirstName == "Bagus" && f.LastName == "Sukaraja"),

                    }
                });
        }
    }
}
