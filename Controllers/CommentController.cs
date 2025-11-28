using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var commentModels = await _commentRepo.GetAllCommentAsync();
            return Ok(commentModels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var commentModels = await _commentRepo.GetCommentByIdAsync(id);
            if(commentModels == null)
            {
                return NotFound();
            }
            return Ok(commentModels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentDto)
        {
            var commentModel = commentDto.CreateCommentMapper();
            var commentModels = await _commentRepo.CreateCommentAsync(commentModel);
            return CreatedAtAction(nameof(GetCommentById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var commentModel = await _commentRepo.DeleteCommentAsync(id);
            if(commentModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto commentDto)
        {
            var commentModel = await _commentRepo.UpdateCommentAsync(id, commentDto);
            if(commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel);
        }
    }
}