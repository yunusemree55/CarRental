using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdded); 
            


        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.RentalDeleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
           
           
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.ListedOfRentedCars);
            
        }

        public IDataResult<List<Rental>> GetAvailableCars()
        {
            if (_rentalDal.GetAll(r => r.RentDate == null).Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == null),Message.OutOfStock);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == null));
            
            
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id),Message.SelectedRentalId);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<Rental>> GetUnAvailableCars()
        {
            if (_rentalDal.GetAll(r => r.RentDate != null).Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Message.FailUnAvailableCars);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate != null),Message.ListedOfUnAvailableCars);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalUpdated);
        }
    }
}
