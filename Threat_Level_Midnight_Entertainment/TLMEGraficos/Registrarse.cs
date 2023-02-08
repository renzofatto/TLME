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
    public partial class Registrarse : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private Form1 _formPrincipal;

        public Registrarse(Form1 formPrincipal, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _formPrincipal = formPrincipal;
        }

        private void Registrarse_Load(object sender, EventArgs e)
        {
            
        }

        private void limpiarCampos()
        {
            this.txtEmail.Clear();
            this.txtContrasena.Clear();
            this.txtConfirmarContrasena.Clear();
            this.txtUsuario.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.Text.Equals(txtContrasena.Text))
            {
                try
                {
                    Usuario nuevoUsuario = new Usuario()
                    {
                        Nombre = txtUsuario.Text,
                        Mail = txtEmail.Text,
                        Contrasena = txtContrasena.Text
                    };
                    nuevoUsuario.ValidarMail();
                    _logicaNegocioUsuario.Agregar(nuevoUsuario);
                    MessageBox.Show("Usuario agregado corectamente");
                    limpiarCampos();
                    _formPrincipal.esconderBotonInicioYRegistro();
                    _formPrincipal.MostrarRegistrarPerfil(_logicaNegocioUsuario.ObtenerUsuariosPorMail(nuevoUsuario.Mail));
                }
                catch (UsuarioInvalidoExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error desconocido");
                }
            }
            else
            {
                MessageBox.Show("Las contrasenas no coinciden");
            }
            
        }
    }
}
