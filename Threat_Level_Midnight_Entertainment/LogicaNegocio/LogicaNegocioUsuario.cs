using System;
using System.Collections.Generic;
using Dominio;

namespace LogicaNegocio
{
    public class LogicaNegocioUsuario
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        private Usuario _usuarioLogueado;
        public LogicaNegocioUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public void Agregar(Usuario unUsuario)
        {
            foreach (Usuario usuario in _repositorioUsuarios.ObtenerUsuarios())
            {
                if (usuario.Nombre.Equals(unUsuario.Nombre))
                {
                    throw new LogicaNegocioUsuarioExcepcion("El nombre del usuario ya esta ingresado en el sistema.");
                }
                
            }
            foreach (Usuario usuario in _repositorioUsuarios.ObtenerUsuarios())
            {
                if (usuario.Mail.Equals(unUsuario.Mail))
                {
                    throw new LogicaNegocioUsuarioExcepcion("El mail ya esta ingresado en el sistema.");
                }

            }
            if (unUsuario.ValidarNombre())
            {
                _repositorioUsuarios.Agregar(unUsuario);
            }
        }

        public bool Existe(Usuario usuarioAuxiliar)
        {
            foreach (Usuario usuario in _repositorioUsuarios.ObtenerUsuarios())
            {
                if (usuario.Mail.Equals(usuarioAuxiliar.Mail))
                {
                    return true;
                }
            }
            throw new LogicaNegocioUsuarioExcepcion("El mail no esta ingresado en el sistema.");
        }

        public string ObtenerContrasenaDe(Usuario usuarioA)
        {
            if (Existe(usuarioA))
            {
                foreach (Usuario usuario in _repositorioUsuarios.ObtenerUsuarios())
                {
                    if (usuario.Mail.Equals(usuarioA.Mail))
                    {
                        return usuario.Contrasena;
                    }
                }
            }
            throw new LogicaNegocioUsuarioExcepcion("El mail no esta ingresado en el sistema.");
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _repositorioUsuarios.ObtenerUsuarios();
        }

        public Usuario ObtenerUsuariosPorMail(string mailABuscar)
        {
            foreach (Usuario usuario in _repositorioUsuarios.ObtenerUsuarios())
            {
                if (usuario.Mail.Equals(mailABuscar))
                {
                    return usuario;
                }
            }
            throw new LogicaNegocioUsuarioExcepcion("El mail no esta ingresado en el sistema.");
        }
        
        public Usuario UsuarioLogueado
        {
            get => _usuarioLogueado;
            set => _usuarioLogueado = value;


        }

    }

}