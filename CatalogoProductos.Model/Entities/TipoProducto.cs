using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatalogoProductos.Model.Entities
{
    public class TipoProducto
    {
        public int Id { get; set; }
        
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Nombre { get; set; }
        public bool EsFragil { get; set; }

        public List<Producto> Productos { get; set; }
        public List<TipoProductoCategoria> TipoProductoCategoria { get; set; }

        public TipoProducto()
        {
            Productos = new List<Producto>();
            TipoProductoCategoria = new List<TipoProductoCategoria>();
        }
    }
}
