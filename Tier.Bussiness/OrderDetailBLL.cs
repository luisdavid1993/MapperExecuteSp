using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tier.Bussiness.Interfaces;
using Tier.Data.Entidades;
using Tier.Entity;

namespace Tier.Bussiness
{
  public  class OrderDetailBLL: Icrud<OrderDetails>
    {
        public OrderDetails Buscar(int id) {

            OrderDetails Order = new OrderDetailsDTO().GetDTO(id);
            Order._Product = new ProductsDTO().GetDTO(Order.ProductId);
            return Order;
        }

        public List<OrderDetails> Buscar() {

            List<OrderDetails> ListaDetail = new OrderDetailsDTO().GetDTO();
            foreach(OrderDetails ord in ListaDetail)
                ord._Product = new ProductsDTO().GetDTO(ord.ProductId);

            return ListaDetail;
        }

        public bool Insertar(OrderDetails p) { return new OrderDetailsDTO().InsertDTO(p); }

        public bool Actualizar(OrderDetails p) { return new OrderDetailsDTO().UpdateDTO(p); }

        public bool Eliminar(int id) { return new OrderDetailsDTO().deleteDTO(id); }

    }
}
