using CatalogoProductos.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Model.Services
{
    public class TiposProductosService
    {
        ProductosContext db;
        public TiposProductosService()
        {
            this.db = new ProductosContext();
        }

        public  List<TipoProductoDTO> GetTiposProductosForProducto()
        {
            return db.TiposProductos.Select(tp => new TipoProductoDTO 
            {
                Id = tp.Id,
                Nombre = tp.Nombre,
                Categorias = tp.TipoProductoCategoria.Select(tpc => tpc.Categoria.Nombre).ToList()
            }).ToList();
        }
    }
}
