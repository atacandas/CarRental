using CarRental.Business.Abstract;
using CarRental.Business.BusinessAspect.Autofac;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll().ToList();
            return  new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<CarDetailDto>> GetAllByBrandIdWithDetails(int brandId)
        {
            var result = _carDal.GetCarsDetail(c=>c.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetAllByColorIdWithDetails(int colorId)
        {
            var result = _carDal.GetCarsDetail(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetAllWithDetails()
        {
            var result = _carDal.GetCarsDetail();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<CarDetailDto> GetByIdWithDetails(int id)
        {
            var result = _carDal.GetCarDetail(c => c.Id == id);
            return new SuccessDataResult<CarDetailDto>(result);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
