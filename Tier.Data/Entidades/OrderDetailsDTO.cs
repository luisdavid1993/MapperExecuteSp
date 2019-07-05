using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tier.Data.Utiles;
using Tier.Entity;

namespace Tier.Data.Entidades
{
 public   class OrderDetailsDTO:BaseDTO<OrderDetails>, Ioperaciones<OrderDetails>
    {
       public bool InsertDTO(OrderDetails obj)
        {

            AddParameters("@tipo",SqlDbType.Int,TipoSpInsert.Insert);
            AddParameters("@OrderId",SqlDbType.Int,obj.OrderId);
            AddParameters("@ProductId",SqlDbType.Int,obj.ProductId);
            AddParameters("@UnitPrice",SqlDbType.Decimal,obj.UnitPrice);
            AddParameters("@Quantity",SqlDbType.Int,obj.Quantity);
            AddParameters("@Discount",SqlDbType.Real,obj.Discount);

            return ExecuteNonQueryBase("Sp_InsertOrderDetail");
        }

        public bool UpdateDTO(OrderDetails obj)
        {
            AddParameters("@tipo", SqlDbType.Int, TipoSpInsert.Insert);
            AddParameters("@OrderId", SqlDbType.Int, obj.OrderId);
            AddParameters("@ProductId", SqlDbType.Int, obj.ProductId);
            AddParameters("@UnitPrice", SqlDbType.Decimal, obj.UnitPrice);
            AddParameters("@Quantity", SqlDbType.Int, obj.Quantity);
            AddParameters("@Discount", SqlDbType.Real, obj.Discount);
            return ExecuteNonQueryBase("Sp_InsertOrderDetail");
        }

        public OrderDetails GetDTO(int id)
        {
            AddParameters("@OrderId",SqlDbType.Int,id);
            return ExuecuteProcedure("Sp_BuscarOrderDetail").FirstOrDefault();
        }

        public List<OrderDetails> GetDTO()
        {
            return ExuecuteProcedure("Sp_BuscarOrderDetail").ToList(); ;
        }

        public bool deleteDTO(int id)
        {
            AddParameters("@OrderId",SqlDbType.Int,id);
            return ExecuteNonQueryBase("Sp_DeleteOrderDetail");
        }
    }
}
