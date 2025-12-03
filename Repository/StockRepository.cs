using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateStockAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<bool> DoesStockExist(int id)
        {
            return await _context.Stocks.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stock = _context.Stocks.Include(x =>x.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stock = stock.Where(e =>e.CompanyName.Contains(query.CompanyName));
            }
            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stock = stock.Where(e => e.Symbol.Contains(query.Symbol));
            }
            return await stock.ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
           var stockModel = await _context.Stocks.Include(x =>x.Comments).FirstOrDefaultAsync(x => x.Id == id);
           if(stockModel == null)
            {
                return null;
            }
            return stockModel;
        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto updateStockDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null)
            {
                return null;
            }
            stockModel.Symbol = updateStockDto.Symbol;
            stockModel.CompanyName = updateStockDto.CompanyName;
            stockModel.Purchase = updateStockDto.Purchase;
            stockModel.LastDiv = updateStockDto.LastDiv;
            stockModel.MarketCap = updateStockDto.MarketCap;
            stockModel.Industry = updateStockDto.Industry;

            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}