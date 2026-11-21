using System;
using System.Collections.Generic;

using RegistroPeliculasEscritorio.Data;
using RegistroPeliculasEscritorio.Models;

namespace RegistroPeliculasEscritorio.Services
{
    public class PeliculaServicio
    {
        private readonly PeliculaDAO peliculaDAO;

        public PeliculaServicio()
        {
            peliculaDAO = new PeliculaDAO();
        }

        public string Registrar(string titulo, string genero, int anio)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                return "Debe ingresar el título de la película.";

            if (string.IsNullOrWhiteSpace(genero))
                return "Debe ingresar el género de la película.";

            if (anio < 1888 || anio > DateTime.Now.Year)
                return "Ingrese un año válido.";

            Pelicula pelicula = new Pelicula(titulo, genero, anio);

            peliculaDAO.Registrar(pelicula);

            return "Película registrada correctamente.";
        }

        public List<Pelicula> Consultar()
        {
            return peliculaDAO.Consultar();
        }

        public string Modificar(int id, string titulo, string genero, int anio)
        {
            if (id <= 0)
                return "Seleccione una película para modificar.";

            if (string.IsNullOrWhiteSpace(titulo))
                return "Debe ingresar el título de la película.";

            if (string.IsNullOrWhiteSpace(genero))
                return "Debe ingresar el género de la película.";

            if (anio < 1888 || anio > DateTime.Now.Year)
                return "Ingrese un año válido.";

            Pelicula pelicula = new Pelicula(id, titulo, genero, anio);

            peliculaDAO.Modificar(pelicula);

            return "Película modificada correctamente.";
        }

        public string Eliminar(int id)
        {
            if (id <= 0)
                return "Seleccione una película para eliminar.";

            peliculaDAO.Eliminar(id);

            return "Película eliminada correctamente.";
        }
    }
}
