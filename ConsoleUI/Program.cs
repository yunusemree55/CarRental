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

            //int i = 1;
            //foreach (var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine("{0}){1}", i, car.Name);
            //    i++;
            //}




            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName);
            //}

            //-------------------------------------------------------------------------------------------------------------------------------------

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer() { Id = 1, CompanyName = "Mobi Cosre", UserId = 1 };
            Customer customer2 = new Customer() { Id = 2, CompanyName = "Bori Proge", UserId = 2 };
            Customer customer3 = new Customer() { Id = 3, CompanyName = "Slow Coop", UserId = 3 };
            Customer customer4 = new Customer() { Id = 4, CompanyName = "Slew Pros", UserId = 4 };
            Customer customer5 = new Customer() { Id = 5, CompanyName = "Bran Smon", UserId = 5 };
            Customer customer6 = new Customer() { Id = 6, CompanyName = "Serv Cpo", UserId = 6 };

            List<Customer> customers = new List<Customer> { customer1,customer2,customer3,customer4, customer5, customer6 };

            //foreach (var customer in customers)
            //{
            //    customerManager.Add(customer);
            //}

            //-------------------------------------------------------------------------------------------------------------------------------------

            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User() { Id = 1, FirstName = "Yunus Emre", LastName = "Çiçek", Email = "abcde@hotmail.com", Password = "19730abc" };
            User user2 = new User() { Id = 2, FirstName = "Enes Emir", LastName = "Çiçek", Email = "edcba@hotmail.com", Password = "14320akc" };
            User user3 = new User() { Id = 3, FirstName = "Furkan", LastName = "Acar", Email = "vnedj@hotmail.com", Password = "19730ame" };
            User user4 = new User() { Id = 4, FirstName = "Mert Ali", LastName = "Işık", Email = "vkdfoe@hotmail.com", Password = "12730abc" };
            User user5 = new User() { Id = 5, FirstName = "Raymond", LastName = "Reddington", Email = "pocvs@hotmail.com", Password = "76230ldc" };
            User user6 = new User() { Id = 6, FirstName = "Dembe", LastName = "Zuma", Email = "ovjser@hotmail.com", Password = "16730bpc" };

            List<User> users = new List<User> { user1, user2, user3, user4, user5, user6 };

            //foreach (var user in users)
            //{
            //    userManager.Add(user);
            //}


            //-------------------------------------------------------------------------------------------------------------------------------------

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental() { Id = 1, CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 02, 20) };
            Rental rental2 = new Rental() { Id = 2, CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 02, 22) };
            Rental rental3 = new Rental() { Id = 3, CarId = 3, CustomerId = 1, RentDate = new DateTime(2021, 03, 14) };
            Rental rental4 = new Rental() { Id = 4, CarId = 4, CustomerId = 5, RentDate = new DateTime(2021, 03, 12) };
            Rental rental5 = new Rental() { Id = 5, CarId = 5, CustomerId = 6, RentDate = new DateTime(2021, 05, 10) };
            Rental rental6 = new Rental() { Id = 6, CarId = 6, CustomerId = 6, RentDate = new DateTime(2021, 05, 10) };

            List<Rental> rentals = new List<Rental> { rental1, rental2, rental3, rental4, rental5, rental6 };

            //foreach (var rental in rentals)
            //{
            //    rentalManager.Add(rental);
            //}
































        }
    }
}
