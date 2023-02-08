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
using Dominio;
using Dominio.Excepciones;

namespace TLMEGraficos
{
    public partial class SeleccionarUsuario : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private Form1 _formPrincipal;

        public SeleccionarUsuario(Form1 formPrincipal, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _formPrincipal = formPrincipal;
            this.btnEliminar.Hide();
            mostrarBotonEliminarAOwner();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            comboPerfiles.Items.Clear();
            comboPerfiles.Items.AddRange(_logicaNegocioUsuario.UsuarioLogueado.Perfiles.ToArray());
            this.btnEliminar.Hide();
            mostrarBotonEliminarAOwner();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Perfil perfilLogeado = (Perfil)comboPerfiles.SelectedItem;
            _logicaNegocioUsuario.UsuarioLogueado.CerrarSesionPerfiles();
            try
            {
                if (perfilLogeado.Infantil || perfilLogeado.CoincidePin(Int32.Parse(txtPin.Text)))
                {
                    perfilLogeado.Logged = true;
                    _formPrincipal.esconderBotonRegistrarPerfil();
                    _formPrincipal.MostrarInicio();
                }
                else
                {
                    MessageBox.Show("Pin incorrecto");
                }
            }
            catch (PerfilInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LogicaNegocioUsuarioExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revise que haya completado todos los campos");
            }
        }

        private void comboPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Perfil perfilSeleccionado = (Perfil)comboPerfiles.SelectedItem;
            if (perfilSeleccionado.Infantil)
            {
                this.txtPin.Hide();
                this.lblPin.Hide();
            }
            else
            {
                this.txtPin.Show();
                this.lblPin.Show();
            }
        }

        private void mostrarBotonEliminarAOwner()
        {
            try
            {
                if (_logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().Owner)
                {
                    this.btnEliminar.Show();
                }
            }
            catch (UsuarioInvalidoExcepcion ex)
            {
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Perfil perfilSeleccionado = (Perfil)comboPerfiles.SelectedItem;
            if (perfilSeleccionado.Owner)
            {
                MessageBox.Show("No se puede eliminar este usuario");
            }
            else
            {
                _logicaNegocioUsuario.UsuarioLogueado.EliminarPerfil(perfilSeleccionado);
                comboPerfiles.Items.Clear();
                comboPerfiles.Items.AddRange(_logicaNegocioUsuario.UsuarioLogueado.Perfiles.ToArray());
                comboPerfiles.SelectedItem = _logicaNegocioUsuario.UsuarioLogueado.Perfiles.ToArray()[0];
                MessageBox.Show("Se ha eliminado el perfil correctamente.");
            }
        }
    }
}
