namespace AdvertWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madePricerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adverts", "AdvertText", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adverts", "AdvertText", c => c.String());
        }
    }
}
