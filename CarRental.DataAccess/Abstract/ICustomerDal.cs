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
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        CustomerDetailDto GetCustomerDetail(Expression<Func<CustomerDetailDto, bool>> filter);
        List<CustomerDetailDto> GetAllCustomersDetails(Expression<Func<CustomerDetailDto, bool>> filter);
    }
}
