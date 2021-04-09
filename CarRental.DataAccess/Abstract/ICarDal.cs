using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter);
    }
}
