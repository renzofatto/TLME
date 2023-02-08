using System.Collections.Generic;
using Dominio;

namespace LogicaNegocio
{
    public interface IRepositorioUsuarios
    {
        void Agregar(Usuario unUsuario);
        List<Usuario> ObtenerUsuarios();
    }
}