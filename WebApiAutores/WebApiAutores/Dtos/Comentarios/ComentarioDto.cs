namespace WebApiAutores.Dtos.Comentarios
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public string Respuesta { get; set; }
    }
}
