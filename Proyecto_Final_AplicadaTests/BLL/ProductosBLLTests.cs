using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final_Aplicada.BLL;
using Proyecto_Final_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AplicadaTests.BLL
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Productos productos = new Productos();
            productos.ProductoId = 1;
            productos.Descripcion = "Lava Plato";
            productos.Nombre = "Lava Plato";
            productos.Precio = 20;
            productos.Ganancia = 50;
            productos.Inventario = 5;

            paso = ProductosBLL.Guardar(productos);
            Assert.AreEqual(paso, true);
        }



        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Productos productos = new Productos();
            productos.ProductoId = 1;
            productos.Descripcion = "Lava Plato";
            productos.Nombre = "Lava";
            productos.Precio = 25;
            productos.Ganancia = 50;
            productos.Inventario = 10;

            paso = ProductosBLL.Modificar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Productos productos = new Productos();
            productos = ProductosBLL.Buscar(id);
            Assert.IsNotNull(productos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = ProductosBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            paso = ProductosBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }
    }
}
