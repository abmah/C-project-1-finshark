using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {

        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 3 characters")]
        [MaxLength(255, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 3 characters")]
        [MaxLength(255, ErrorMessage = "Content cannot exceed 50 characters")]
        public string Content { get; set; } = string.Empty;
    }
}