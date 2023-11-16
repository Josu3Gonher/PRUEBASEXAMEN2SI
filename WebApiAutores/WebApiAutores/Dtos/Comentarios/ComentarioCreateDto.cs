using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Dtos.Comentarios
{
    public class ComentarioCreateDto
    {
        [Required(ErrorMessage = "El comentario es requerido")]
        [StringLength(500, ErrorMessage = "El {0} requiere {1} caracteres")]
        public string Texto { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La respuesta es requerida")]
        public string Respuesta { get; set; }
    }
}
