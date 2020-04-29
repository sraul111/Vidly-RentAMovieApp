namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenere : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Generes (Id,GenereName) values (1,'Comedy')");
            Sql("Insert into Generes (Id,GenereName) values (2,'Action')");
            Sql("Insert into Generes (Id,GenereName) values (3,'Family')");
            Sql("Insert into Generes (Id,GenereName) values (4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
