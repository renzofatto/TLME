using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLMEGraficos
{
    public partial class EliminarPelicula : UserControl
    {
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioGenero _logicaNegocioGenero;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;

        public EliminarPelicula(LogicaNegocioPelicula logicaNegocioPelicula, LogicaNegocioGenero logicaNegocioGenero, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioPelicula = logicaNegocioPelicula;
            _logicaNegocioGenero = logicaNegocioGenero;
            _logicaNegocioUsuario = logicaNegocioUsuario;
            cargarCombo();
        }

        private void EliminarPelicula_Load(object sender, EventArgs e)
        {

        }

        private void cargarCombo()
        {
            cmbPeliulas.Text = "";
            cmbPeliulas.Items.Clear();
            cmbPeliulas.Items.AddRange(_logicaNegocioPelicula.ObtenerPelicula().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Pelicula peliculaAEliminar = (Pelicula)cmbPeliulas.SelectedItem;
                Genero generoPrincipal = _logicaNegocioGenero.ObtenerGeneroPorNombre(peliculaAEliminar.GeneroPrincipal.Nombre);
                for (int i = 0; i < peliculaAEliminar.GeneroSecundario.Count; i++)
                {
                    _logicaNegocioGenero.ObtenerGeneroPorNombre(peliculaAEliminar.GeneroSecundario[i].ToString()).Peliculas.Remove(peliculaAEliminar);
                }

                generoPrincipal.Peliculas.Remove(peliculaAEliminar);
                _logicaNegocioPelicula.Eliminar(peliculaAEliminar);
                cargarCombo();
                eliminarPeliculaAPerfil(peliculaAEliminar);
                MessageBox.Show("Pelicula eliminada.");
            }
            catch (LogicaNegocioPeliculaExcepcion exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {

            }
        }
        private void eliminarPeliculaAPerfil(Pelicula unaPelicula)
        {
            bool continuar = true;
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    continuar = true;
                    for (int i = 0; i < perfil.Peliculas.Count && continuar; i++)
                    {
                        if (perfil.Peliculas[i].Nombre.Equals(unaPelicula.Nombre) && perfil.Peliculas[i].Descripcion.Equals(unaPelicula.Descripcion))
                        {
                            perfil.Peliculas.RemoveAt(i);
                            continuar = false;
                        }
                    }
                }
            }
        }
    }
}
