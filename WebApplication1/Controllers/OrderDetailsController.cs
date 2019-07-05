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
    public class OrderDetailsController : ApiController
    {
        /// <summary>
        ///  Post Order detail
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(OrderDetails p)
        {
            try
            {
                new OrderDetailBLL().Insertar(p);
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
        ///  get OrderDetails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDetails> get()
        {
            try
            {
                return new OrderDetailBLL().Buscar();
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
        /// get OrderDetails by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderDetails get(int id)
        {
            try
            {
                return new OrderDetailBLL().Buscar(id);
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
        ///  Update OrderDetails
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public HttpResponseMessage Put(OrderDetails p)
        {
            try
            {
                new OrderDetailBLL().Actualizar(p);
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
        ///  Delete OrderDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        // DELETE: api/test/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new OrderDetailBLL().Eliminar(id);
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
