using Dominio;
using LogicaNegocio;
using RepositorioEnBDD;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEnBDD
{
    public class RepositorioRepartoBDD : IRepositorioReparto
    {
        public void Agregar(Reparto reparto)
        {
            using (var context = new TLMDBContext())
            {
                context.Repartos.Add(reparto);
                context.SaveChanges();
            }
        }

        public void Eliminar(Reparto reparto)
        {
            Reparto unReparto = ObtenerRepartoPorID(reparto.Id);

            using (var context = new TLMDBContext())
            {
                context.Repartos.Remove(unReparto);
                context.SaveChanges();
            }
        }

        public Reparto ObtenerRepartoPorID(int id)
        {
            using (var context = new TLMDBContext())
            {
                return context.Repartos.Where(c => c.Id == id).Include(c => c.Nombre)
                    .Include(c => c.FechaNacimiento)
                    .Include(c => c.Imagen).FirstOrDefault();
            }
        }

        public List<Actor> ObtenerActores()
        {
            using (var context = new TLMDBContext())
            {
                return context.Actores.Include(c => c.Nombre)
                    .Include(c => c.Imagen)
                    .Include(c => c.FechaNacimiento)
                    .Include(c => c.PeliculasActuadas).ToList();
            }
        }

        public List<Director> ObtenerDirectores()
        {
            using (var context = new TLMDBContext())
            {
                return context.Directores.Include(c => c.Nombre)
                    .Include(c => c.Imagen)
                    .Include(c => c.FechaNacimiento)
                    .Include(c => c.PeliculasDirigidas).ToList();
            }
        }

        public List<Reparto> ObtenerRepartos()
        {
            using (var context = new TLMDBContext())
            {
                return context.Repartos.Include(c => c.Nombre)
                    .Include(c => c.Imagen)
                    .Include(c => c.FechaNacimiento).ToList();
            }
        }
    }
}