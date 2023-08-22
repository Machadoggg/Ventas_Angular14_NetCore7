using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Angular14_NetCore7.Model;
using Ventas_Angular14_NetCore7.DTO;

namespace Ventas_Angular14_NetCore7.BLL.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<List<Producto>> Lista();
        Task<Producto> Crear(Producto modelo);
        Task<bool> Editar(Producto modelo);
        Task<bool> Eliminar(int id);
    }
}
