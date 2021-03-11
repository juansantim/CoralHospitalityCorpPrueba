using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatalogoProductos.Model.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Codigo { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public int TipoProductoId { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
    }
}
