using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Model.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoProductoId { get; set; }
        public string TipoProducto { get; set; }
    }
}
