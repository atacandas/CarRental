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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomersDetails(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (var context = new CarRentalContext())
            {
                var result = from custo in context.Customers
                             join user in context.Users
                             on custo.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 Id = custo.Id,
                                 UserId = custo.UserId,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = custo.CompanyName,
                                 FindexPoint = (int)custo.FindexPoint
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
        public CustomerDetailDto GetCustomerDetail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (var context = new CarRentalContext())
            {
                var result = from custo in context.Customers
                             join user in context.Users
                             on custo.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 Id = custo.Id,
                                 UserId = custo.UserId,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = custo.CompanyName,
                                 FindexPoint = (int)custo.FindexPoint
                             };
                return result.SingleOrDefault(filter);
            }
        }
    }
}
