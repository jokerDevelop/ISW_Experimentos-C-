using System;
using System.Web;
using TechTalk.SpecFlow;
using Moq;
using NUnit.Framework;
using BPZ.Business;
using BPZ.Dtos;
using System.Collections.Generic;
using AutoMapper;
using BPZ.Models;


namespace BPZTest
{
    [Binding]
    [SetUpFixture]
    public class ProveedorIntegrationTest
    {
        private ProveedorBusiness proveedorBusiness = new ProveedorBusiness();
        private ProveedorDto proveedorDto;
        private bool esNuevo = false;
        private string mensaje = "";
        private string nombre = "";

        [OneTimeSetUp]
        public void init()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Proveedor, ProveedorDto>();
                config.CreateMap<ProveedorDto, Proveedor>();
                config.CreateMap<FacturaDto, Factura>();
                config.CreateMap<Factura, FacturaDto>();
            });
        }


        [Given(@"luego de iniciar sesion en la aplicacion")]
        public void GivenLuegoDeIniciarSesionEnLaAplicacion()
        {
            Assert.IsTrue(true);
        }
        
        [When(@"hago clic en el enlace de Proveedores")]
        public void WhenHagoClicEnElEnlaceDeProveedores()
        {
            esNuevo = true;
            Assert.IsTrue(true);
        }
        
        [When(@"luego hago click en el boton de Registro")]
        public void WhenLuegoHagoClickEnElBotonDeRegistro()
        {
            esNuevo = true;
            Assert.IsTrue(true);
        }
        
        [When(@"en la nueva pantalla escribo en campo nombre el valor de ""(.*)""")]
        public void WhenEnLaNuevaPantallaEscriboEnCampoNombreElValorDe(string p0)
        {
            nombre = p0;
            Assert.IsTrue(true);
        }
        
        [When(@"hago click en el boton de Guardar")]
        public void WhenHagoClickEnElBotonDeGuardar()
        {
            try
            {
                if (esNuevo)
                {
                    proveedorDto = new ProveedorDto();
                    proveedorDto.nombre = nombre;
                    proveedorDto.estado = "ACT";
                    proveedorBusiness.insertar(proveedorDto);
                    mensaje = "Se registro correctamente el Proveedor";
                }
                else
                {
                    proveedorDto.nombre = nombre;
                    proveedorDto.estado = "ACT";
                    proveedorBusiness.actualizar(proveedorDto);
                    mensaje = "Se actualizo correctamente el Proveedor";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error" + ex.Message;
                Console.WriteLine(mensaje);
                Assert.Fail();
            }
        }
        
        [Then(@"el sistema muestra un mensaje de ""(.*)""")]
        public void ThenElSistemaMuestraUnMensajeDe(string p0)
        {
            Assert.AreEqual(p0, mensaje);
        }

        [When(@"busco el Proveedor de id ""(.*)"" para seleccionarlo")]
        public void WhenBuscoElProveedorDeIdParaSeleccionarlo(int p0)
        {
            proveedorDto = proveedorBusiness.obtener(p0);
            
        }

        [When(@"luego hago click en el boton de Editar")]
        public void WhenLuegoHagoClickEnElBotonDeEditar()
        {
            esNuevo = false;
            Assert.IsTrue(true);
        }

        [Then(@"la nueva pantalla muestra la lista de Proveedores")]
        public void ThenLaNuevaPantallaMuestraLaListaDeProveedores()
        {
            List<ProveedorDto> proveedores = new List<ProveedorDto>();
            proveedores = proveedorBusiness.listar();
            Assert.IsTrue(proveedores.Count > 0);
            Assert.IsTrue(true);
        }

        [When(@"hago clic en el boton de Eliminar el Proveedor con el id ""(.*)""")]
        public void WhenHagoClicEnElBotonDeEliminarElProveedorConElId(int p0)
        {
            bool flag = false;
            flag = proveedorBusiness.eliminar(p0);
            Assert.IsTrue(flag);
            mensaje = "Se elimino el Proveedor";
        }


    }
}
