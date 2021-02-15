using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {

            if (car.DailyPrice == 0)
            {
                return new ErrorResult(Message.InvalidCar);
            }

            _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);   
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car,bool>> filter = null)
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.CarListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }
    }
}
