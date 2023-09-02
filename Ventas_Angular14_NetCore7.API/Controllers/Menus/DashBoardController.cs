﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ventas_Angular14_NetCore7.API.Utilidad;
using Ventas_Angular14_NetCore7.BLL;
using Ventas_Angular14_NetCore7.BLL.Servicios.Contrato;

namespace Ventas_Angular14_NetCore7.API.Controllers.Menus
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashBoardServicio;
        private readonly IMapper _mapper;

        public DashBoardController(IDashBoardService dashBoardServicio, IMapper mapper)
        {
            _dashBoardServicio = dashBoardServicio;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var respuesta = new Response<DashBoardDTO>();

            try
            {
                var resultado = await _dashBoardServicio.Resumen().ConfigureAwait(false);
                respuesta.Value = _mapper.Map<DashBoardDTO>(resultado);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Ok = false;
                respuesta.MensajeError = ex.Message;
                return StatusCode(400, respuesta);
            }
        }
    }
}
