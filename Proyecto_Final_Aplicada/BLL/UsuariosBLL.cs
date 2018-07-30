using Proyecto_Final_Aplicada.DAL;
using Proyecto_Final_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Aplicada.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.usuario.Add(usuario) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.usuario.Find(Id);
                if (eliminar != null)
                {
                    db.Entry(eliminar).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto db = new Contexto();
            try
            {
                usuario = db.usuario.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuarios)
        {
            List<Usuarios> usuario = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                usuario = db.usuario.Where(usuarios).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public static List<Usuarios> GetList()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();
            lista = db.usuario.ToList();
            return lista;
        }

        public static List<Usuarios> GetListId(int usuarioId)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();
            lista = db.usuario.Where(p => p.UsuarioId == usuarioId).ToList();
            return lista;
        }

        public static List<Usuarios> GetListUsuario(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();
            lista = db.usuario.Where(p => p.Usuario == aux).ToList();
            return lista;
        }

        public static List<Usuarios> GetContrasena(string aux)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();
            lista = db.usuario.Where(p => p.Clave == aux).ToList();
            return lista;
        }

    }
}
