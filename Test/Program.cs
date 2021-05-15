using Bussiness.Abstract;
using Bussiness.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                List<object> managers = new List<object>() {
                    new ColorManager(new EfColorDal()) ,
                    new BrandManager(new EfBrandDal()) ,
                    new CarManager(new EfCarDal())
                };

                int counter = 0;
                foreach (var manager in managers)
                {
                    Console.WriteLine(++counter + " - " + manager.GetType().Name);
                }

                Console.Write("\n\n___Select Table: ");
                int selectedManagerIndex;
                try
                {
                    selectedManagerIndex = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());

                }
                catch (Exception)
                {
                    continue;
                }
                object selectedManager = managers[selectedManagerIndex - 1];
                switch (selectedManagerIndex)
                {
                    case 1:
                        writeAll((IService<Color>)selectedManager);

                        Console.Write("Do you want to create new entry (y/n): ");
                        if (Console.ReadKey().KeyChar == 'y')
                            SetEntity((IService<Color>)selectedManager);
                        break;
                    case 2:
                        writeAll((IService<Brand>)selectedManager);

                        Console.Write("Do you want to create new entry (y/n): ");
                        if (Console.ReadKey().KeyChar == 'y')
                            SetEntity((IService<Brand>)selectedManager);
                        break;
                    case 3:
                        writeAll((IService<Car>)selectedManager);
                        Console.WriteLine("=================================");
                        foreach (var carInfo in ((CarManager)selectedManager).GetCarInfos())
                        {
                            Console.WriteLine($"Car Description: {carInfo.CarName}");
                            Console.WriteLine($"BrandName: {carInfo.BrandName}");
                            Console.WriteLine($"ColorName: {carInfo.ColorName}");
                            Console.WriteLine($"DailyPrice: {carInfo.DailyPrice}");


                        }
                        Console.WriteLine("=================================");
                        Console.Write("Do you want to create new entry (y/n): ");
                        if (Console.ReadKey().KeyChar == 'y')
                            SetEntity((IService<Car>)selectedManager);
                        break;
                    default:
                        continue;
                }



                Console.Write("\n\n________________Continue (c), Quit(q):");

                if (Console.ReadKey().KeyChar == 'q') break;
                else Console.Clear();
            }
        }

        private static void SetEntity<TType>(IService<TType> manager) where TType : class, IEntity, new()
        {
            Console.Clear();
            Console.WriteLine("\n\n_" + typeof(TType) + " New Enty:___________________________\n\n");
            TType entity = new TType();
            bool isUpdate = false;
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                
                Console.Write(propertyInfo.Name + ": ");
                var val = Console.ReadLine();
                if (propertyInfo.Name.Equals("Id"))
                {
                    isUpdate = manager.GetById(Convert.ToInt32(val)) != null;
                    if (!isUpdate) continue;
                }
                entity.GetType().GetProperty(propertyInfo.Name).SetValue(entity, Convert.ChangeType(val, propertyInfo.PropertyType));
            }
            try
            {
                if (isUpdate)
                    manager.Update(entity);
                else
                    manager.Add(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kayıt işlemi gerçekleşmedi. Nedeni: {ex.Message}");
            }
        }

        private static void writeAll<TType>(IService<TType> manager) where TType : class, IEntity, new()
        {
            Console.WriteLine("\n\n_" + typeof(TType) + " LIST:___________________________");
            foreach (var oEntity in manager.GetAll())
            {
                Console.WriteLine("_____________________________");
                foreach (var propertyInfo in oEntity.GetType().GetProperties())
                {
                    Console.WriteLine(propertyInfo.Name + ": " + propertyInfo.GetValue(oEntity));
                }
            }
        }
    }
}
