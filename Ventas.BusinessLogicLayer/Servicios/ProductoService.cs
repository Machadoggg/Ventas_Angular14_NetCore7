﻿using Microsoft.EntityFrameworkCore;
using Ventas.BusinessLogicLayer.Servicios.Contrato;
using Ventas.DataAccessLayer.Repositorios.Contrato;
using Ventas.Model;

namespace Ventas.BusinessLogicLayer.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productoRepositorio;

        public ProductoService(IGenericRepository<Producto> productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }


        public async Task<List<Producto>> Lista()
        {
            try
            {
                var queryProducto = await _productoRepositorio.Consultar();
                var listaProductos = queryProducto.Include(cat => cat.IdCategoriaNavigation).ToList();

                return listaProductos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto> Crear(Producto modelo)
        {
            try
            {
                var productoCreado = await _productoRepositorio.Crear(modelo);

                if (productoCreado.IdProducto == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return productoCreado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(Producto modelo)
        {
            try
            {
                var productoEncontrado = await _productoRepositorio.Obtener(u => u.IdProducto == modelo.IdProducto);

                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El producto no existe");
                }

                productoEncontrado.Nombre = modelo.Nombre;
                productoEncontrado.IdCategoria = modelo.IdCategoria;
                productoEncontrado.Stock = modelo.Stock;
                productoEncontrado.Precio = modelo.Precio;
                productoEncontrado.EsActivo = modelo.EsActivo;

                bool respuesta = await _productoRepositorio.Editar(productoEncontrado);

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
                var productoEncontrado = await _productoRepositorio.Obtener(p => p.IdProducto == id);

                if (productoEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                bool respuesta = await _productoRepositorio.Eliminar(productoEncontrado);

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