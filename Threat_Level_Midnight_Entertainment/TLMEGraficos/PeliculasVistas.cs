using Dominio;
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
    public partial class PeliculasVistas : UserControl
    {
        private readonly LogicaNegocioUsuario _logicaNegocioUsuario;

        public PeliculasVistas(LogicaNegocioUsuario logicaNegocioUsuario)
        {
            InitializeComponent();
            _logicaNegocioUsuario = logicaNegocioUsuario;
            cargarLista();
        }

        public void cargarLista()
        {
            lBoxPeliculas.Text = "";
            lBoxPeliculas.Items.Clear();
            Perfil perfil = _logicaNegocioUsuario.UsuarioLogueado.PerfilLogueado();
            int peliculasVistas = perfil.PeliculasVistas.Count;
            int maxDirectores = 3;
            int maxActores = 5;
            string directores = "";
            string actores = "";

            string[] array = new string[peliculasVistas];
            
            for (int i = 0; i < peliculasVistas; i++)
            {
                directores = "";
                actores = "";
                maxActores = 5;
                maxDirectores = 3;

                if (perfil.PeliculasVistas[i].Directores.Count<maxDirectores)
                {
                    maxDirectores = perfil.PeliculasVistas[i].Directores.Count;
                }

                if (perfil.PeliculasVistas[i].Actores.Count<maxActores)
                {
                    maxActores = perfil.PeliculasVistas[i].Actores.Count;
                }

                for (int j = 0; j < maxDirectores; j++)
                {
                    if (directores.Equals(""))
                    {
                        directores += $"{perfil.PeliculasVistas[i].Directores[j]}";
                    }
                    else
                    {
                        directores += $" - {perfil.PeliculasVistas[i].Directores[j]}";
                    }
                }

                for (int k = 0; k < maxActores; k++)
                {
                    if (actores.Equals(""))
                    {
                        actores += $"{perfil.PeliculasVistas[i].Actores[k]}";
                    }
                    else
                    {
                        actores += $" - {perfil.PeliculasVistas[i].Actores[k]}";
                    }
                }

                if (directores.Equals(""))
                {
                    directores = " no tiene";
                }

                if (actores.Equals(""))
                {
                    actores = " no tiene";
                }

                array[i] = $"Pelicula: {perfil.PeliculasVistas[i].Nombre}; Directores: {directores}; Actores: {actores}";
            }

            lBoxPeliculas.Text = "";
            lBoxPeliculas.Items.Clear();
            lBoxPeliculas.Items.AddRange(array);
        }
    }
}
