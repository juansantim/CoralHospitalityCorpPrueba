using CatalogoProductos.Model.DTOs;
using CatalogoProductos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Model.Services
{
    public class ProdutosService
    {
        private readonly ProductosContext db;

        public ProdutosService(ProductosContext db)
        {
            this.db = db;
        }

        public ProdutosService()
        {
            this.db = new ProductosContext();
        }

        public List<ProductoDTO> GetAll()
        {
            return db.Productos.ToList().Select(prod => GetProductoDTO(prod)).ToList();
        }

        public ProductoDTO GetById(int Id) {

            return db.Productos.Where(p => p.Id == Id).ToList().Select(prod => GetProductoDTO(prod)).FirstOrDefault();
        }

        private ProductoDTO GetProductoDTO(Producto prod)
        {
            return new ProductoDTO
            {
                Id = prod.Id,
                Nombre = prod.Nombre,
                Codigo = prod.Codigo,
                TipoProductoId = prod.TipoProductoId,
                TipoProducto = prod.TipoProducto.Nombre,
                Descripcion = prod.Descripcion
            };
        }

        public ProductoDTO Delete(int id)
        {
            var producto = db.Productos.Single(p => p.Id == id);

            var dto = GetProductoDTO(producto);

            db.Productos.Remove(producto);
            db.SaveChanges();

            return dto;
        }

        public ProductoDTO GuardarCambios(ProductoDTO producto)
        {
            Producto product = null;

            if (producto.Id > 0)
            {
                product = db.Productos.Single(p => p.Id == producto.Id);

                product.Nombre = producto.Nombre;
                product.Codigo = producto.Codigo;
                product.Descripcion = producto.Descripcion;
                product.TipoProductoId = producto.TipoProductoId;
            }
            else 
            {
                product = new Producto
                {
                    Codigo = producto.Codigo,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    TipoProductoId = producto.TipoProductoId
                };

                db.Productos.Add(product);
            }

            db.SaveChanges();
            product.Id = product.Id;

            return producto;
        }
    }
}
