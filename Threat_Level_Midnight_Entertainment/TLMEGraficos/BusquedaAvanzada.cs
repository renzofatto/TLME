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
    public partial class BusquedaAvanzada : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly Form1 _formPrincipal;
        private List<Pelicula> _listaPeliculas= new List<Pelicula>();
        private IEnumerable<Pelicula> _listaPeliculasOrdenadas = new List<Pelicula>();

        public BusquedaAvanzada(Form1 formPrincipal,LogicaNegocioPelicula logicaNegocioPelicula, LogicaNegocioUsuario logicaNegocioUsuario,LogicaNegocioReparto logicaNegocioReparto)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _logicaNegocioPelicula = logicaNegocioPelicula;
            _formPrincipal = formPrincipal;
            cmbOrdenar.SelectedItem = cmbOrdenar.Items[0];
            //cargarListaPeliculas("Genero");
            radioBtnDirector.Checked = true;
            cargarReparto("Director");
            lblReparto.Text = "Directores:";
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

        private void radioBtnDirector_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDirector.Checked)
            {
                cargarReparto("Director");
                lblReparto.Text = "Directores:";
            }
        }

        private void radioBtnActor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnActor.Checked)
            {
                cargarReparto("Actor");
                lblReparto.Text = "Actores:";
            }
        }

        private void cargarReparto(string rol)
        {
            chkListReparto.Items.Clear();
            int posicion = 0;
            bool agregar = true;

            if (rol.Equals("Director"))
            {
                foreach (Reparto reparto in _logicaNegocioReparto.ObtenerRepartos())
                {
                    if (reparto.GetType()== typeof(Director))
                    {
                        posicion++;
                    }
                }
                Reparto[] listaRepartos = new Reparto[posicion];

                for (int i = 0; i < posicion; i++)
                {
                    foreach (Reparto reparto in _logicaNegocioReparto.ObtenerRepartos())
                    {
                        if (reparto.GetType() == typeof(Director))
                        {
                            for (int j = 0; j < listaRepartos.Length; j++)
                            {
                                if (listaRepartos[j]!= null && listaRepartos[j].Nombre.Equals(reparto.Nombre))
                                {
                                    agregar = false;
                                }
                            }

                            if (agregar)
                            {
                                listaRepartos[i] = reparto;
                            }
                        }
                    }
                }
                chkListReparto.Items.AddRange(listaRepartos);
            }
            else
            {
                foreach (Reparto reparto in _logicaNegocioReparto.ObtenerRepartos())
                {
                    if (reparto.GetType() == typeof(Actor))
                    {
                        posicion++;
                    }
                }
                Reparto[] listaRepartos = new Reparto[posicion];
                for (int i = 0; i < posicion; i++)
                {
                    foreach (Reparto reparto in _logicaNegocioReparto.ObtenerRepartos())
                    {
                        if (reparto.GetType() == typeof(Actor))
                        {
                            for (int j = 0; j < listaRepartos.Length; j++)
                            {
                                if (listaRepartos[j] != null && listaRepartos[j].Nombre.Equals(reparto.Nombre))
                                {
                                    agregar = false;
                                }
                            }

                            if (agregar)
                            {
                                listaRepartos[i] = reparto;
                            }
                        }
                    }
                }
                chkListReparto.Items.AddRange(listaRepartos);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool buscarDirector = false;
            bool mostrar = true;
            List<Reparto> listaRepartos = new List<Reparto>();
            _listaPeliculas = new List<Pelicula>();
            if (radioBtnDirector.Checked)
            {
                buscarDirector = true;
            }

            for (int i = 0; i < chkListReparto.CheckedItems.Count; i++)
            {
                foreach (Reparto reparto in _logicaNegocioReparto.ObtenerRepartos())
                {
                    if (reparto.Nombre.Equals(chkListReparto.CheckedItems[i].ToString()))
                    {
                        listaRepartos.Add(reparto);
                    }
                }
            }

            if (buscarDirector)
            {
                foreach (Reparto reparto in listaRepartos)
                {
                    if (reparto.GetType() == typeof(Director))
                    {
                        Director director = (Director)reparto;
                        foreach (Pelicula pelicula in director.PeliculasDirigidas)
                        {
                            mostrar = true;
                            
                            foreach (Reparto directorAuxiliar in listaRepartos)
                            {
                                if (!pelicula.Directores.Contains(directorAuxiliar))
                                {
                                    mostrar = false;
                                }
                            }

                            if (mostrar && !_listaPeliculas.Contains(pelicula))
                            {
                                _listaPeliculas.Add(pelicula);
                            }
                        }
                    }
                    
                }
            }
            else
            {
                foreach (Reparto reparto in listaRepartos)
                {
                    Actor actor = (Actor)reparto;
                    foreach (Pelicula pelicula in actor.PeliculasActuadas)
                    {
                        mostrar = true;

                        foreach (Reparto actorAuxiliar in listaRepartos)
                        {
                            if (!pelicula.Actores.Contains(actorAuxiliar))
                            {
                                mostrar = false;
                            }
                        }

                        if (mostrar && !_listaPeliculas.Contains(pelicula))
                        {
                            _listaPeliculas.Add(pelicula);
                        }
                    }
                }
            }
            cargarListaPeliculasFiltrada(cmbOrdenar.SelectedItem.ToString(), _listaPeliculas);
        }

        private void cargarListaPeliculasFiltrada(string ordenamiento, List<Pelicula> listaPeliculas)
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

            _listaPeliculasOrdenadas = new List<Pelicula>();

            if (ordenamiento.Equals("Alfabeticamente"))
            {
                _listaPeliculasOrdenadas = ordenarPeliculasAlfabeticamente(listaPeliculas);
            }
            else if (ordenamiento.Equals("Estreno"))
            {
                _listaPeliculasOrdenadas = ordenarPeliculasEstreno(listaPeliculas);
            }

            foreach (Pelicula pelicula in _listaPeliculasOrdenadas)
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

        private IEnumerable<Pelicula> ordenarPeliculasEstreno(List<Pelicula> listaPeliculas)
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
                        foreach (Pelicula peliculaAux in listaPeliculas)
                        {
                            if (peliculaAux.Nombre.Equals(pelicula.Nombre))
                            {
                                listaOrdenadaPeliculas.Add(pelicula);
                            }
                        }
                    }
                }
            }
            return listaOrdenadaPeliculas.OrderBy(Pelicula => Pelicula.Estreno);
        }

        private IEnumerable<Pelicula> ordenarPeliculasAlfabeticamente(List<Pelicula> listaPeliculas)
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
                        foreach (Pelicula peliculaAux in listaPeliculas)
                        {
                            if (peliculaAux.Nombre.Equals(pelicula.Nombre))
                            {
                                listaOrdenadaPeliculas.Add(pelicula);
                            }
                        }
                    }
                }
            }
            return listaOrdenadaPeliculas.OrderBy(Pelicula => Pelicula.Nombre);
        }

        private void dgvPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Pelicula pelicula = new Pelicula();
                int posicionPelicula = dgvPeliculas.Rows[e.RowIndex].Index;
                int orden = cmbOrdenar.SelectedIndex;
                int contador = 0;
                Pelicula[] listaPeliculas = new Pelicula[_listaPeliculasOrdenadas.Count()];
                //Alfabeticamente
                if (orden == 0)
                {
                    foreach (Pelicula peliculasOrdenadas in ordenarPeliculasAlfabeticamente(_listaPeliculas))
                    {
                        listaPeliculas[contador] = peliculasOrdenadas;
                        contador++;
                    }

                    pelicula = listaPeliculas[posicionPelicula];
                }
                //Cronologicamente
                else if (orden == 1)
                {
                    {
                        foreach (Pelicula peliculasOrdenadas in ordenarPeliculasEstreno(_listaPeliculas))
                        {
                            listaPeliculas[contador] = peliculasOrdenadas;
                            contador++;
                        }

                        pelicula = listaPeliculas[posicionPelicula];
                    }
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
    }
}
