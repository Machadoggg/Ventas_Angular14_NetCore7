﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ventas.BusinessLogicLayer.Comun;
using Ventas.DataAccessLayer.DBContext;

namespace Ventas.DataAccessLayer.Repositorios.Comun
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly VentasAngular14Context _dbcontext;

        public GenericRepository(VentasAngular14Context dbcontext)
        {
            _dbcontext = dbcontext;
        }



        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo? modelo = await _dbcontext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbcontext.Set<TModelo>().Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbcontext.Set<TModelo>().Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbcontext.Set<TModelo>().Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo;
                if (filtro == null)
                {
                    queryModelo = _dbcontext.Set<TModelo>();
                }
                else
                {
                    queryModelo = _dbcontext.Set<TModelo>().Where(filtro);
                }

                return Task.FromResult(queryModelo);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}