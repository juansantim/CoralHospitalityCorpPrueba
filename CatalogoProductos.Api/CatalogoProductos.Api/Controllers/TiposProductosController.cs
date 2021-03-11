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
    public class TiposProductosController : ApiController
    {
        TiposProductosService service;

        public TiposProductosController()
        {
            service = new TiposProductosService();

        }    

        public List<TipoProductoDTO> GetTiposProductosForAll() 
        {
            return service.GetTiposProductosForProducto();
        }
    }
}
