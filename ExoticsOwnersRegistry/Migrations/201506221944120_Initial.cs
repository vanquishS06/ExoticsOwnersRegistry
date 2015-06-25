namespace ExoticsOwnersRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarDetails",
                c => new
                    {
                        carID = c.Long(nullable: false),
                        originalFuelSystem = c.Int(),
                        currentFuelSystem = c.Int(),
                        originalExteriorColor = c.String(),
                        originalInteriorColor = c.String(),
                        currentExteriorColor = c.String(),
                        currentInteriorColor = c.String(),
                        modelYear = c.DateTime(),
                        productionDate = c.DateTime(),
                        deliveryCountry = c.String(),
                        deliveryDealership = c.String(),
                        currentCountryLocation = c.String(),
                        currentRegionalLocation = c.String(),
                    })
                .PrimaryKey(t => t.carID)
                .ForeignKey("dbo.Cars", t => t.carID)
                .Index(t => t.carID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        carID = c.Long(nullable: false, identity: true),
                        makeID = c.Long(),
                        modelID = c.Long(),
                        subModelID = c.Long(),
                        VIN = c.String(nullable: false),
                        showCaseCarPicture = c.Binary(),
                        ownerID = c.Long(nullable: false),
                        bHideCar = c.Boolean(nullable: false),
                        approvalStatus = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.carID)
                .ForeignKey("dbo.CarMakers", t => t.makeID)
                .ForeignKey("dbo.CarModels", t => t.modelID)
                .ForeignKey("dbo.CarSubModels", t => t.subModelID)
                .ForeignKey("dbo.Owners", t => t.ownerID, cascadeDelete: true)
                .Index(t => t.makeID)
                .Index(t => t.modelID)
                .Index(t => t.subModelID)
                .Index(t => t.ownerID);
            
            CreateTable(
                "dbo.CarMakers",
                c => new
                    {
                        makeID = c.Long(nullable: false, identity: true),
                        makeName = c.String(nullable: false),
                        makeHistory = c.String(),
                    })
                .PrimaryKey(t => t.makeID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        modelID = c.Long(nullable: false, identity: true),
                        modelName = c.String(nullable: false),
                        ModelDescription = c.String(),
                        makeID = c.Long(),
                    })
                .PrimaryKey(t => t.modelID)
                .ForeignKey("dbo.CarMakers", t => t.makeID)
                .Index(t => t.makeID);
            
            CreateTable(
                "dbo.CarSubModels",
                c => new
                    {
                        subModelID = c.Long(nullable: false, identity: true),
                        subModelName = c.String(nullable: false),
                        subModelDescription = c.String(),
                        modelID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.subModelID)
                .ForeignKey("dbo.CarModels", t => t.modelID, cascadeDelete: true)
                .Index(t => t.modelID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ownerID = c.Long(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        Email = c.String(),
                        hideOwner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ownerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarDetails", "carID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "ownerID", "dbo.Owners");
            DropForeignKey("dbo.Cars", "subModelID", "dbo.CarSubModels");
            DropForeignKey("dbo.Cars", "modelID", "dbo.CarModels");
            DropForeignKey("dbo.Cars", "makeID", "dbo.CarMakers");
            DropForeignKey("dbo.CarSubModels", "modelID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "makeID", "dbo.CarMakers");
            DropIndex("dbo.CarSubModels", new[] { "modelID" });
            DropIndex("dbo.CarModels", new[] { "makeID" });
            DropIndex("dbo.Cars", new[] { "ownerID" });
            DropIndex("dbo.Cars", new[] { "subModelID" });
            DropIndex("dbo.Cars", new[] { "modelID" });
            DropIndex("dbo.Cars", new[] { "makeID" });
            DropIndex("dbo.CarDetails", new[] { "carID" });
            DropTable("dbo.Owners");
            DropTable("dbo.CarSubModels");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarMakers");
            DropTable("dbo.Cars");
            DropTable("dbo.CarDetails");
        }
    }
}
