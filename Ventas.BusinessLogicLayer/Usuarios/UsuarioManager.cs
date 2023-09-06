﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Domain.Usuarios;

namespace Ventas.BusinessLogicLayer.Usuarios
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioManager(IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }


        public async Task<List<Usuario>> Lista()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(rol => rol.IdRolNavigation).ToList();

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string clave)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u =>
                    u.Correo == correo &&
                    u.Clave == clave
                );
                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario no existe");

                Usuario devolverUsuario = queryUsuario.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<SesionDTO>(devolverUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> Crear(Usuario modelo)
        {
            try
            {
                var usuarioCreado = await _usuarioRepositorio.Crear(_mapper.Map<Usuario>(modelo));

                if (usuarioCreado.Id == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _usuarioRepositorio.Consultar(u => u.Id == usuarioCreado.Id);
                usuarioCreado = query.Include(rol => rol.IdRolNavigation).First();
                return usuarioCreado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario modelo)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Id == modelo.Id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.NombreCompleto = modelo.NombreCompleto;
                usuarioEncontrado.Correo = modelo.Correo;
                usuarioEncontrado.IdRol = modelo.IdRol;
                usuarioEncontrado.Clave = modelo.Clave;
                usuarioEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.Id == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
