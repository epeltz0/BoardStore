using BoardBrowser.Data;
using BoardBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardBrowser.Services
{
        public class CustomerServices
        {
            private readonly Guid _userId;

            public CustomerServices(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateCustomer(CustomerCreate model)
            {
                var entity =
                    new Customer()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        YearsSkating = model.YearsSkating,
                        
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Customers.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<CustomerListItems> GetCustomers()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Customers
                            .Select(

                                e =>
                                    new CustomerListItems
                                    {
                                        CustomerId = e.CustomerId,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        YearsSkating = e.YearsSkating,
                                       

                                    }
                            );

                    return query.ToArray();
                }
            }

            public CustomerDetails GetCustomerById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Customers
                            .Single(e => e.CustomerId == id);
                    return
                        new CustomerDetails
                        {
                            CustomerId = entity.CustomerId,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            YearsSkating = entity.YearsSkating,
         
                        };
                }
            }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.YearsSkating = model.YearsSkating;
               
                



                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

