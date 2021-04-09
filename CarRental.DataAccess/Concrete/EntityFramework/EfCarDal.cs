using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (var context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join br in context.Brands
                             on car.BrandId equals br.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId=car.BrandId,
                                 ColorId= car.ColorId,
                                 BrandName = br.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 FindexPoint = car.FindexPoint,
                                 ModelYear = car.ModelYear
                             };
                return filter == null 
                    ? result.ToList() 
                    : result.Where(filter).ToList();
            }
        }
        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (var context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join br in context.Brands
                             on car.BrandId equals br.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = car.Id,
                                 ColorId = car.Id,
                                 BrandName = br.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 FindexPoint = car.FindexPoint,
                                 ModelYear = car.ModelYear
                             };
                return result.SingleOrDefault(filter);
            }
        }
    }
}
