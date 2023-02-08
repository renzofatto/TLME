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
    public partial class AgregarDirector : UserControl
    {
        private readonly LogicaNegocioReparto _logicaNegocioReparto;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly Pelicula _pelicula;
        public AgregarDirector(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioReparto logicaNegocioReparto, Pelicula pelicula)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioReparto = logicaNegocioReparto;
            _pelicula = pelicula;
            cargarCombo();
            cargarListBox();
        }

        private void cargarListBox()
        {
            listBox.Text = "";
            listBox.Items.Clear();
            listBox.Items.AddRange(_pelicula.Directores.ToArray());
        }
        private void cargarCombo()
        {
            cmbReparto.Text = "";
            cmbReparto.Items.Clear();
            cmbReparto.Items.AddRange(_logicaNegocioReparto.ObtenerDirectores().ToArray());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Director directorAAgregar = (Director)cmbReparto.SelectedItem;
                if (!_pelicula.Directores.Contains(directorAAgregar))
                {
                    agregarDirectorAPeliculaAPerfiles(directorAAgregar);
                    MessageBox.Show("Se agrego el director a esta pelicula.");
                    cargarListBox();
                    if (!directorAAgregar.PeliculasDirigidas.Contains(_pelicula))
                    {
                        directorAAgregar.AgregarPeliculaDirigida(_pelicula);
                    }
                }
                else
                {
                    MessageBox.Show("El director ya dirige esta pelicula.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        private void agregarDirectorAPeliculaAPerfiles(Reparto unDirector)
        {
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    foreach (Genero genero in perfil.Generos)
                    {
                        foreach (Pelicula pelicula in genero.Peliculas)
                        {
                            if (!pelicula.Directores.Contains(unDirector) && pelicula.Nombre.Equals(_pelicula.Nombre))
                            {
                                pelicula.Directores.Add(unDirector);
                            }
                        }
                    }
                }
            }
        }
    }
}
