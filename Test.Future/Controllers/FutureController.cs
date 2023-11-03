using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using Test.Future.Data;
using Test.Future.Data.Entities;
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
        public async Task<IActionResult> Future(FutureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var future = await GenerateFutureFromModel(model);
                await _repository.AddEntityAsync(future);
                var dbResult = await _repository.SaveAllAsync();
                if (dbResult)
                {
                    return RedirectToAction("FutureDetail", "FutureDetail", new { id = future.Id });
                }
                else
                {
                    ViewBag.Expenses = await GenerateExpenseSelectItems();
                    return View(model);
                }
            }
            else
            {
                ViewBag.Expenses = await GenerateExpenseSelectItems();
                return View(model);
            }

        }
        private async Task<List<SelectListItem>> GenerateExpenseSelectItems()
        {
            var listExpenses = new List<SelectListItem>();
            var expenses = await _repository.GetExpenses();
            foreach (var expense in expenses.OrderBy(c => c.Order))
            {
                var item = new SelectListItem { Text = expense.Name, Value = expense.Id.ToString() };
                listExpenses.Add(item);
            }
            return listExpenses;
        }
        private async Task<HS_CostOfFuture> GenerateFutureFromModel(FutureViewModel model)
        {   // Get All Expenses
            List<HS_Expense> expenses = await _repository.GetExpenses();
            // Map Model to Entity
            HS_CostOfFuture future = new()
            {
                Amount = model.Amount,
                CardLastName = model.CardLastName,
                CardName = model.CardName,
                Comment = model.Comment,
                HS_Expense = expenses.Where(e => e.Id == model.ExpenseId).First(),
                InstallmentCount = model.InstallmentCount,
                PaymentMethodType = model.PaymentMethodType,
                PolicyBeginDate = model.PolicyStartDate,
                PolicyEndDate = model.PolicyEndDate,
                PolicyNumber = model.PolicyNumber
            };
            return future;
        }

    }
}
