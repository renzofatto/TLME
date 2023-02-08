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
    public partial class EliminarActor : UserControl
    {
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly Pelicula _pelicula;

        public EliminarActor(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _pelicula = pelicula;
            cargarCombo();
        }
        private void cargarCombo()
        {
            cmbActuaciones.Text = "";
            cmbActuaciones.Items.Clear();
            cmbActuaciones.Items.AddRange(_pelicula.Actuaciones.ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarActuacionAPeliculaAPerfiles((Actuacion)cmbActuaciones.SelectedItem);
                cargarCombo();
                MessageBox.Show("Actuacion eliminada.");
            }
            catch (LogicaNegocioGeneroExcepcion exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {

            }
        }

        private void eliminarActuacionAPeliculaAPerfiles(Actuacion unaActuacion)
        {
            _pelicula.Actuaciones.Remove(unaActuacion);
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    foreach (Genero genero in perfil.Generos)
                    {
                        foreach (Pelicula pelicula in genero.Peliculas)
                        {
                            if (!pelicula.Actuaciones.Contains(unaActuacion))
                            {
                                pelicula.Actuaciones.Remove(unaActuacion);
                            }
                        }
                    }
                }
            }
        }
    }
}
