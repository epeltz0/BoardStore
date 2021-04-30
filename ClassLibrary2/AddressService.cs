using BoardBrowser.Data;
using BoardBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBrowser.Services
{
    public class AddressService
    {
        private readonly Guid _userId;

        public AddressService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAddress(AddressCreate model)
        {
            var entity =
                new Address()
                {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    State = model.State,
                    City = model.City,
                    ZipCode = model.ZipCode,
                    CustomerId = model.CustomerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Addresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AddressListItem> GetAddresses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Addresses
                        .Select(

                            e =>
                                new AddressListItem
                                {
                                    AddressId = e.AddressId,
                                     AddressLine1= e.AddressLine1,
                                    AddressLine2 = e.AddressLine2,
                                    State = e.State,
                                    City = e.City,
                                    ZipCode = e.ZipCode,
                                    CustomerId = e.CustomerId
                                }
                        );

                return query.ToArray();
            }
        }

        public AddressDetails GetAddressById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Addresses
                        .Single(e => e.AddressId == id);
                return
                    new AddressDetails
                    {
                        AddressId = entity.AddressId,
                        AddressLine1 = entity.AddressLine1,
                        AddressLine2 = entity.AddressLine2,
                        State = entity.State,
                        City = entity.City,
                        ZipCode = entity.ZipCode,
                        CustomerId = entity.CustomerId,
                        FirstName = entity.Customer.FirstName,
                        LastName = entity.Customer.LastName,

                    };
            }
        }

        public bool UpdateAddress(AddressEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Addresses
                        .Single(e => e.AddressId == model.AddressId);

                entity.AddressLine1 = model.AddressLine1;
                entity.AddressLine2 = model.AddressLine2;
                entity.State = model.State;
                entity.City = model.City;
                entity.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAddress(int addressId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Addresses
                        .Single(e => e.AddressId == addressId);

                ctx.Addresses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

