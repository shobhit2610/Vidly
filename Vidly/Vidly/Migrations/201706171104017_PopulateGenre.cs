namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Name) values ('Comedy') ");
            Sql("Insert into Genres(Name) values('Action') ");
            Sql("Insert into Genres(Name) values('Family') ");
            Sql("Insert into Genres(Name) values('Romance') ");
        }
        
        public override void Down()
        {
        }
    }
}
