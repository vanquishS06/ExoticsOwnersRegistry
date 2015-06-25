using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExoticsOwnersRegistry.Models
{
    public class ExoticsOwnersRegistryContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ExoticsOwnersRegistryContext() : base("name=ExoticsOwnersRegistryContext")
        {
        }

        public DbSet<Car> cars { get; set; }
        public DbSet<CarDetails> carDetails { get; set; }
        public DbSet<CarMaker> carMakers { get; set; }
        public DbSet<CarModel> carModels { get; set; }
        public DbSet<CarSubModel> carSubModels { get; set; }
        public DbSet<Owner> owners { get; set; }
    }
}
