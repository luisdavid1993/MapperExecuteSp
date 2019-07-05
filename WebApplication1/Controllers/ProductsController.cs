using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tier.Bussiness;
using Tier.Entity;

namespace WebApplication1.Controllers
{
    public class ProductsController : ApiController
    {

        /// <summary>
        /// Post Productos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(Product p)
        {
            try
            {
                new ProductBLL().Insertar(p);
                return this.Request.CreateResponse(HttpStatusCode.OK, p);
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }
        }


        /// <summary>
        ///  get Productos
        /// </summary>
        /// <returns></returns>
        public List<Product> get()
        {
            try
            {
                List<Product> retorno = new ProductBLL().Buscar();
                return retorno;
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }

        }

        /// <summary>
        /// get products by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product get(int id)
        {
            try
            {
                return new ProductBLL().Buscar(id);
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }

        }

        /// <summary>
        ///  Update produtcs
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public HttpResponseMessage Put(Product p)
        {
            try
            {
                new ProductBLL().Actualizar(p);
                return this.Request.CreateResponse(HttpStatusCode.OK, p);
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }
        }

        /// <summary>
        ///  Delete Products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        // DELETE: api/test/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new ProductBLL().Eliminar(id);
                return this.Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception eException)
            {
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(eException.Message)
                });
            }
        }


    }
}
