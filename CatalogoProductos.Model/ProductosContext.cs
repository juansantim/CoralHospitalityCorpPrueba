using CatalogoProductos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CatalogoProductos.Model
{
    public class ProductosContext : DbContext
    {
        public ProductosContext():base("InventarioProductos")
        {
            Database.SetInitializer(new ProductContextInitializer());
        }    
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoProducto> TiposProductos { get; set; }

        public DbSet<TipoProductoCategoria> TiposProductosCategorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                  .HasRequired(p => p.TipoProducto)
                  .WithMany(tp => tp.Productos)
                  .HasForeignKey(p => p.TipoProductoId);

            modelBuilder.Entity<TipoProducto>()
                 .HasMany(p => p.TipoProductoCategoria)
                 .WithRequired(tpc => tpc.TipoProducto)
                 .HasForeignKey(tpc => tpc.TipoProductoId);

            modelBuilder.Entity<TipoProducto>()
                .HasMany(tp => tp.Productos)
                .WithRequired(p => p.TipoProducto)
                .HasForeignKey(p => p.TipoProductoId);

            modelBuilder.Entity<Categoria>()
                 .HasMany(p => p.TipoProductoCategoria)
                 .WithRequired(tpc => tpc.Categoria)
                 .HasForeignKey(tpc => tpc.CategoriaId);

            modelBuilder.Entity<Categoria>()
                .HasOptional(c => c.CategoriaPadre)
                .WithMany(cp => cp.CategoriasHijas)
                .HasForeignKey(c => c.CategoriaPadreId);
        }

      
    }

    public class ProductContextInitializer : DropCreateDatabaseIfModelChanges<ProductosContext>
    {
        protected override void Seed(ProductosContext context)
        {
            IList<Categoria> categorias = new List<Categoria>();

            var papeleria = new Categoria() { Nombre = "Papeleria" };
            var escolares = new Categoria() { Nombre = "Escolares" };

            papeleria.CategoriasHijas.Add(escolares);
            
            categorias.Add(papeleria);

            var tipoLapicero = new TipoProducto 
            {
                EsFragil = true,
                Nombre = "Lapiceros",
            };

            var tipoProductoCategoria = new TipoProductoCategoria 
            {
                Categoria = papeleria,
                TipoProducto = tipoLapicero
            };

            context.Categorias.AddRange(categorias);
            context.Categorias.AddRange(categorias);
            context.TiposProductos.Add(tipoLapicero);
            context.TiposProductosCategorias.Add(tipoProductoCategoria);


            base.Seed(context);
        }
    }
}
