using Core.Utilities.FileSystems;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddSync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Message.AddedCarImage);

        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(FileHelper.DeleteAsync(_carImageDal.Get(c=>c.Id == carImage.Id).ImagePath));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Message.DeletedCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Message.ListedAllCarImages);
        }

        public IDataResult<CarImage> GetCarImagesById(int carImageId)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Message.CarImageUpdated);


        }

        private IResult CheckCarImageLimit(int carId)
        {
            var carImageLimit = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageLimit > 5)
            {
                return new ErrorResult(Message.LimitOfImage);
            }
            return new SuccessResult();
        }

    }
}
