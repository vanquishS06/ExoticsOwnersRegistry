using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace ExoticsOwnersRegistry.Models
{
    // This class seeds the database for unit testing.
    public class RegistryDataContextInitializer : DropCreateDatabaseAlways<ExoticsOwnersRegistryContext>
    {
        // Log SQL via System.Diagnostics
        //Database.Log = l => Debug.WriteLine(l);

        // Override seed for dbase population
        protected override void Seed(ExoticsOwnersRegistryContext context)
        {
#if DEBUG    
            try
            {
                // Populate Car Makers
                context.carMakers.Add(CreateCarMakerAstonMartin(context));
                context.carMakers.Add(CreateCarMakerLamborghini(context));
                context.SaveChanges();

                // Populate cars
                context.cars.Add(CreateCar(context, "021444", "Aston Martin", "Vanquish", "S", true));
                context.cars.Add(CreateCar(context, "FLA1992", "Lamborghini", "Countach", "lp400", false));
                context.SaveChanges();
            }

            catch(Exception ex)
            {
                throw;
            }
#endif
        }

        #region Helpers
        // Initialize some cars
        private Car CreateCar(ExoticsOwnersRegistryContext context, string vin, string make, string model, string submodel, bool hide)
        {
            Car car = null;
            try
            { 
                // Create a car
                if (!string.IsNullOrEmpty(make))
                {
                    car = new Car();
                    car.carMaker = context.carMakers.Where(m => m.makeName == make).ToList().FirstOrDefault();
                    if (!string.IsNullOrEmpty(model))
                        car.carModel = context.carModels.Where(m => m.modelName.Contains(model) && car.carMaker.makeID == m.makeID).FirstOrDefault();
                    if (!string.IsNullOrEmpty(submodel))
                        car.carSubModel = context.carSubModels.Where(s => s.subModelName.Contains(submodel) && car.carModel.modelID == s.modelID).FirstOrDefault();
                }
            } 

            catch (Exception ex)
            {
                //TODO
                throw;
            }
            return car;
        }

        // Create the Lamborghini make in Database
        private CarMaker CreateCarMakerLamborghini(ExoticsOwnersRegistryContext context)
        {
            CarMaker carMaker = new CarMaker();
            carMaker.makeName = "Lamborghini";
            carMaker.makeHistory = "Lamborghini History";

            carMaker.modelList = new List<CarModel>();

            // Add Countach model
            CarModel cm = AddCarModel(context, "Countach", "Countach description");
            {
                cm.subModelList = new List<CarSubModel>();
                cm.subModelList.Add(AddCarSubModel(context, "lp400", "lp400 description"));
                cm.subModelList.Add(AddCarSubModel(context, "400 S1", "400 S1 description"));
                cm.subModelList.Add(AddCarSubModel(context, "400 S2", "400 S2 description"));
                cm.subModelList.Add(AddCarSubModel(context, "400 S3", "400 S3 description"));
                cm.subModelList.Add(AddCarSubModel(context, "5000 S", "5000 S description"));
                cm.subModelList.Add(AddCarSubModel(context, "5000 QV", "5000 QV description"));
                cm.subModelList.Add(AddCarSubModel(context, "Anniversary", "Anniversary description"));
            }
            carMaker.modelList.Add(cm);

            // Add Muira model
            CarModel cm1 = AddCarModel(context, "Muira", "Muira description");
            {
                cm1.subModelList = new List<CarSubModel>();
                cm1.subModelList.Add(AddCarSubModel(context, "Base", "Muira description"));
                cm1.subModelList.Add(AddCarSubModel(context, "S", "Muira S description"));
                cm1.subModelList.Add(AddCarSubModel(context, "SV", "Muira SV description"));
            }
            carMaker.modelList.Add(cm1);

            return carMaker;

            //return new CarMaker()
            //{
            //    makeName = "Lamborghini",
            //    makeHistory = "Lamborghini History",
            //    modelList = new List<CarModel>
            //    {
            //        context.carModels.Add(InitModelLamboCountach(context)),
            //        context.carModels.Add(InitModelLamboMuira(context))
            //    }
            //};
        }

        // Create the Lamborghini make in Database
        private CarMaker CreateCarMakerAstonMartin(ExoticsOwnersRegistryContext context)
        {
            CarMaker carMaker = new CarMaker();
            carMaker.makeName = "Aston Martin";
            carMaker.makeHistory = "Aston History";

                //context.carModels.Add(InitModelAstonVanquish(context)),
                //context.carModels.Add(InitModelAstonRapide(context)),
            carMaker.modelList = new List<CarModel>();

            // Add Vanquish model
            CarModel cm = AddCarModel(context, "V12 Vanquish", "v12 Vanquish description");
            {
            cm.subModelList = new List<CarSubModel>();
            cm.subModelList.Add(AddCarSubModel(context, "Base", "Vanquish Base description"));
            cm.subModelList.Add(AddCarSubModel(context, "SDP", "Vanquish SDP description"));
            cm.subModelList.Add(AddCarSubModel(context, "S 1st serie", "Vanquish S 1st serie description"));
            cm.subModelList.Add(AddCarSubModel(context, "S 2nd serie", "Vanquish S 2nd serie description"));
            cm.subModelList.Add(AddCarSubModel(context, "Ultimate", "Vanquish Ultimate description"));
            }
            carMaker.modelList.Add(cm);

            // Add Rapide model
            CarModel cm1 = AddCarModel(context, "Rapide", "Rapide description");
            {
                cm1.subModelList = new List<CarSubModel>();
                cm1.subModelList.Add(AddCarSubModel(context, "Base", "Rapide Base description"));
                cm1.subModelList.Add(AddCarSubModel(context, "S", "Rapide S description"));
            }
            carMaker.modelList.Add(cm1);

            return carMaker;
        }

        // Create the Aston Vanquish model in Database
        //private CarModel InitModelAstonVanquish(RegistryContext context)
        //{
        //    return new CarModel()
        //    {
        //        modelName = "V12 Vanquish",
        //        ModelDescription = "v12 Vanquish description",
        //        subModelList = new List<CarSubModel>
        //        {
        //            context.carSubModels.Add(AddCarSubModel(context, "Base", "Vanquish Base description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "SDP", "Vanquish SDP description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "S 1st serie", "Vanquish S 1st serie description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "S 2nd serie", "Vanquish S 2nd serie description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "Ultimate", "Vanquish Ultimate description"))
        //        }
        //    };
        //}

        //// Create the Aston Vanquish model in Database
        //private CarModel InitModelAstonRapide(RegistryContext context)
        //{
        //    return new CarModel()
        //    {
        //        modelName = "Rapide",
        //        ModelDescription = "Rapide description",
        //        subModelList = new List<CarSubModel>
        //        {
        //            context.carSubModels.Add(AddCarSubModel(context, "Base", "Rapide Base description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "S", "Rapide S description"))
        //        }
        //    };
        //}

        // Create the Lamborghini Countach model in Database
        //private CarModel InitModelLamboCountach(RegistryContext context)
        //{
        //    return new CarModel()
        //    {
        //        modelName = "Countach",
        //        ModelDescription = "Countach description",
        //        // Populate sub-models

        //        subModelList = new List<CarSubModel>
        //        {
        //            context.carSubModels.Add(AddCarSubModel(context, "lp400", "lp400 description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "400 S1", "400 S1 description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "400 S2", "400 S2 description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "400 S3", "400 S3 description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "5000 S", "5000 S description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "5000 QV", "5000 QV description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "Anniversary", "Anniversary description"))
        //        }
        //    };
        //}

        // Create the Lamborghini Muira model in Database
        //private CarModel InitModelLamboMuira(RegistryContext context)
        //{
        //    return new CarModel()
        //    {
        //        modelName = "Muira",
        //        ModelDescription = "Muira description",
        //        // Populate sub-models
        //        subModelList = new List<CarSubModel>
        //        {
        //            context.carSubModels.Add(AddCarSubModel(context, "P400", "P400 description")),
        //            context.carSubModels.Add(AddCarSubModel(context, "S", "S description"))
        //        }
        //    };
        //}

        // Add a car Maker
        // Optionall a model, submodel and description can be added
        //TODO genericize all these helpers
        private CarMaker AddCarMaker(ExoticsOwnersRegistryContext context, string make,
                                        string model=null,
                                        string modelDescription=null,
                                        string subModel=null,
                                        string subModelDescription=null)
        {
            CarMaker carMaker = null;

            if (!String.IsNullOrEmpty(make))
            {
                carMaker = new CarMaker();
                carMaker.makeName = make;
            }
            //TODO
            return carMaker;
        }

        // Add a car model
        //TODO need a make to select
        private CarModel AddCarModel(ExoticsOwnersRegistryContext context, string model, string description)
        {
            CarModel carModel = null;

            if (!String.IsNullOrEmpty(model))
            {
                carModel = new CarModel();
                carModel.modelName = model;
            }

            if (!String.IsNullOrEmpty(description))
                carModel.ModelDescription = description;

            return carModel;
        }

        // Add a car sub-model
        // TODO need a model to select
        private CarSubModel AddCarSubModel(ExoticsOwnersRegistryContext context, string subModel, string subModelDescription)
        {
            CarSubModel carSubModel = null;

            if (!String.IsNullOrEmpty(subModel))
            {
                carSubModel = new CarSubModel();
                carSubModel.subModelName = subModel;
            }

            if (!String.IsNullOrEmpty(subModelDescription))
                carSubModel.subModelDescription = subModelDescription;

            return carSubModel;
        }
        #endregion helpers
    }
}