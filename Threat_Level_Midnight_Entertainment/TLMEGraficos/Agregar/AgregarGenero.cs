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
    public partial class AgregarGenero : UserControl
    {
        private readonly LogicaNegocioGenero _logicaNegocioGenero;
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;

        public AgregarGenero( LogicaNegocioGenero logicaNegocioGenero, LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioGenero = logicaNegocioGenero;
            _logicaNegocioUsuario = logicaNegocioUsuario;
            borrarCampos();
        }

        private void AgregarGenero_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Genero genero = new Genero()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text
                };
                _logicaNegocioGenero.Agregar(genero);
                agregarGeneroAPerfiles(genero);
                MessageBox.Show("Genero creado");
                borrarCampos();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void agregarGeneroAPerfiles(Genero unGenero)
        {
            foreach (Usuario usuario in _logicaNegocioUsuario.ObtenerUsuarios())
            {
                foreach (Perfil perfil in usuario.Perfiles)
                {
                    perfil.AgregarGeneroClonado(unGenero);
                }
            }
        }

        private void borrarCampos()
        {
            txtDescripcion.Clear();
            txtNombre.Clear();
        }
    }
}
