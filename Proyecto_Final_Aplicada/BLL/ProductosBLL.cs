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
    public class ProductosBLL
    {

        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.producto.Add(productos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }



        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Productos productos = contexto.producto.Find(id);

                if (productos != null)
                {
                    contexto.Entry(productos).State = EntityState.Deleted;
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }



        public static bool Modificar(Productos productos)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(productos).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }



        public static Productos Buscar(int id)
        {

            Productos productos = new Productos();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.producto.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return productos;

        }



        public static List<Productos> GetList(Expression<Func<Productos, bool>> expression)
        {
            List<Productos> productos = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.producto.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return productos;
        }

        public static decimal CalcularCosto(decimal Ganancia, decimal precio)
        {

            Ganancia /= 100;

            return Convert.ToDecimal(precio) * Convert.ToDecimal(Ganancia);

        }

        public static decimal CalcularGanancia(decimal Costo, decimal Precio)
        {
            decimal p = Precio - Costo;

            return (Convert.ToDecimal(p) / Convert.ToDecimal(Costo)) * 100;

        }

        public static decimal CalcularPrecio(decimal Costo, decimal Ganancia)
        {

            Ganancia /= 100;
            Ganancia *= Costo;
            return Convert.ToDecimal(Costo) + Convert.ToDecimal(Ganancia);
        }

        public static string RetornarDescripcion(string nombre)
        {
            string descripcion = string.Empty;
            var lista = GetList(x => x.Descripcion.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Descripcion;
            }

            return descripcion;
        }
    }
}