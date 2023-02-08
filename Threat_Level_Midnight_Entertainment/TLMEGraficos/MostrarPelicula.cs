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
    public partial class MostrarPelicula : UserControl
    {
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly Form1 _formPrincipal;
        private Pelicula _pelicula;

        public MostrarPelicula(Form1 formPrincipal, LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioPelicula logicaNegocioPelicula, LogicaNegocioReparto logicaNegocioReparto, string nombrePelicula)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _logicaNegocioPelicula = logicaNegocioPelicula;
            comboCalificacion.SelectedIndex = 0;
            _pelicula = buscarPelicula(nombrePelicula);
            picBoxImagen.ImageLocation = _pelicula.Imagen;
            this.btnAgregarActor.Hide();
            this.btnAgregarDirector.Hide();
            this.btnEliminarActor.Hide();
            this.btnEliminarDirector.Hide();
            mostrarBotonesAdmin();
        }
        
        private void mostrarBotonesAdmin()
        {
            if (_logicaNegocioUsuario.UsuarioLogueado.Administrador)
            {
                this.btnAgregarActor.Show();
                this.btnAgregarDirector.Show();
                this.btnEliminarActor.Show();
                this.btnEliminarDirector.Show();
            }
        }
        private void MostrarPelicula_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = _pelicula.Nombre;
            lblDescripcion.Text = _pelicula.Descripcion;
            lblGeneroPrincipal.Text = _pelicula.GeneroPrincipal.Nombre;
            mostrarDirectores();
            mostrarGenerosSecundarios();
            mostrarActuaciones();
            if (_pelicula.Vista)
            {
                lblVisualizar.Text = "Visualizada";
            }
            
        }

        private void mostrarDirectores()
        {
            string directoresAMostrar = "";
            if (_pelicula.Directores!= null )
            {
                foreach (Reparto director in _pelicula.Directores)
                {
                    if (directoresAMostrar.Equals(""))
                    {
                        directoresAMostrar += $"{director.Nombre}";
                    }
                    else
                    {
                        directoresAMostrar += $" - {director.Nombre}";
                    }
                }
            }
            else
            {
                directoresAMostrar = "No tiene director";
            }
            lblDirectores.Text = directoresAMostrar;
        }
        
        private void mostrarGenerosSecundarios()
        {
            string generosSecundariosAMostrar = "";
            if (_pelicula.GeneroSecundario != null)
            {
                foreach (Genero genero in _pelicula.GeneroSecundario)
                {
                    if (generosSecundariosAMostrar.Equals(""))
                    {
                        generosSecundariosAMostrar += $"{genero.Nombre}";
                    }
                    else
                    {
                        generosSecundariosAMostrar += $" - {genero.Nombre}";
                    }
                }
            }
            else
            {
                generosSecundariosAMostrar = "No tiene generos secundarios";
            }
            lblMostrarGenerosSecundarios.Text = generosSecundariosAMostrar;
        }

        private void mostrarActuaciones()
        {
            lBoxReparto.Text = "";
            lBoxReparto.Items.Clear();
            lBoxReparto.Items.AddRange(_pelicula.Actuaciones.ToArray());
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            _pelicula.Visualizar();
            lblVisualizar.Text = "Visualizada";
            if (!_logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().PeliculasVistas.Contains(_pelicula))
            {
                _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().PeliculasVistas.Add(_pelicula);
            }
            MessageBox.Show("La pelicula se visualizo");
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            string calificacion = comboCalificacion.SelectedItem.ToString();
            calificarPelicula(calificacion);
        }

        private void calificarPelicula(string criterio)
        {
            switch (criterio)
            {
                case "Negativa":
                    _pelicula.CalificacionNegativa();
                    break;
                case "Positiva":
                    _pelicula.CalificacionPositiva();
                    break;
                case "Muy Positiva":
                    _pelicula.CalificacionMuyPositiva();
                    break;
            }

            MessageBox.Show("Calificada");

        }

        private Pelicula buscarPelicula(String nombrePelicula)
        {
            Pelicula peliculaAMostrar = new Pelicula();
            Perfil perfilLogeado = _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado();
            foreach (Genero genero in perfilLogeado.Generos)
            {
                foreach (Pelicula pelicula in genero.Peliculas)
                {
                    if (pelicula.Nombre.Equals(nombrePelicula))
                    {
                        peliculaAMostrar = pelicula;
                    }
                }
            }
            return peliculaAMostrar;
        }

        private void btnAgregarDirector_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarAgregarDirector(_logicaNegocioUsuario, _logicaNegocioReparto, _pelicula);
        }

        private void btnAgregarActor_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarAgregarActor(_logicaNegocioUsuario, _logicaNegocioReparto, _pelicula);
        }

        private void btnEliminarDirector_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarEliminarDirector(_logicaNegocioUsuario, _logicaNegocioReparto, _pelicula);
        }

        private void btnEliminarActor_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarEliminarActor(_logicaNegocioUsuario, _logicaNegocioReparto, _pelicula);
        }
    }
}
