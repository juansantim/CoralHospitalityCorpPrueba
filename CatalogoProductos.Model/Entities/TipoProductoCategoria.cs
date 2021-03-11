using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Model.Entities
{
    public class TipoProductoCategoria
    {
        public int Id { get; set; }
        
        public int TipoProductoId { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
