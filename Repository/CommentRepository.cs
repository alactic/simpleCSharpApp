using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
           _context = context;   
        }

        public async Task<Comment> CreateCommentAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllCommentAsync()
        {
            var commentModel = await _context.Comments.ToListAsync();
            return commentModel;
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(commentModel == null)
            {
                return null;
            }
            return commentModel;
        }
    }
}