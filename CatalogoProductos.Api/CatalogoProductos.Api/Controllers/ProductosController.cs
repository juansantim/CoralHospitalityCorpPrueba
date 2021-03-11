using CatalogoProductos.Model.DTOs;
using CatalogoProductos.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogoProductos.Api.Controllers
{
    //[Route("api/[controller]")]
    public class ProductosController : ApiController
    {
        private readonly ProdutosService service;

        public ProductosController()
        {
            this.service = new ProdutosService();
        }

        [ActionName("GetAll")]
        public List<ProductoDTO> GetAll()
        {
           return service.GetAll();
        }

        public ProductoDTO Post(ProductoDTO producto)
        {
            return service.GuardarCambios(producto);
        }

        public ProductoDTO Get(int Id)
        {
            return service.GetById(Id);
        }


        public ProductoDTO Delete(int Id)
        {
            return service.Delete(Id);
        }
    }
}
