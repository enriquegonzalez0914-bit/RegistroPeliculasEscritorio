
using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace RegistroPeliculasEscritorio.Data
{
    public class ConexionBD
    {
        private readonly string cadenaConexion;

        public ConexionBD()
        {
            string rutaBD = Path.Combine(
                AppContext.BaseDirectory,
                "peliculas.db"
            );

            cadenaConexion = $"Data Source={rutaBD}";
        }

        public SqliteConnection ObtenerConexion()
        {
            return new SqliteConnection(cadenaConexion);
        }

        public void CrearBaseDatos()
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS Peliculas (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Titulo TEXT NOT NULL,
                        Genero TEXT NOT NULL,
                        Anio INTEGER NOT NULL
                    );";

                using (var comando = new SqliteCommand(sql, conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
