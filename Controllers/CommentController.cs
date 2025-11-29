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
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var commentModels = await _commentRepo.GetAllCommentAsync();
            var commentDto = commentModels.Select(x =>x.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var commentModels = await _commentRepo.GetCommentByIdAsync(id);
            if(commentModels == null)
            {
                return NotFound();
            }
            return Ok(commentModels.ToCommentDto());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> CreateComment([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if(!await _stockRepo.DoesStockExist(stockId))
            {
                return BadRequest("Stock Id does not exist");
            }
            var commentModel = commentDto.CreateCommentMapper(stockId);
            var commentModels = await _commentRepo.CreateCommentAsync(commentModel);
            return CreatedAtAction(nameof(GetCommentById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
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
        [Route("{id:int}")]
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