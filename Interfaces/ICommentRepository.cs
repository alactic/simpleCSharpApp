using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentAsync();
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(Comment commentDto);
    }
}