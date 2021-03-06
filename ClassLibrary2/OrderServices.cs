using BoardBrowser.Data;
using BoardBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardBrowser.Services
{
    public class OrderServices
    {
        private readonly Guid _userId;

        public OrderServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    BoardId = model.BoardId,
                    CustomerId = model.CustomerId,
                    DateOfTransaction = model.DateOfTransaction,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Orders
                        
                        .Select(

                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerId = e.CustomerId,
                                    FirstName = e.Customer.FirstName,
                                    LastName = e.Customer.LastName,
                                    BoardId = e.BoardId,
                                    BoardName = e.Board.BoardName,
                                    Price = e.Board.Price,
                                    DateOfTransaction = e.DateOfTransaction
                                }
                        );

                return query.ToArray();
            }
        }

        public OrderDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId== id);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        CustomerId = entity.CustomerId,
                        FirstName = entity.Customer.FirstName,
                        LastName = entity.Customer.LastName,
                        BoardId = entity.BoardId,
                        BoardCategory = entity.Board.BoardCategory,
                        BoardName = entity.Board.BoardName,
                        Price = entity.Board.Price,
                        DateOfTransaction = entity.DateOfTransaction
                    };
            }
        }
        public bool UpdateTransaction(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == model.OrderId);

                entity.CustomerId = model.CustomerId;
                entity.BoardId = model.BoardId;
             




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

