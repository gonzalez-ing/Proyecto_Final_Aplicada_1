using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Aplicada.Entidades
{
    public class FacturasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Productos { get; set; }

        public FacturasDetalle()
        {
            Id = 0;
            FacturaId = 0;
        }

        public FacturasDetalle(int id, int facturaId, int clienteId, int productoId, string producto, int cantidad, decimal precio, decimal importe)
        {
            this.Id = id;
            this.FacturaId = facturaId;
            this.ClienteId = ClienteId;
            this.ProductoId = productoId;
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;
            
        }

        public FacturasDetalle(int id, int usuarioId, int clienteId, int facturaId, int productoId, string producto, int cantidad, decimal precio, decimal importe)
        {

            this.Id = 0;
            this.FacturaId = 0;
            this.ProductoId = 0;
            this.Cantidad = 0;
            this.Precio = 0;
            this.Importe = 0;
        }
    }
}
