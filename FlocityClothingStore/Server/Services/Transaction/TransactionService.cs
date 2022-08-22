using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Shared.Models.Transaction;
using Microsoft.EntityFrameworkCore;
using FlocityClothingStore.Server.Models;

namespace FlocityClothingStore.Server.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;
        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTransactionAsync(TransactionCreate model)
        {
            if (model == null) return false;

            _context.Transactions.Add(new Models.Transaction
            {
                CustomerId = model.CustomerId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                DateOfTransaction = DateTime.Now
            });
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync()
        {
            var transcations = _context.Transactions.Select(t => new TransactionListItem
            {
                Id = t.Id,
                CustomerId = t.CustomerId,
                ProductId = t.ProductId,
                Quantity = t.Quantity,
                DateOfTransaction = t.DateOfTransaction
            });
   
            return await transcations.ToListAsync();
        }

        public async Task<TransactionDetail> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);

            if (transaction == null) return null;

            var transacationDetail = new TransactionDetail
            {
                Id = transaction.Id,
                ProductId = transaction.ProductId,
                CustomerId = transaction.CustomerId,
                Quantity = transaction.Quantity,
                DateOfTransaction = transaction.DateOfTransaction,
                ProductPrice = transaction.Product.Price

            };
            return transacationDetail;
        }
        public async Task<bool> UpdateTransactionAsync(TransactionEdit model)
        {
            var transacation = await _context.Transactions.FindAsync(model.Id);
            if (transacation is null) return false;

            transacation.Id = model.Id;
            transacation.ProductId = model.ProductId;
            transacation.CustomerId = model.CustomerId;
            transacation.Quantity = model.Quantity;
            transacation.DateOfTransaction = model.DateOfTransaction;

            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if (transaction is null) return false;

            _context.Transactions.Remove(transaction);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

    }
}
