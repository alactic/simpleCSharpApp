using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager,
        IStockRepository stockRepository, IPortfolioRepository portfolioRepository
        )
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
        }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserPortfolio() {
       var username = User.GetUsername();
       var appUser = await _userManager.FindByNameAsync(username);
       var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
       return Ok(userPortfolio);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddPortfolio(string symbol)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var stock = await _stockRepository.GetBySymbolAsync(symbol);
        if(stock == null) return BadRequest("Stock not found");

        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
        if(userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Stock already exist. We can't add the same stock to this user");
        var portfolioModel = new Portfolio
        {
            StockId = stock.Id,
            AppUserId = appUser.Id
        };
        var newPortfolio = await _portfolioRepository.CreatePortfolio(portfolioModel);
        if(newPortfolio == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }

    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeletePortfolio(string symbol)
    {
       var username = User.GetUsername();
       var appUser = await _userManager.FindByNameAsync(username);
       var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
       var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower());

       if(filteredStock.Count() == 1)
        {
            var portfolioModel = await _portfolioRepository.DeletePortfolio(appUser, symbol);
            if(portfolioModel == null)
                {
                    return BadRequest("We couldn't delete this portfolio, try again later");
                }
            return Ok("This portfolio was deleted successfully");
        }
        return BadRequest("This portfolio does not exist");

    }
  }
}