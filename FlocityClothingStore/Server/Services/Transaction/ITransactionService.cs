using FlocityClothingStore.Shared.Models.Transaction;

namespace FlocityClothingStore.Server.Services.Transaction
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(TransactionCreate model);
        Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync();
        Task<TransactionDetail> GetTransactionByIdAsync(int customerId);
        Task<bool> UpdateTransactionAsync(TransactionEdit model);
        Task<bool> DeleteTransactionAsync(int transactionId);
    }
}
