using Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Usuario
    {
        private const int largoMaxContrasena = 30;
        private const int largoMinContrasena = 10;
        private const int largoMaxNombre = 20;
        private const int largoMinNombre = 10;
        private string _contrasena;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        private List<Perfil> _perfiles = new List<Perfil>();

        public string Contrasena
        {
            get => _contrasena;
            set
            {
                if (ValidarContrasena(value))
                {
                    _contrasena = FuncionHash.Hash(value, 1000);
                }
                else
                {
                    throw new UsuarioInvalidoExcepcion("Contrasena invalida");
                }
                    
            }
        }
        public bool Administrador { get; set; }

        public List<Perfil> Perfiles
        {
            get => _perfiles;
            set => _perfiles = value;
        }
        public bool Logged { get; set; }

        public void AgregarPerfil(Perfil unPerfil)
        {
            foreach (Perfil perfil in Perfiles)
            {
                if (perfil.Alias.Equals(unPerfil.Alias))
                {
                    throw new UsuarioInvalidoExcepcion("El perfil ya esta ingresado en el sistema.");
                }

            }
            if (_perfiles.Count < 4)
            {
                Perfiles.Add(unPerfil);
            }
            else
            {
                throw new UsuarioInvalidoExcepcion("No es posible agregar mas de 3 perfiles");
            }
            
        }

        public bool CoincideContrasena(string unaContrasena)
        {
            return FuncionHash.Hash(unaContrasena, 1000).Equals(this.Contrasena);
        }

        public bool ValidarContrasena(string unaContrasena)
        {
            if (unaContrasena.Length < largoMinContrasena)
            {
                throw new UsuarioInvalidoExcepcion($"La contrasena debe tener mas de {largoMinContrasena} caracteres.");
            }
            if (unaContrasena.Length > largoMaxContrasena)
            {
                throw new UsuarioInvalidoExcepcion($"La contrasena debe tener menos de {largoMaxContrasena} caracteres.");
            }
            return true;
        }

        public bool ValidarMail()
        {
            Regex rgx = new Regex(@"(\w*)@(\w*).com");
            if (rgx.IsMatch(this.Mail))
            {
                return true;
            }
            else
            {
                throw new UsuarioInvalidoExcepcion("El formato del mail es invalido");
            }
        }

        public bool ValidarNombre()
        {
            if (this.Nombre.Equals(""))
            {
                throw new UsuarioInvalidoExcepcion("El nombre de usuario no puede ser vacío.");
            }
            if (this.Nombre.Length < largoMinNombre)
            {
                throw new UsuarioInvalidoExcepcion($"El nombre de usuario no puede tener menos de {largoMinNombre} caracteres.");
            }
            if (this.Nombre.Length > largoMaxNombre)
            {
                throw new UsuarioInvalidoExcepcion($"El nombre de usuario no puede tener mas de {largoMaxNombre} caracteres.");
            }
            return true;
        }

        public void LoguearA(Perfil perfilALoguear)
        {
            foreach (Perfil perfil in _perfiles)
            {
                if (perfil == perfilALoguear)
                {
                    perfil.Logged = true;
                }
            }
        }

        public Perfil PerfilLogueado()
        {
            foreach (Perfil perfil in _perfiles)
            {
                if (perfil.Logged)
                {
                    return perfil;
                }
            }
            throw new UsuarioInvalidoExcepcion("No hay ningun perfil logueado");
        }

        public void CerrarSesionPerfiles()
        {
            foreach (Perfil perfil in _perfiles)
            {
                perfil.Logged = false;
            }
        }

        public void EliminarPerfil(Perfil unPerfil)
        {
            this.Perfiles.Remove(unPerfil);
        }
    }
}