using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
               Id = comment.Id, 
               Title = comment.Title, 
               Content = comment.Content, 
               CreatedOn = comment.CreatedOn, 
               StockId = comment.StockId 
            };
        }

        public static Comment CreateCommentMapper(this CreateCommentDto commentDto)
        {
            return new Comment
            {
               Title = commentDto.Title, 
               Content = commentDto.Content, 
               CreatedOn = commentDto.CreatedOn, 
               StockId = commentDto.StockId 
            };
        }
    }
}