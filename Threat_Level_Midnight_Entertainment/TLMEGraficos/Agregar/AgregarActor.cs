using Dominio;
using Dominio.Excepciones;
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
    public partial class AgregarActor: UserControl
    {
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly Pelicula _pelicula;
        public AgregarActor(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _pelicula = pelicula;
            cargarCombo();
            cargarListBox();
        }

        private void cargarListBox()
        {
            listBox.Text = "";
            listBox.Items.Clear();
            listBox.Items.AddRange(_pelicula.Actuaciones.ToArray());
        }
        private void cargarCombo()
        {
            cmbReparto.Text = "";
            cmbReparto.Items.Clear();
            cmbReparto.Items.AddRange(_logicaNegocioReparto.ObtenerActores().ToArray());
        }
        
        private void agregarActuacionAPeliculaAPerfiles(Actuacion unaActuacion)
        {
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    foreach (Genero genero in perfil.Generos)
                    {
                        foreach (Pelicula pelicula in genero.Peliculas)
                        {
                            if (!_pelicula.Actuaciones.Contains(unaActuacion) && pelicula.Nombre.Equals(_pelicula.Nombre))
                            {
                                pelicula.AgregarActuacion(unaActuacion.Actor, unaActuacion.Papel);
                            }
                        }
                    }
                }
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Actor actorAAgregar = (Actor)cmbReparto.SelectedItem;
                if (actorAAgregar != null && !txtPapel.Text.Equals(""))
                {
                    Actuacion actuacionAAgregar = new Actuacion()
                    {
                        Actor = actorAAgregar,
                        Papel = txtPapel.Text
                    };
                    if (!actorAAgregar.PeliculasActuadas.Contains(_pelicula))
                    {
                        actorAAgregar.AgregarPeliculaActuada(_pelicula);
                    }

                    if (!_pelicula.Actuaciones.Contains(actuacionAAgregar))
                    {
                        agregarActuacionAPeliculaAPerfiles(actuacionAAgregar);
                        MessageBox.Show("Se agrego la actuacion a esta pelicula.");
                        cargarListBox();
                    }
                    else
                    {
                        MessageBox.Show("El actor ya actua ese papel.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un actor y cargar el papel que realiza.");
                }
            }
            catch (PeliculaInvalidaExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
