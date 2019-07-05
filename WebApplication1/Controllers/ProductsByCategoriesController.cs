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
    public class ProductsByCategoriesController : ApiController
    {
        public List<Categories> get()
        {
            try
            {
                return new CategoriesBLL().ProductsByCategory();
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

        public Categories get(int id)
        {
            try
            {
                return new CategoriesBLL().ProductsByCategory(id);
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
