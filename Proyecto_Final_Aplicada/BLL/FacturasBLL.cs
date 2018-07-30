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
    public class FacturasBLL
    {
        public static bool Guardar(Facturas facturas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            Clientes clientes = new Clientes();
            try
            {
                if (contexto.factura.Add(facturas) != null)
                {

                    foreach (var item in facturas.Detalle)
                    {
                        contexto.producto.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }

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
                Facturas facturas = contexto.factura.Find(id);


                if (facturas != null)
                {
                    foreach (var item in facturas.Detalle)
                    {
                        contexto.producto.Find(item.ProductoId).Inventario += item.Cantidad;

                    }

                    facturas.Detalle.Count();
                    contexto.factura.Remove(facturas);
                }

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

        public static Facturas Buscar(int id)
        {
            Facturas facturas = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.factura.Find(id);
                if (facturas != null)
                {
                    facturas.Detalle.Count();

                    foreach (var item in facturas.Detalle)
                    {

                        string s = item.Productos.Descripcion;
                    }

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return facturas;
        }

        public static bool Modificar(Facturas facturas)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var factura = BLL.FacturasBLL.Buscar(facturas.FacturaId);


                if (facturas != null)
                {


                    foreach (var item in facturas.Detalle)
                    {

                        contexto.producto.Find(item.ProductoId).Inventario += item.Cantidad;

                        if (!facturas.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {

                            item.Productos = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }

                    }


                    foreach (var item in facturas.Detalle)
                    {
                        contexto.producto.Find(item.ProductoId).Inventario -= item.Cantidad;

                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }

                    Facturas Anterior = BLL.FacturasBLL.Buscar(facturas.FacturaId);

                    decimal diferencia;

                    diferencia = facturas.Total - Anterior.Total;

                    Productos productos = BLL.ProductosBLL.Buscar(facturas.FacturaId);
                    BLL.ProductosBLL.Modificar(productos);

                    contexto.Entry(facturas).State = EntityState.Modified;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturas> facturas = new List<Facturas>();

            try
            {
                facturas = contexto.factura.Where(expression).ToList();

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return facturas;

        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }

        public static decimal CalcularITBIS(decimal subtotal)
        {
            return Convert.ToDecimal(subtotal) * Convert.ToDecimal(0.18);
        }

        public static decimal Total(decimal subtotal, decimal ITBIS)
        {
            return Convert.ToDecimal(subtotal) + Convert.ToDecimal(ITBIS);
        }

    }
}