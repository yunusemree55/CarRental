using Core.DataAccess.EntityFramework;
using System.Linq; //
using Microsoft.EntityFrameworkCore; //
using DataAccess.Abstract; //
using Entities.Concrete; //
using Entities.DTOs; //
using System; //
using System.Collections.Generic; //
using Microsoft.EntityFrameworkCore.Query.SqlExpressions; //


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.Id
                             join r in context.Colors
                             on c.ColorId equals r.Id

                             select new CarDetailDto { BrandName = b.Name , CarId = c.Id, CarName = c.Name, DailyPrice = c.DailyPrice,ColorName= r.Name };

                return result.ToList();
                                

                
            }
        }
    }
}
