using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RegistroPeliculasEscritorio.Models;
using RegistroPeliculasEscritorio.Services;

namespace RegistroPeliculasEscritorio;

public partial class MainWindow : Window
{
    private readonly PeliculaServicio peliculaServicio;
    private int idSeleccionado = 0;

    public MainWindow()
    {
        InitializeComponent();

        peliculaServicio = new PeliculaServicio();

        var conexion = new Data.ConexionBD();
        conexion.CrearBaseDatos();

        CargarPeliculas();

        btnGuardar.Click += BtnGuardar_Click;
        btnConsultar.Click += BtnConsultar_Click;
        btnModificar.Click += BtnModificar_Click;
        btnEliminar.Click += BtnEliminar_Click;
        btnLimpiar.Click += BtnLimpiar_Click;

        lstPeliculas.SelectionChanged += LstPeliculas_SelectionChanged;
    }

    private void BtnGuardar_Click(object? sender, RoutedEventArgs e)
    {
        if (!int.TryParse(txtAnio.Text, out int anio))
        {
            txtMensaje.Text = "Ingrese un año válido.";
            return;
        }

        try
        {
            string mensaje = peliculaServicio.Registrar(
                txtTitulo.Text ?? "",
                txtGenero.Text ?? "",
                anio
            );

            txtMensaje.Text = mensaje;

            if (mensaje == "Película registrada correctamente.")
            {
                CargarPeliculas();
                LimpiarCampos();
            }
        }
        catch (Exception ex)
        {
            txtMensaje.Text = "Error al guardar: " + ex.Message;
        }
    }

    private void BtnConsultar_Click(object? sender, RoutedEventArgs e)
    {
        CargarPeliculas();
        txtMensaje.Text = "Consulta realizada correctamente.";
    }

    private void BtnModificar_Click(object? sender, RoutedEventArgs e)
    {
        if (idSeleccionado <= 0)
        {
            txtMensaje.Text = "Seleccione una película de la lista.";
            return;
        }

        if (!int.TryParse(txtAnio.Text, out int anio))
        {
            txtMensaje.Text = "Ingrese un año válido.";
            return;
        }

        try
        {
            string mensaje = peliculaServicio.Modificar(
                idSeleccionado,
                txtTitulo.Text ?? "",
                txtGenero.Text ?? "",
                anio
            );

            txtMensaje.Text = mensaje;

            if (mensaje == "Película modificada correctamente.")
            {
                CargarPeliculas();
                LimpiarCampos();
            }
        }
        catch (Exception ex)
        {
            txtMensaje.Text = "Error al modificar: " + ex.Message;
        }
    }

    private void BtnEliminar_Click(object? sender, RoutedEventArgs e)
    {
        if (idSeleccionado <= 0)
        {
            txtMensaje.Text = "Seleccione una película para eliminar.";
            return;
        }

        try
        {
            string mensaje = peliculaServicio.Eliminar(idSeleccionado);

            txtMensaje.Text = mensaje;

            if (mensaje == "Película eliminada correctamente.")
            {
                CargarPeliculas();
                LimpiarCampos();
            }
        }
        catch (Exception ex)
        {
            txtMensaje.Text = "Error al eliminar: " + ex.Message;
        }
    }

    private void LstPeliculas_SelectionChanged(
        object? sender,
        SelectionChangedEventArgs e)
    {
        if (lstPeliculas.SelectedItem is Pelicula pelicula)
        {
            idSeleccionado = pelicula.Id;

            txtTitulo.Text = pelicula.Titulo;
            txtGenero.Text = pelicula.Genero;
            txtAnio.Text = pelicula.Anio.ToString();
        }
    }

    private void CargarPeliculas()
    {
        lstPeliculas.ItemsSource = null;

        List<Pelicula> peliculas = peliculaServicio.Consultar();

        lstPeliculas.ItemsSource = peliculas;
    }

    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        LimpiarCampos();
        txtMensaje.Text = "Campos limpiados.";
    }

    private void LimpiarCampos()
    {
        txtTitulo.Text = "";
        txtGenero.Text = "";
        txtAnio.Text = "";

        lstPeliculas.SelectedItem = null;
        idSeleccionado = 0;
    }
}
