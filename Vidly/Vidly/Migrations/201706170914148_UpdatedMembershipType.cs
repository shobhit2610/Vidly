namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update Membershiptypes set Name = 'Pay as You Go' where Id =1");
            Sql("Update Membershiptypes set Name = 'Monthly' where Id =2");
            Sql("Update Membershiptypes set Name = 'Quaterly' where Id =3");
            Sql("Update Membershiptypes set Name = 'Annually' where Id =4");
        }
        
        public override void Down()
        {
        }
    }
}
