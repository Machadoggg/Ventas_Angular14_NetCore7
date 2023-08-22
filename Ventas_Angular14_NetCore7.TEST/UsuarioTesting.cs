using Ventas_Angular14_NetCore7.API.Controllers;
using Ventas_Angular14_NetCore7.BLL.Servicios;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ventas_Angular14_NetCore7.Model;
using Xunit;
using Ventas_Angular14_NetCore7.DTO;
using Ventas_Angular14_NetCore7.API.Utilidad;

namespace Ventas_Angular14_NetCore7.TEST
{
    public class UsuarioTesting
    {


        [Fact]
        public async Task ListaUsuariosTesting()
        {
            // Arrange
            var mockUsuarioServicio = new Mock<IUsuarioService>();
            var usuarios = new List<UsuarioDTO>
            {
            };
            mockUsuarioServicio.Setup(servicio => servicio.Lista()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(mockUsuarioServicio.Object);

            // Act
            var result = await controller.Lista();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var respuesta = Assert.IsType<Response<List<UsuarioDTO>>>(okResult.Value);

            Assert.True(respuesta.Ok);
            Assert.Equal(usuarios, respuesta.Value);
        }



        [Fact]
        public async Task IniciarSesion_ReturnsOkResponseWithSesion()
        {
            // Arrange
            var mockUsuarioServicio = new Mock<IUsuarioService>();
            var sesion = new SesionDTO { IdUsuario = 1 };
            mockUsuarioServicio.Setup(servicio => servicio.ValidarCredenciales(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(sesion);

            var controller = new UsuarioController(mockUsuarioServicio.Object);

            var loginDTO = new LoginDTO { Correo = "m@gmail.com", Clave = "123" };

            // Act
            var result = await controller.IniciarSesion(loginDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var respuesta = Assert.IsType<Response<SesionDTO>>(okResult.Value);

            Assert.True(respuesta.Ok);
            Assert.Equal(sesion, respuesta.Value);
        }


        }
}