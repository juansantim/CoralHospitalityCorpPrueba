using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Model.DTOs
{
    public class TipoProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<string> Categorias { get; set; }
    }
}
