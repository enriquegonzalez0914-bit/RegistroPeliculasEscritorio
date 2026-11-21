using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using RegistroPeliculasEscritorio.Models;

namespace RegistroPeliculasEscritorio.Data
{
    public class PeliculaDAO
    {
        private readonly ConexionBD conexionBD;

        public PeliculaDAO()
        {
            conexionBD = new ConexionBD();
        }

        public void Registrar(Pelicula pelicula)
        {
            using (var conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"INSERT INTO Peliculas
                               (Titulo, Genero, Anio)
                               VALUES (@titulo, @genero, @anio)";

                using (var comando = new SqliteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@titulo", pelicula.Titulo);
                    comando.Parameters.AddWithValue("@genero", pelicula.Genero);
                    comando.Parameters.AddWithValue("@anio", pelicula.Anio);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Pelicula> Consultar()
        {
            List<Pelicula> peliculas = new List<Pelicula>();

            using (var conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = "SELECT * FROM Peliculas ORDER BY Id";

                using (var comando = new SqliteCommand(sql, conexion))
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Pelicula pelicula = new Pelicula(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetString(2),
                            lector.GetInt32(3)
                        );

                        peliculas.Add(pelicula);
                    }
                }
            }

            return peliculas;
        }

        public void Modificar(Pelicula pelicula)
        {
            using (var conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"UPDATE Peliculas
                               SET Titulo = @titulo,
                                   Genero = @genero,
                                   Anio = @anio
                               WHERE Id = @id";

                using (var comando = new SqliteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", pelicula.Id);
                    comando.Parameters.AddWithValue("@titulo", pelicula.Titulo);
                    comando.Parameters.AddWithValue("@genero", pelicula.Genero);
                    comando.Parameters.AddWithValue("@anio", pelicula.Anio);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var conexion = conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = "DELETE FROM Peliculas WHERE Id = @id";

                using (var comando = new SqliteCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
