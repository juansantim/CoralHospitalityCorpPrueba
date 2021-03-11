using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProductos.Model.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public int? CategoriaPadreId { get; set; }
        public string Nombre { get; set; }
        public Categoria CategoriaPadre { get; set; }

        public List<Categoria> CategoriasHijas { get; set; }
        public List<TipoProductoCategoria> TipoProductoCategoria { get; set; }

        public Categoria()
        {
            CategoriasHijas = new List<Categoria>();
            TipoProductoCategoria = new List<TipoProductoCategoria>();
        }    
    }
}
