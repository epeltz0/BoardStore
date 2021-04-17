using BoardBrowser.Data;
using BoardBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardBrowser.Services
{
    public class TransactionServices
    {
        private readonly Guid _userId;

        public TransactionServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    BoardId = model.BoardId,
                    CustomerID = model.CustomerID,
                    DateOfTransaction = model.DateOfTransaction,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Select(

                            e =>
                                new TransactionListItem
                                {
                                    CustomerID = e.CustomerID,
                                    BoardId = e.BoardId,
                                    DateOfTransaction = e.DateOfTransaction
                                }
                        );

                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId== id);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        CustomerID = entity.CustomerID,
                        BoardId = entity.BoardId,
                        DateOfTransaction = entity.DateOfTransaction
                    };
            }
        }
    }
}
