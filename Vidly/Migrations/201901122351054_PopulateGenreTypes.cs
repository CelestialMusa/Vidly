namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Commedy')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Thriller')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Suspense')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Romance')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Action')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (6, 'Documentary')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (7, 'History')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (8, 'Contemporary')");
            Sql(@"INSERT INTO GenreTypes (Id, Name) VALUES (9, 'Musical')");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM GenreTypes WHERE Id IN (1,2,3,4,5,6,7,8,9)");
        }
    }
}
