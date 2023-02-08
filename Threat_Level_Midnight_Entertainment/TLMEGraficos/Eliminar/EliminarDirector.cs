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
    public partial class EliminarDirector : UserControl
    {
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly Pelicula _pelicula;

        public EliminarDirector(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _pelicula = pelicula;
            cargarCombo();
        }

        private void cargarCombo()
        {
            cmbDirectores.Text = "";
            cmbDirectores.Items.Clear();
            cmbDirectores.Items.AddRange(_pelicula.Directores.ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarDirectorAPeliculaAPerfiles((Reparto)cmbDirectores.SelectedItem);
                cargarCombo();
                MessageBox.Show("Director eliminado.");
            }
            catch (LogicaNegocioGeneroExcepcion exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {

            }
        }

        private void eliminarDirectorAPeliculaAPerfiles(Reparto unDirector)
        {
            _pelicula.Directores.Remove(unDirector);
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    foreach (Genero genero in perfil.Generos)
                    {
                        foreach (Pelicula pelicula in genero.Peliculas)
                        {
                            if (!pelicula.Directores.Contains(unDirector))
                            {
                                pelicula.Directores.Remove(unDirector);
                            }
                        }
                    }
                }
            }
        }
    }
}
