using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentAsync();
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(Comment commentDto);
        Task<Comment?> DeleteCommentAsync(int id);
        Task<Comment?> UpdateCommentAsync(int id, UpdateCommentDto commentDto);
    }
}