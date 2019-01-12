namespace IvyNotesv2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diapers",
                c => new
                    {
                        DiaperID = c.Int(nullable: false, identity: true),
                        DiaperDT = c.DateTime(nullable: false),
                        DiaperHasPoop = c.Boolean(nullable: false),
                        DiaperHasPee = c.Boolean(nullable: false),
                        DiaperComments = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.DiaperID);
            
            CreateTable(
                "dbo.FeedingBottles",
                c => new
                    {
                        FeedingBottleID = c.Int(nullable: false, identity: true),
                        FeedingBottleDT = c.DateTime(nullable: false),
                        FeedingBottleType = c.String(maxLength: 4000),
                        FeedingBottleComments = c.String(maxLength: 4000),
                        FeedingBottleQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedingBottleID);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        MeasureID = c.Int(nullable: false, identity: true),
                        MeasureDT = c.DateTime(nullable: false),
                        MeasureComments = c.String(maxLength: 4000),
                        MeasureValueHeight = c.Int(nullable: false),
                        MeasureValueWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeasureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Measures");
            DropTable("dbo.FeedingBottles");
            DropTable("dbo.Diapers");
        }
    }
}
