using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Dtos.Reviews
{
    public class ReviewCreateDto
    {
        [Display(Name = "Review")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(500, ErrorMessage = "El {0} requiere {1} caracteres")]
        public string Reviews { get; set; }

        [Required(ErrorMessage = "La calificacion es requerida")]
        public int Calificacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
