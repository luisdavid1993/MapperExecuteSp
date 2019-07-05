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
    public class CategoriesController : ApiController
    {
        /// <summary>
        /// Post Productos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(Categories p)
        {
            try
            {
                new CategoriesBLL().Insertar(p);
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
        public IEnumerable<Categories> get()
        {
            try
            {
                return new CategoriesBLL().Buscar();
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
        public Categories get(int id)
        {
            try
            {
                return new CategoriesBLL().Buscar(id);
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

        public HttpResponseMessage Put(Categories p)
        {
            try
            {
                new CategoriesBLL().Actualizar(p);
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
                new CategoriesBLL().Eliminar(id);
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
