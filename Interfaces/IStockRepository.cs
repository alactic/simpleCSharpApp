using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock> CreateStockAsync(Stock stockModel);
        Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto stockDato);
        Task<Stock?> DeleteStockAsync(int id);
        Task<bool> DoesStockExist(int id);

    }
}