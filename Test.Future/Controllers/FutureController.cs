using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test.Future.Data;
using Test.Future.Models;

namespace Test.Future.Controllers
{
    public class FutureController : Controller
    {
        private readonly IRepository _repository;

        public FutureController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Future")]
        public async Task<IActionResult> Future()
        {
            ViewBag.Expenses = await GenerateExpenseSelectItems();
            return View();
        }
        [HttpPost("Future")]
        public async Task<IActionResult> Future(FutueViewModel model)
        {
            return View();
        }
        private async Task<List<SelectListItem>> GenerateExpenseSelectItems()
        {
            var listExpenses= new List<SelectListItem>();
            var expenses = await _repository.GetExpenses();
            foreach (var expense in expenses.OrderBy(c => c.Order))
            {
                var item = new SelectListItem { Text = expense.Name, Value = expense.Id.ToString() };
                listExpenses.Add(item);
            }

            return listExpenses;
        }
    }
}
