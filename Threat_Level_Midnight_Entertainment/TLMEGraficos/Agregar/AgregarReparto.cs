using Dominio.Excepciones;
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

namespace TLMEGraficos
{
    public partial class AgregarReparto : UserControl
    {
        private LogicaNegocioReparto _logicaNegocioReparto;
        public AgregarReparto(LogicaNegocioReparto LogicaNegocioReparto)
        {
            InitializeComponent();
            _logicaNegocioReparto = LogicaNegocioReparto;
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = path.Text;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (path.Text != "" && !txtNombre.Text.Equals(""))
            {
                try
                {
                    if (radioBtnAmbos.Checked)
                    {
                        Actor actor = new Actor()
                        {
                            Nombre = txtNombre.Text,
                            FechaNacimiento = dateTimePicker.Value,
                            Imagen = path.Text
                        };
                        _logicaNegocioReparto.Agregar(actor);
                        
                        Director director = new Director()
                        {
                            Nombre = txtNombre.Text,
                            FechaNacimiento = dateTimePicker.Value,
                            Imagen = path.Text
                        };
                        _logicaNegocioReparto.Agregar(director);
                    }else if (radioBtnActor.Checked)
                    {
                        Actor actor = new Actor()
                        {
                            Nombre = txtNombre.Text,
                            FechaNacimiento = dateTimePicker.Value,
                            Imagen = path.Text
                        };
                        _logicaNegocioReparto.Agregar(actor);
                    }
                    else
                    {
                        Director director = new Director()
                        {
                            Nombre = txtNombre.Text,
                            FechaNacimiento = dateTimePicker.Value,
                            Imagen = path.Text
                        };
                        _logicaNegocioReparto.Agregar(director);
                    }
                    MessageBox.Show("Reparto agregado corectamente.");
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (path.Text == "")
            {
                MessageBox.Show("Debe seleccionar una imagen");
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre");
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            pictureBox1.Image = null;
            path.Text = null;
            dateTimePicker.Value = DateTime.Today;
        }
    }
}
