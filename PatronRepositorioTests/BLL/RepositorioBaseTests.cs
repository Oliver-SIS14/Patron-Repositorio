using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado empleado = new Empleado();

            empleado.Nombres = "Pedro Manuel";
            empleado.Cedula = "4039034";
            empleado.Direccion = "Nagua";
            empleado.Telefono = "809839234";
            empleado.Sueldo = 40000;
            empleado.Fecha = DateTime.Now;
            empleado.Incentivo = 500;
            empleado.Celular = "4029032834";

            Assert.IsTrue(repositorio.Guardar(empleado));

        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado empleado = new Empleado();

            empleado.Nombres = "Oliver Jose";
            empleado.Cedula = "403904";
            empleado.Direccion = "Castillo";
            empleado.Telefono = "809839234";
            empleado.Sueldo = 40000;
            empleado.Fecha = DateTime.Now;
            empleado.Incentivo = 500;
            empleado.Celular = "4029032834";
            empleado.Empleadoid = 1;

            Assert.IsTrue(repositorio.Modificar(empleado));
           
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            Assert.IsTrue(repositorio.Eliminar(2));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            Assert.IsTrue(repositorio.Buscar(1)!=null);
            
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            Assert.IsTrue(repositorio.GetList(p => true) != null);
        }
    }
}