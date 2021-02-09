using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { BrandId = 1, ColorId = 2, Name = "Ford July", ModelYear = 2009, DailyPrice = 650 };
            Car car2 = new Car() { BrandId = 1, ColorId = 3, Name = "Ford Purge", ModelYear = 2011, DailyPrice = 850 };
            Car car3 = new Car() { BrandId = 2, ColorId = 1, Name = "BMW Reon", ModelYear = 2012, DailyPrice = 900 };
            Car car4 = new Car() { BrandId = 2, ColorId = 5, Name = "BMW Plus", ModelYear = 2011, DailyPrice = 750 };
            Car car5 = new Car() { BrandId = 3, ColorId = 4, Name = "Toyota Condinal", ModelYear = 2007, DailyPrice = 600 };
            Car car6 = new Car() { BrandId = 3, ColorId = 6, Name = "Toyota Logic", ModelYear = 2008, DailyPrice = 500 };

            List<Car> cars = new List<Car>() { car1, car2, car3, car4, car5, car6 };

            //foreach (var car in cars)
            //{
            //    carManager.Add(car);          //Arabalar db'ye ekleme işlemi yapıldı.
            //}

            //-------------------------------------------------------------------------------------------------------------------------------------


            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand() { Id = 1, Name = "Ford" };
            Brand brand2 = new Brand() { Id = 2, Name = "BMW" };
            Brand brand3 = new Brand() { Id = 3, Name = "Toyota" };

            List<Brand> brands = new List<Brand>() { brand1, brand2, brand3 };

            //foreach (var brand in brands)
            //{
            //    brandManager.Add(brand);     //Markalar db'ye ekleme işlemi yapıldı.
            //}



            //-------------------------------------------------------------------------------------------------------------------------------------

            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color() { Id = 1, Name = "Siyah" };
            Color color2 = new Color() { Id = 2, Name = "Beyaz" };
            Color color3 = new Color() { Id = 3, Name = "Mavi" };
            Color color4 = new Color() { Id = 4, Name = "Yeşil" };
            Color color5 = new Color() { Id = 5, Name = "Gri" };
            Color color6 = new Color() { Id = 6, Name = "Kırmızı" };

            List<Color> colors = new List<Color>() { color1, color2, color3, color4, color5, color6 };

            //foreach (var color in colors)
            //{
            //    colorManager.Add(color);          //Renkler db'ye aktarıldı.
            //}

            Color color7 = new Color() { Id = 7, Name = "Pembe" };

            //colorManager.Add(color7);   // Renk db'ye aktarıldı.
            //colorManager.Delete(color7);   // Renk db'den silindi.

            int i = 1;
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}){1} ===> {2} TL", i, car.Name, car.DailyPrice);
                i++;
            }




            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName);
            }

            































        }
    }
}
