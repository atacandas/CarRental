using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetAllWithDetails();
        IDataResult<CarDetailDto> GetByIdWithDetails(int id);
        IDataResult<List<CarDetailDto>> GetAllByBrandIdWithDetails(int brandId);
        IDataResult<List<CarDetailDto>> GetAllByColorIdWithDetails(int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
