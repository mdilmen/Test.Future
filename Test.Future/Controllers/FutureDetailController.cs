using Microsoft.AspNetCore.Mvc;
using Test.Future.Data;
using Test.Future.Data.Entities;
using Test.Future.Models;
using Test.Future.Services.FutureCostService;

namespace Test.Future.Controllers
{
    public class FutureDetailController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFutureCostService _costService;

        public FutureDetailController(IRepository repository, IFutureCostService costService)
        {
            _repository = repository;
            _costService = costService;
        }
        [HttpGet("FutureDetail/{id}")]
        public async Task<IActionResult> FutureDetail(int id)
        {
            HS_CostOfFuture? future = await _repository.GetFuture(id);
            if(future == null) 
            {
                return RedirectToAction("Home", "Error");
            }
            FutureDetailViewModel viewModel = new FutureDetailViewModel()
            {
                PolicyNumber = future.PolicyNumber,
                Amount = future.Amount,
                CardLastName = future.CardLastName,
                CardName = future.CardName,
                FutureCostModel = await _costService.GetCost(future)

            };
                
                ;
            return View(viewModel);
        }
    }
}
