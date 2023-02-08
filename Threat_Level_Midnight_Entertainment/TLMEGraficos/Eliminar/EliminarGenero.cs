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
    public partial class EliminarGenero : UserControl
    {
        private readonly LogicaNegocioGenero _logicaNegocioGenero;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;

        public EliminarGenero(LogicaNegocioGenero logicaNegocioGenero, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioGenero = logicaNegocioGenero;
            _logicaNegocioUsuario = logicaNegocioUsuario;
            cargarCombo();
        }

        private void EliminarGenero_Load(object sender, EventArgs e)
        {

        }

        private void cargarCombo()
        {
            cmbGeneros.Text = "";
            cmbGeneros.Items.Clear();
            cmbGeneros.Items.AddRange(_logicaNegocioGenero.ObtenerGeneros().ToArray());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                _logicaNegocioGenero.Eliminar((Genero)cmbGeneros.SelectedItem);
                cargarCombo();
                eliminarGeneroAPerfil((Genero)cmbGeneros.SelectedItem);
                MessageBox.Show("Genero eliminado.");
            }
            catch (LogicaNegocioGeneroExcepcion exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception exception)
            {
                
            }

        }

        private void eliminarGeneroAPerfil(Genero unGenero)
        {
            bool continuar = true;
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    continuar = true;
                    for (int i = 0; i < perfil.Generos.Count && continuar; i++)
                    {
                        if (perfil.Generos[i].Nombre.Equals(unGenero.Nombre) && perfil.Generos[i].Descripcion.Equals(unGenero.Descripcion))
                        {
                            perfil.Generos.RemoveAt(i);
                            continuar = false;
                        }
                    }
                }
            }
        }
    }
}
