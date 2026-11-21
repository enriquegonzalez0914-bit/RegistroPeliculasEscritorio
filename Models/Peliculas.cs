
namespace RegistroPeliculasEscritorio.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }

        public Pelicula(int id, string titulo, string genero, int anio)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Anio = anio;
        }

        public Pelicula(string titulo, string genero, int anio)
        {
            Titulo = titulo;
            Genero = genero;
            Anio = anio;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Genero} - {Anio}";
        }
    }
}
