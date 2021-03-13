using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        // Car Messages //
        public static string CarAdded = "Araba başarıyla eklendi";
        public static string InvalidCar = "Araba ekleme başarısız";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string CarUpdated = "Araba bilgileri başarıyla güncellendi";
        public static string CarListed = "Arabalar listelendi";

        // Brand Messages //
        public static string BrandAdded = "Marka başarıyla eklendi";
        public static string BrandDeleted = "Marka başarıyla silindi";
        public static string BrandUpdated = "Marka bilgileri güncellendi";
        

        // Car Messages //
        public static string ColorUpdated = "Renk bilgileri güncellendi";
        public static string ColorAdded= "Renk başarıyla eklendi";
        public static string ColorDeleted = "Renk başarıyla silindi";
        public static string ColorListed = "Renkler listelendi";

        // User Messages //
        public static string UserAdded = "Kullanıcı başarıyla eklendi";
        public static string UserPasswordUnSuccesfull = "Kullanıcı şifresi en az 5 karakter içermelidir ";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string UserUpdated = "Kullanıcı bilgileri başarıyla güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";

        // Customer Messages //
        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CustomersListed = "Müşteriler listelendi ";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";

        //Rental Messages //
        public static string InvalidRent = "Kiralanmak istenilen araba mevcut değildir!";
        public static string RentalAdded = "Araba başarıyla kiralandı ";
        public static string RentalDeleted = "Kiralanan araba silindi";
        public static string ListedOfRentedCars = "Kiralanan araçlar listelendi";
        public static string OutOfStock = "Kiralanılabilecek uygun araba kalmadı ";
        public static string FailUnAvailableCars = "Kiralanmış araba yoktur";
        public static string ListedOfUnAvailableCars = "Kiralanmış arabalar listelenmiştir";
        public static string RentalUpdated = "Kiralanan araba bilgileri güncellendi";
        public static string SelectedRentalId = "Seçilen Id'ye göre kiralanan araba bilgileri görüntülenmiştir";

        public static string LimitOfImage;
        public static string AddedCarImage;
        public static string DeletedCarImage;
        public static string ListedAllCarImages;
        public static string CarImageUpdated;
    }
}
