using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Actor = Dominio.Actor;

namespace TLMEGraficos
{
    public partial class EliminarReparto : UserControl
    {
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        public EliminarReparto(LogicaNegocioReparto LogicaNegocioReparto)
        {
            InitializeComponent();
            _logicaNegocioReparto = LogicaNegocioReparto;
            cargarCombo();

        }
        private void cargarCombo()
        {
            cmbReparto.Text = "";
            cmbReparto.Items.Clear();
            cmbReparto.Items.AddRange(_logicaNegocioReparto.ObtenerRepartos().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Reparto repartoAEliminar = (Reparto)cmbReparto.SelectedItem;
                if (repartoAEliminar == null)
                {
                    MessageBox.Show("No hay reparto seleccionado.");
                }
                else
                {
                    if (repartoAEliminar.GetType() == typeof(Director))
                    {
                        Director director = (Director)repartoAEliminar;
                        if (director.PeliculasDirigidas.Count == 0)
                        {
                            _logicaNegocioReparto.Eliminar(director);
                            MessageBox.Show("Reparto eliminado.");
                            cargarCombo();
                            pictureBox1.ImageLocation = null;
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar por que participa de alguna pelicula.");
                        }
                    }  
                    if (repartoAEliminar.GetType() == typeof(Actor))
                    {
                        Actor actor = (Actor)repartoAEliminar;
                        if (actor.PeliculasActuadas.Count == 0)
                        {
                            _logicaNegocioReparto.Eliminar(actor);
                            MessageBox.Show("Reparto eliminado.");
                            cargarCombo();
                            pictureBox1.ImageLocation = null;
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar por que participa de alguna pelicula.");
                        }
                    }
                    
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void cmbReparto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reparto repartoSeleccionado = (Reparto)cmbReparto.SelectedItem;
            txtNuevoNombre.Text = repartoSeleccionado.Nombre;
            pictureBox1.ImageLocation = repartoSeleccionado.Imagen;
            dateFechaNacimientoNueva.Value = repartoSeleccionado.FechaNacimiento;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Reparto repartoAModificar = (Reparto)cmbReparto.SelectedItem;
                if (repartoAModificar == null)
                {
                    MessageBox.Show("No hay reparto seleccionado.");
                }
                else
                {
                    if (repartoAModificar.GetType() == typeof(Director) && radioBtnActor.Checked)
                    {
                        Director director = (Director)repartoAModificar;
                        if (director.PeliculasDirigidas.Count == 0)
                        {
                            Actor actor = new Actor()
                            {
                                FechaNacimiento = dateFechaNacimientoNueva.Value,
                                Imagen = director.Imagen,
                                Nombre = txtNuevoNombre.Text
                            };
                            _logicaNegocioReparto.Eliminar(director);
                            _logicaNegocioReparto.Agregar(actor);
                            MessageBox.Show("Reparto modificado.");
                            cargarCombo();
                            pictureBox1.ImageLocation = null;
                        }
                        else
                        {
                            MessageBox.Show("No se puede modificar por que dirige alguna pelicula.");
                        }
                    }
                    if (repartoAModificar.GetType() == typeof(Actor) && radioBtnDirector.Checked)
                    {
                        Actor actor = (Actor)repartoAModificar;
                        if (actor.PeliculasActuadas.Count == 0)
                        {
                            Director director = new Director()
                            {
                                FechaNacimiento = dateFechaNacimientoNueva.Value,
                                Imagen = actor.Imagen,
                                Nombre = txtNuevoNombre.Text
                            };
                            _logicaNegocioReparto.Eliminar(actor);
                            _logicaNegocioReparto.Agregar(director);
                            MessageBox.Show("Reparto modificado.");
                            cargarCombo();
                            pictureBox1.ImageLocation = null;
                        }
                        else
                        {
                            MessageBox.Show("No se puede modificar por que actua en alguna pelicula.");
                        }
                    }
                    if (repartoAModificar.GetType() == typeof(Director) && radioBtnAmbos.Checked)
                    {
                        Actor actor = new Actor()
                        {
                            FechaNacimiento = dateFechaNacimientoNueva.Value,
                            Imagen = repartoAModificar.Imagen,
                            Nombre = txtNuevoNombre.Text
                        };
                        repartoAModificar.Nombre = txtNuevoNombre.Text;
                        repartoAModificar.FechaNacimiento = dateFechaNacimientoNueva.Value;
                        _logicaNegocioReparto.Agregar(actor);
                        MessageBox.Show("Reparto modificado.");
                        cargarCombo();
                        pictureBox1.ImageLocation = null;
                    }
                    if (repartoAModificar.GetType() == typeof(Actor) && radioBtnAmbos.Checked)
                    {
                        Director director = new Director()
                        {
                            FechaNacimiento = dateFechaNacimientoNueva.Value,
                            Imagen = repartoAModificar.Imagen,
                            Nombre = txtNuevoNombre.Text
                        };
                        repartoAModificar.Nombre = txtNuevoNombre.Text;
                        repartoAModificar.FechaNacimiento = dateFechaNacimientoNueva.Value;
                        _logicaNegocioReparto.Agregar(director);
                        MessageBox.Show("Reparto modificado.");
                        cargarCombo();
                        pictureBox1.ImageLocation = null;
                    }

                }
            }
            catch (Exception exception)
            {

            }
        }
    }
}
