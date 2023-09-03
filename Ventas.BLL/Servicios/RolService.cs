﻿using Ventas.BLL.Servicios.Contrato;
using Ventas.DAL.Repositorios.Contrato;
using Ventas.Model;


namespace Ventas.BLL.Servicios
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;

        public RolService(IGenericRepository<Rol> rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        public async Task<List<Rol>> Lista()
        {
            try
            {
                //Convertir (Rol) a (RolDTO) en forma de lista
                var listaRoles = await _rolRepositorio.Consultar();
                return listaRoles.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
