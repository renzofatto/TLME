using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dominio;
using Dominio.Excepciones;
using LogicaNegocio;

namespace TLMEGraficos
{
    public partial class AgregarPelicula : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        private readonly LogicaNegocioPelicula _logicaNegocioPelicula;
        private readonly LogicaNegocioGenero _logicaNegocioGenero;
        
        public AgregarPelicula(LogicaNegocioUsuario logicaNegocioUsuario, LogicaNegocioPelicula logicaNegocioPelicula, LogicaNegocioGenero logicaNegocioGenero)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            _logicaNegocioPelicula = logicaNegocioPelicula;
            _logicaNegocioGenero = logicaNegocioGenero;
            cargarGeneroPrimario();
            cargarGenerosSecundarios();
        }

        private void cargarGenerosSecundarios()
        {
            chkListGenerosSecundarios.Items.Clear();
            for (int i = 0; i < chkListGenerosSecundarios.Items.Count; i++)
            {
                chkListGenerosSecundarios.SetItemChecked(i, false);
                chkListGenerosSecundarios.SetItemCheckState(i, CheckState.Unchecked);
            }
            chkListGenerosSecundarios.Items.AddRange(_logicaNegocioGenero.ObtenerGeneros().ToArray());
            chkListGenerosSecundarios.Items.Remove(cmbGenero.SelectedItem);
        }
        
        private void cargarGeneroPrimario()
        {
            cmbGenero.Items.Clear();
            cmbGenero.Items.AddRange(_logicaNegocioGenero.ObtenerGeneros().ToArray());
            try
            {
                cmbGenero.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        private void AgregarPelicula_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (path.Text != "" && (Genero)cmbGenero.SelectedItem!=null)
            {
                try
                {
                    Pelicula nuevaPelicula = new Pelicula
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        ATP = chkATP.CheckState == CheckState.Checked,
                        GeneroPrincipal = (Genero)cmbGenero.SelectedItem,
                        Imagen = path.Text,
                        Patrocinada = chkPatrocinada.CheckState == CheckState.Checked,
                        Estreno = dateEstreno.Value
                    };
                    for (int i = 0; i < chkListGenerosSecundarios.CheckedItems.Count; i++)
                    {
                        nuevaPelicula.GeneroSecundario.Add(
                            _logicaNegocioGenero.ObtenerGeneroPorNombre(
                                chkListGenerosSecundarios.CheckedItems[i].ToString()));
                        _logicaNegocioGenero.ObtenerGeneroPorNombre(
                            chkListGenerosSecundarios.CheckedItems[i].ToString()).Peliculas.Add(nuevaPelicula);
                    }

                    nuevaPelicula.GeneroPrincipal.Peliculas.Add(nuevaPelicula);

                    _logicaNegocioPelicula.Agregar(nuevaPelicula);
                    agregarPeliculaAPerfiles(nuevaPelicula);

                    MessageBox.Show("Pelicula agregada corectamente.");
                    limpiarCampos();
                }
                catch (PeliculaInvalidaExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (LogicaNegocioGeneroExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (GeneroInvalidoExcepcion ex)
                {
                    MessageBox.Show(ex.Message);
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
                MessageBox.Show("Debe ingresar un genero");
            }
            
        }

        private void agregarPeliculaAPerfiles(Pelicula unaPelicula)
        {
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    Pelicula peliculaClon = unaPelicula.Clon();
                    perfil.Peliculas.Add(peliculaClon);
                    foreach (Genero genero in perfil.Generos)
                    {
                        if (genero.Nombre.Equals(unaPelicula.GeneroPrincipal.Nombre))
                        {
                            peliculaClon.GeneroPrincipal = genero;
                            genero.Peliculas.Add(peliculaClon);
                        }
                    }
                    List<Genero> auxiliarGeneros = new List<Genero>();
                    for (int i = 0; i < chkListGenerosSecundarios.CheckedItems.Count; i++)
                    {
                        foreach (Genero genero in perfil.Generos)
                        {
                            if (genero.Nombre.Equals(chkListGenerosSecundarios.CheckedItems[i].ToString()))
                            {
                                auxiliarGeneros.Add(genero);
                                genero.Peliculas.Add(peliculaClon);
                            }
                        }
                    }

                    peliculaClon.GeneroSecundario = auxiliarGeneros;

                }
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            pictureBox1.Image = null;
            chkListGenerosSecundarios.ClearSelected();
            chkATP.Checked = false;
            cmbGenero.SelectedItem = 0;
            cargarGenerosSecundarios();
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGenerosSecundarios();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = path.Text;
            }
        }
    }
}
