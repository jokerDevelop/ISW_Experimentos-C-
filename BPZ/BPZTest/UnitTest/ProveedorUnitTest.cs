using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using BPZ.Models;
using BPZ.Dtos;
using BPZ.Dao;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BPZ.Test.UnitTest
{
    [TestClass]
    public class ProveedorUnitTest
    {    
        private  Mock<ProveedorDao> proveedorDao = new Mock<ProveedorDao>();
        private static List<ProveedorDto> lista;
        private static Mock<ProveedorDto> proveedorDto = new Mock<ProveedorDto>();

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            //Initialize proveedorDto
            proveedorDto.Object.id = 1;
            proveedorDto.Object.nombre = "proveedor 1";
            proveedorDto.Object.estado = "ACT";

            //Initialize List<ProveedorDto>
            lista = new List<ProveedorDto>()
             {
                 new ProveedorDto
                 {
                     id = 1,
                     nombre = "proveedor 1"
                 },
                 new ProveedorDto
                 {
                     id = 2,
                     nombre = "proveedor 2"
                 }
             };
        }

        [TestMethod]
        public void Insertar_Proveedor_UnitTest()
        {
            proveedorDao.Setup(x => x.insertar(It.IsAny<ProveedorDto>())).Returns(true);
            bool flag = proveedorDao.Object.insertar(proveedorDto.Object);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Actualizar_Proveedor_UnitTest()
        {
            proveedorDto.Object.nombre = "Alonso";
            proveedorDto.Object.estado = "INA";
            proveedorDao.Setup(x => x.actualizar(It.IsAny<ProveedorDto>())).Returns(true);
            bool flag = proveedorDao.Object.actualizar(proveedorDto.Object);
            Assert.IsTrue(flag);
        }


        [TestMethod]
        public void Eliminar_Proveedor_UnitTest()
        {
            int proveedorEliminadoId = 4;
            proveedorDao.Setup(x => x.eliminar(It.IsAny<int>())).Returns(true);
            bool flag = proveedorDao.Object.eliminar(proveedorEliminadoId);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void Listar_Proveedor_UnitTest()
        {
            List<ProveedorDto> listaEsperada = new List<ProveedorDto>();
            proveedorDao.Setup(x => x.listar()).Returns(lista);
            listaEsperada = proveedorDao.Object.listar();
            Assert.IsTrue(listaEsperada.Count > 0);
            Assert.IsNotNull(listaEsperada);
            Assert.AreEqual(listaEsperada.ElementAt(0).id, 1);
            Assert.AreEqual(listaEsperada.ElementAt(0).nombre, "proveedor 1");
        }

        [TestMethod]
        public void Obtener_Proveedor_UnitTest()
        {
            ProveedorDto proveedorEsperado = new ProveedorDto();
            proveedorDao.Setup(x => x.obtener(It.IsAny<int>())).Returns(proveedorDto.Object);
            proveedorEsperado = proveedorDao.Object.obtener(proveedorDto.Object.id);
            Assert.AreEqual(proveedorEsperado.id, proveedorDto.Object.id);
            Assert.AreEqual(proveedorEsperado.nombre, proveedorDto.Object.nombre);
            Assert.AreEqual(proveedorEsperado.estado, proveedorDto.Object.estado);
        }


    }   
}