using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (var context = new CarRentalContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarBrand = brand.Name,
                                 CarColor = color.Name,
                                 CarDailyPrice = car.DailyPrice,
                                 CarModelYear = car.ModelYear,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
