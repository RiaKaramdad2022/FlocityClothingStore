using FlocityClothingStore.Server.Services.Transaction;
using FlocityClothingStore.Shared.Models.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//The Transaction controller will handle all the HTTP methods for our app. Since our application is separated into Server and Client
//layers, the Server doesn't send HTML views as result, it sends JSON data and the Client uses that JSON data to build views.

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        //Created a DI(Dependency Injection) in order to use the Transaction Service.
    
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<List<TransactionListItem>> Index()
        {
            var transaction = await _transactionService.GetAllTransactionsAsync();
            return transaction.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Transaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
                if(transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSucessful = await _transactionService.CreateTransactionAsync(model);

            if (wasSucessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, TransactionEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();

            bool wasSucessful = await _transactionService.UpdateTransactionAsync(model);

            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null) return NotFound();

            bool wasSucessful = await _transactionService.DeleteTransactionAsync(id);

            if (!wasSucessful) return BadRequest();
            return Ok();

        }
    }
}
