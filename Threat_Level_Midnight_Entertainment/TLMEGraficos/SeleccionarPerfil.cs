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
    public partial class SeleccionarPerfil : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;
        public SeleccionarPerfil(LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {

        }
    }
}
