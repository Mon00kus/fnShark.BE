using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Titulo debe tener al menos 5 caracteres")]
        [MaxLength(280, ErrorMessage = "Titulo debe no puede tener mas de 280 caracteres")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Contenido debe tener al menos 5 caracteres")]
        [MaxLength(280, ErrorMessage = "Contenido no puede tener mas de 280 caracteres")]
        public string Content { get; set; } = string.Empty;
    }
}
