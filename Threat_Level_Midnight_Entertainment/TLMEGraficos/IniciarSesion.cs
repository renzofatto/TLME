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
    public partial class IniciarSesion : UserControl
    {
        private Form1 _formPrincipal;

        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;

        public IniciarSesion(Form1 formPrincipal, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            _formPrincipal = formPrincipal;
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
        }

        private void limpiarCampos()
        {
            this.txtEmail.Clear();
            this.txtContrasena.Clear();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioAux = new Usuario()
                {
                    Contrasena = txtContrasena.Text,
                    Mail = txtEmail.Text
                };

                if (_logicaNegocioUsuario.Existe(usuarioAux))
                {
                    if (_logicaNegocioUsuario.ObtenerContrasenaDe(usuarioAux)
                        .Equals(FuncionHash.Hash(txtContrasena.Text)))
                    {
                        _logicaNegocioUsuario.UsuarioLogueado = _logicaNegocioUsuario.ObtenerUsuariosPorMail(usuarioAux.Mail);
                        limpiarCampos();
                        _formPrincipal.esconderBotonInicioYRegistro();
                        _formPrincipal.mostrarBotonCerrarSesion();
                        if (_logicaNegocioUsuario.UsuarioLogueado.Administrador)
                        {
                            _logicaNegocioUsuario.UsuarioLogueado.LoguearA(_logicaNegocioUsuario.UsuarioLogueado.Perfiles[0]);
                            _formPrincipal.MostrarInicio();
                        }
                        else
                        {
                            _formPrincipal.mostrarSeleccionarUsuario();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contrasena incorrecta");
                    }
                }
            }
            catch (UsuarioInvalidoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (LogicaNegocioUsuarioExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error desconocido");
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
        }
    }
}
