using LogicaNegocio;
using RepositorioEnMemoria;
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

namespace TLMEGraficos
{
    public partial class Form1 : Form
    {
        private readonly LogicaNegocioUsuario logicaNegocioUsuario;
        private readonly LogicaNegocioPelicula logicaNegocioPelicula;
        private readonly LogicaNegocioGenero logicaNegocioGenero;
        private readonly LogicaNegocioReparto logicaNegocioReparto;
        
        public Form1()
        {
            InitializeComponent();
            inicializarBotones();

            this.controlLayaoutPanel.Controls.Clear();
            
            logicaNegocioUsuario = new LogicaNegocioUsuario(new RepositorioUsuariosImpl());
            logicaNegocioPelicula = new LogicaNegocioPelicula(new RepositorioPeliculasImpl());
            logicaNegocioGenero = new LogicaNegocioGenero(new RepositorioGenerosImpl());
            logicaNegocioReparto = new LogicaNegocioReparto(new RepositorioRepartoImpl());
            Usuario usuarioAdministrador = new Usuario()
            {
                Mail = "admin@admin.com",
                Contrasena = "adminadmin",
                Nombre = "Administrador",
                Administrador = true
            };
            Perfil perfilAdmin = new Perfil()
            {
                Alias = "Administrador",
                Owner = true,
            };
            usuarioAdministrador.AgregarPerfil(perfilAdmin);
            logicaNegocioUsuario.Agregar(usuarioAdministrador);

            UserControl iniciarSesion = new IniciarSesion(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(iniciarSesion);
            
        }

        private void inicializarBotones()
        {
            this.btnIniciarSesion.Show();
            this.btnRegistrarse.Show();
            this.btnCerrarSesion.Hide();
            this.btnInicio.Hide();
            this.btnRegistrarPerfil.Hide();
            this.btnCambiarPerfil.Hide();
            this.btnAgregarGenero.Hide();
            this.btnAgregarPelicula.Hide();
            this.btnEliminarGenero.Hide();
            this.btnEliminarPelicula.Hide();
            this.btnAgregarReparto.Hide();
            this.btnEliminarReparto.Hide();
        }

        private void mostrarBotonesAdmin()
        {
            if (logicaNegocioUsuario.UsuarioLogueado.Administrador)
            {
                this.btnRegistrarPerfil.Hide();
                this.btnAgregarGenero.Show();
                this.btnAgregarPelicula.Show();
                this.btnEliminarGenero.Show();
                this.btnEliminarPelicula.Show();
                this.btnAgregarReparto.Show();
                this.btnEliminarReparto.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl iniciarSesion = new IniciarSesion(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(iniciarSesion);
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl registrarse = new Registrarse(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(registrarse);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl iniciarSesion = new IniciarSesion(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(iniciarSesion);
            inicializarBotones();
            try
            {
                logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().Logged = false;
                logicaNegocioUsuario.UsuarioLogueado = null;
            }
            catch (Exception exception)
            {
                logicaNegocioUsuario.UsuarioLogueado = null;
            }
        }

        private void btnRegistrarPerfil_Click(object sender, EventArgs e)
        {
            MostrarRegistrarPerfil(logicaNegocioUsuario.UsuarioLogueado);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            esconderBotonInicioYRegistro();
            esconderBotonRegistrarPerfil();
            mostrarBotonCambiarPerfil();
            this.btnInicio.Show();
            this.btnCerrarSesion.Show();
            this.btnRegistrarPerfil.Show();
            mostrarBotonesAdmin();
            Inicio inicio = new Inicio(this, logicaNegocioPelicula, logicaNegocioUsuario, logicaNegocioGenero);
            controlLayaoutPanel.Controls.Add(inicio);
        }

        internal void esconderBotonInicioYRegistro()
        {
           this.btnIniciarSesion.Hide();
           this.btnRegistrarse.Hide();
        }
        
        internal void mostrarBotonInicioYRegistro()
        {
           this.btnIniciarSesion.Show();
           this.btnRegistrarse.Show();
        }

        internal void mostrarBotonCerrarSesion()
        {
            this.btnCerrarSesion.Show();
        }
        
        internal void mostrarSeleccionarUsuario()
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl ventanaPrincipal = new SeleccionarUsuario(this, logicaNegocioUsuario);
            this.btnRegistrarPerfil.Show();
            controlLayaoutPanel.Controls.Add(ventanaPrincipal);
        }
        
        internal void mostrarAgregarDirector(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl agregarDirector = new AgregarDirector(logicaNegocioUsuario, logicaNegocioReparto, pelicula);
            controlLayaoutPanel.Controls.Add(agregarDirector);
        }
        
        internal void mostrarAgregarActor(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl agregarActor = new AgregarActor(logicaNegocioUsuario, logicaNegocioReparto, pelicula);
            controlLayaoutPanel.Controls.Add(agregarActor);
        }

        internal void MostrarRegistrarPerfil(Usuario usuario)
        {
            controlLayaoutPanel.Controls.Clear();
            RegistrarPerfil registrarPerfil = new RegistrarPerfil(this, logicaNegocioUsuario,logicaNegocioGenero,logicaNegocioPelicula, usuario);
            controlLayaoutPanel.Controls.Add(registrarPerfil);
        }

        internal void MostrarIniciarSesion()
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl iniciarSesion = new IniciarSesion(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(iniciarSesion);
        }

        internal void MostrarInicio()
        {
            controlLayaoutPanel.Controls.Clear();
            this.esconderBotonInicioYRegistro();
            this.btnInicio.Show();
            this.btnCerrarSesion.Show();
            esconderBotonRegistrarPerfil();
            mostrarBotonCambiarPerfil();
            mostrarBotonesAdmin();
            Inicio inicio = new Inicio(this, logicaNegocioPelicula, logicaNegocioUsuario, logicaNegocioGenero);
            controlLayaoutPanel.Controls.Add(inicio);
        }

        internal void esconderBotonRegistrarPerfil()
        {
            if (logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().Owner)
            {
                this.btnRegistrarPerfil.Show();
            }
            else
            {
                this.btnRegistrarPerfil.Hide();
            }
        }

        private void btnCambiarPerfil_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl seleccionarUsuario = new SeleccionarUsuario(this, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(seleccionarUsuario);
        }

        private void mostrarBotonCambiarPerfil()
        {
            if (logicaNegocioUsuario.UsuarioLogueado.Perfiles.Count>1)
            {
                this.btnCambiarPerfil.Show();
            }

            if (logicaNegocioUsuario.UsuarioLogueado.Administrador)
            {
                this.btnCambiarPerfil.Hide();
                this.btnRegistrarPerfil.Hide();
            }
        }

        private void btnAgregarPelicula_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl agregarPelicula = new AgregarPelicula(logicaNegocioUsuario, logicaNegocioPelicula, logicaNegocioGenero);
            controlLayaoutPanel.Controls.Add(agregarPelicula);
        }

        private void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl agregarGenero = new AgregarGenero(logicaNegocioGenero, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(agregarGenero);
        }

        private void btnEliminarGenero_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl eliminarGenero = new EliminarGenero(logicaNegocioGenero, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(eliminarGenero);
        }

        internal void MostrarPelicula(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioPelicula logicaNegocioPelicula, string nombrePelicula)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl mostrarPelicula = new MostrarPelicula(this, logicaNegocioUsuario, logicaNegocioPelicula, logicaNegocioReparto, nombrePelicula);
            controlLayaoutPanel.Controls.Add(mostrarPelicula);
        }

        private void btnEliminarPelicula_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl eliminarPelicula = new EliminarPelicula(logicaNegocioPelicula, logicaNegocioGenero, logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(eliminarPelicula);
        }

        private void btnAgregarReparto_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl agregarReparto = new AgregarReparto(logicaNegocioReparto);
            controlLayaoutPanel.Controls.Add(agregarReparto);
        }

        private void btnEliminarReparto_Click(object sender, EventArgs e)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl eliminaReparto = new EliminarReparto(logicaNegocioReparto);
            controlLayaoutPanel.Controls.Add(eliminaReparto);
        }

        internal void mostrarEliminarDirector(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl eliminarDirector = new EliminarDirector(logicaNegocioUsuario, logicaNegocioReparto, pelicula);
            controlLayaoutPanel.Controls.Add(eliminarDirector);
        }

        internal void mostrarEliminarActor(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl eliminarActor = new EliminarActor(logicaNegocioUsuario, logicaNegocioReparto, pelicula);
            controlLayaoutPanel.Controls.Add(eliminarActor);
        }

        internal void mostrarPeliculasVistas(LogicaNegocioUsuario logicaNegocioUsuario)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl peliculasVistas = new PeliculasVistas(logicaNegocioUsuario);
            controlLayaoutPanel.Controls.Add(peliculasVistas);
        }

        internal void mostrarBusquedaAvanzada(LogicaNegocioUsuario logicaNegocioUsuario)
        {
            controlLayaoutPanel.Controls.Clear();
            UserControl busquedaAvanzada = new BusquedaAvanzada(this, logicaNegocioPelicula, logicaNegocioUsuario, logicaNegocioReparto);
            controlLayaoutPanel.Controls.Add(busquedaAvanzada);
        }
    }
}
