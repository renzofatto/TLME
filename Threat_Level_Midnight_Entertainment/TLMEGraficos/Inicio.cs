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

namespace TLMEGraficos
{
    public partial class Inicio : UserControl
    {
        private Form1 _formPrincipal;
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly LogicaNegocioGenero _logicaNegocioGenero;

        public Inicio(Form1 formPrincipal, LogicaNegocioPelicula logicaNegocioPelicula, LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioGenero logicaNegocioGenero)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            _logicaNegocioPelicula = logicaNegocioPelicula;
            _logicaNegocioUsuario  = logicaNegocioUsuario;
            _logicaNegocioGenero = logicaNegocioGenero;
            cmbOrdenar.SelectedItem = cmbOrdenar.Items[0];
            cargarListaPeliculas("Genero");
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            cmbOrdenar.SelectedItem = cmbOrdenar.Items[0];
            cargarListaPeliculas("Genero");
        }

        private void cargarListaPeliculas(string ordenamiento)
        {
            bool mostrarTodas = !_logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado().Infantil;

            dgvPeliculas.Columns.Clear();
            dgvPeliculas.Rows.Clear();
            
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.Text = "Ver";
            btnCol.UseColumnTextForButtonValue = true;
            btnCol.HeaderText = "Ver";
            dgvPeliculas.Columns.Add(imageCol);
            dgvPeliculas.Columns.Add("nombre", "Nombre");
            dgvPeliculas.Columns.Add("descripcion", "Descripcion");
            dgvPeliculas.Columns.Add(btnCol);
            List<Pelicula> peliculas = ordenarPeliculasGenero();
            if (ordenamiento.Equals("Patrocinio"))
            {
                peliculas = ordenarPeliculasPatrocinio();
            }else if (ordenamiento.Equals("Puntaje"))
            {
                peliculas = ordenarPeliculasPuntaje();
            }
            
            foreach (Pelicula pelicula in peliculas)
            {
                if (mostrarTodas)
                {
                    Bitmap img;
                    img = new Bitmap(pelicula.Imagen);
                    btnCol.Name = pelicula.Nombre;
                    dgvPeliculas.Rows.Add(img, pelicula.Nombre, pelicula.Descripcion, btnCol);
                }
                else
                {
                    if (pelicula.ATP)
                    {
                        Bitmap img;
                        img = new Bitmap(pelicula.Imagen);
                        btnCol.Name = pelicula.Nombre;
                        dgvPeliculas.Rows.Add(img, pelicula.Nombre, pelicula.Descripcion, btnCol);
                    }
                }
                
            }
            
        }

        private void dgvPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Pelicula pelicula = new Pelicula();
                int posicionPelicula = dgvPeliculas.Rows[e.RowIndex].Index;
                int indice = cmbOrdenar.SelectedIndex;
                if (indice == 0)
                {
                    pelicula = _logicaNegocioPelicula.ObtenerPeliculaPorNombre(ordenarPeliculasGenero()[posicionPelicula].Nombre);
                }
                else if (indice == 1)
                {
                    pelicula = _logicaNegocioPelicula.ObtenerPeliculaPorNombre(ordenarPeliculasPatrocinio()[posicionPelicula].Nombre);
                }
                else
                {
                    pelicula = _logicaNegocioPelicula.ObtenerPeliculaPorNombre(ordenarPeliculasPuntaje()[posicionPelicula].Nombre);
                }
                _formPrincipal.MostrarPelicula(_logicaNegocioUsuario, _logicaNegocioPelicula, pelicula.Nombre);
            }
            catch (LogicaNegocioPeliculaExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
        }

        private List<Pelicula> ordenarPeliculasGenero()
        {
            List<Pelicula> listaOrdenadaPeliculas = new List<Pelicula>();
            Perfil perfilLogueado = _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado();
            IEnumerable<Genero> listaOrdenadaGeneros = perfilLogueado.Generos.OrderBy(Genero => Genero.Nombre);
            foreach (Genero genero in listaOrdenadaGeneros)
            {
                foreach (Pelicula pelicula in genero.Peliculas.OrderBy(Pelicula => Pelicula.Nombre))
                {
                    if (genero.Nombre.Equals(pelicula.GeneroPrincipal.Nombre))
                    {
                        listaOrdenadaPeliculas.Add(pelicula);
                    }
                }
            }
            return listaOrdenadaPeliculas;
        }
        
        private List<Pelicula> ordenarPeliculasPatrocinio()
        {
            Perfil perfilLogueado = _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado();
            IEnumerable<Genero> listaOrdenadaGeneros = perfilLogueado.Generos.OrderBy(Genero => Genero.Nombre);
            List<Pelicula> listaOrdenada = new List<Pelicula>();
            List<Pelicula> listaDePeliculas = new List<Pelicula>();
            listaDePeliculas = ordenarPeliculasGenero().ToList();
            
            foreach (Pelicula pelicula in listaDePeliculas)
            {
                if (pelicula.Patrocinada)
                {
                    listaOrdenada.Add(pelicula);
                }
            }
            foreach (Genero genero in listaOrdenadaGeneros)
            {
                foreach (Pelicula pelicula in genero.Peliculas.OrderBy(Pelicula => Pelicula.Nombre))
                {
                    if (!pelicula.Patrocinada)
                    {
                        if (genero.Nombre.Equals(pelicula.GeneroPrincipal.Nombre))
                        { 
                            listaOrdenada.Add(pelicula);
                        }
                    }
                    
                }
            }
            return listaOrdenada;
        }

        private List<Pelicula> ordenarPeliculasPuntaje()
        {
            Perfil perfilLogueado = _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado();
            IEnumerable<Genero> listaOrdenadaGenerosPuntaje = perfilLogueado.Generos.OrderByDescending(Genero => Genero.Puntaje);
            List<Pelicula> listaRetorno = new List<Pelicula>();
            foreach (Genero genero in listaOrdenadaGenerosPuntaje)
            {
                genero.Peliculas.OrderBy(Pelicula => Pelicula.Nombre);
            }
            foreach (Genero genero in listaOrdenadaGenerosPuntaje)
            {
                foreach (Pelicula pelicula in genero.Peliculas)
                {
                    if (genero.Nombre.Equals(pelicula.GeneroPrincipal.Nombre))
                    {
                        listaRetorno.Add(pelicula);
                    }
                }
            }
            return listaRetorno;
        }

        private List<Genero> ordenarGeneroPorPutaje(List<Genero> listaGenero)
        {
            List<Genero> retorno = new List<Genero>();
            int contador = 0;
            foreach (Genero genero in listaGenero)
            {
                contador = 0;
                foreach (Pelicula pelicula in genero.Peliculas)
                {
                    contador += pelicula.Puntaje;
                }
                genero.Puntaje = contador;
            }
            return listaGenero;
        }

        private void Ordenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbOrdenar.SelectedIndex;
            if (indice == 0)
            {
                cargarListaPeliculas("Genero");
            }
            else if (indice == 1)
            {
                cargarListaPeliculas("Patrocinio");
            }
            else
            {
                cargarListaPeliculas("Puntaje");
            }
        }

        private void btnPeliculasVisualizadas_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarPeliculasVistas(_logicaNegocioUsuario);
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            _formPrincipal.mostrarBusquedaAvanzada(_logicaNegocioUsuario);
        }
    }
}
