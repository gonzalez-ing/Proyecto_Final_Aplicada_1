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
    public class EntradaProductosBLL
    {
        public static bool Guardar(EntradaProductos entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.entrada.Add(entrada) != null)
                {
                    Productos productos = BLL.ProductosBLL.Buscar(entrada.ProductoId);
                    productos.Inventario += entrada.Cantidad;
                    BLL.ProductosBLL.Modificar(productos);

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
                EntradaProductos entrada = contexto.entrada.Find(id);

                if (entrada != null)
                {
                    Productos productos = BLL.ProductosBLL.Buscar(entrada.ProductoId);
                    productos.Inventario -= entrada.Cantidad;
                    BLL.ProductosBLL.Modificar(productos);

                    contexto.Entry(entrada).State = EntityState.Deleted;
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



        public static bool Modificar(EntradaProductos entrada)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                EntradaProductos ant = BLL.EntradaProductosBLL.Buscar(entrada.EntradaId);
                int resta;
                resta = entrada.Cantidad - ant.Cantidad;

                Productos productos = BLL.ProductosBLL.Buscar(entrada.ProductoId);
                productos.Inventario += resta;
                BLL.ProductosBLL.Modificar(productos);

                contexto.Entry(entrada).State = EntityState.Modified;

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


        public static EntradaProductos Buscar(int id)
        {

            EntradaProductos entrada = new EntradaProductos();
            Contexto contexto = new Contexto();

            try
            {
                entrada= contexto.entrada.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;

        }


        public static List<EntradaProductos> GetList(Expression<Func<EntradaProductos, bool>> expression)
        {
            List<EntradaProductos> entrada = new List<EntradaProductos>();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.entrada.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }
    }
}
