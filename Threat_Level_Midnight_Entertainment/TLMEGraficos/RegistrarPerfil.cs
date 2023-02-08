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
    public partial class RegistrarPerfil : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioGenero _logicaNegocioGenero;
        private readonly Usuario _usuario;
        private Form1 _formPrincipal;

        public RegistrarPerfil(Form1 formPrincipal, LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioGenero logicaNegocioGenero, LogicaNegocioPelicula logicaNegocioPelicula, Usuario usuario)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioPelicula = logicaNegocioPelicula;
            _logicaNegocioGenero = logicaNegocioGenero;
            _usuario = usuario;
            _formPrincipal = formPrincipal;
            if (_usuario.Perfiles.Count == 0)
            {
                chkInfantil.Hide();
                chkInfantil.CheckState = CheckState.Unchecked;
            }
            else
            {
                chkInfantil.Show();
            }
        }

        private void RegistrarPerfil_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkInfantil.Checked)
            {
                try
                {
                    Perfil nuevoPerfil = new Perfil()
                    {
                        Alias = txtAlias.Text,
                        Pin = 12345,
                        Owner = _usuario.Perfiles.Count == 0,
                        Infantil = chkInfantil.CheckState == CheckState.Checked
                    };
                    nuevoPerfil.ValidarAlias();
                    nuevoPerfil.ClonarGeneros(_logicaNegocioGenero.ObtenerGeneros());
                    nuevoPerfil.ClonarPeliculas(_logicaNegocioPelicula.ObtenerPelicula());
                    _usuario.AgregarPerfil(nuevoPerfil);
                    MessageBox.Show("Perfil agregado corectamente.");
                    limpiarCampos();
                    if (_logicaNegocioUsuario.UsuarioLogueado == null)
                    {
                        _formPrincipal.mostrarBotonInicioYRegistro();
                        _formPrincipal.MostrarIniciarSesion();
                    }
                }
                catch (PerfilInvalidoExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
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
            else if (txtPin.Text.Equals(txtConfirmarPin.Text))
            {
                try
                {
                    Perfil nuevoPerfil = new Perfil()
                    {
                        Alias = txtAlias.Text,
                        Pin = Int32.Parse(txtPin.Text),
                        Owner = _usuario.Perfiles.Count == 0,
                        Infantil = chkInfantil.CheckState == CheckState.Checked
                    };
                    nuevoPerfil.ValidarAlias();
                    nuevoPerfil.ValidarPin(txtPin.Text);
                    nuevoPerfil.ClonarGeneros(_logicaNegocioGenero.ObtenerGeneros());
                    nuevoPerfil.ClonarPeliculas(_logicaNegocioPelicula.ObtenerPelicula());
                    _usuario.AgregarPerfil(nuevoPerfil);
                    MessageBox.Show("Perfil agregado corectamente.");
                    limpiarCampos();
                    if (_logicaNegocioUsuario.UsuarioLogueado == null)
                    {
                        _formPrincipal.mostrarBotonInicioYRegistro();
                        _formPrincipal.MostrarIniciarSesion();
                    }
                }
                catch (PerfilInvalidoExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (UsuarioInvalidoExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El pin debe ser numerico.");
                }
            }
            else
            {
                MessageBox.Show("Los pin no coinciden.");
            }
        }
        private void limpiarCampos()
        {
            this.txtPin.Clear();
            this.txtAlias.Clear();
            this.txtConfirmarPin.Clear();
            this.chkInfantil.CheckState = CheckState.Unchecked;
        }

        private void chkInfantil_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfantil.Checked)
            {
                txtPin.Hide();
                txtConfirmarPin.Hide();
                lblConfirmarPin.Hide();
                lblPin.Hide();
            }
            else
            {
                txtPin.Show();
                txtConfirmarPin.Show();
                lblConfirmarPin.Show();
                lblPin.Show();
            }
        }
    }
}
