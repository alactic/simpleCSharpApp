using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Title must be not be greater than 15 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Title must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Title must be not be greater than 15 characters")]
        public string Content { get; set; } = string.Empty;
    }
}