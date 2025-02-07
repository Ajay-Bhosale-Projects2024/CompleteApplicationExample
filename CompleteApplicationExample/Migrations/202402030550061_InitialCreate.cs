namespace CompleteApplicationExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        MonthlyInc = c.Decimal(nullable: false, storeType: "smallmoney"),
                        YearlyInc = c.Decimal(nullable: false, storeType: "money"),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 10, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100, unicode: false),
                        Attachment = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 16),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
            DropTable("dbo.Employees");
        }
    }
}
