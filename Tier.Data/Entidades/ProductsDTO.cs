using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tier.Data.Utiles;
using Tier.Entity;

namespace Tier.Data.Entidades
{
   public class ProductsDTO : BaseDTO<Product>, Ioperaciones<Product>
    {

        #region Crud Product
        public bool InsertDTO(Product obj)
        {
            AddParameters("@tipo",SqlDbType.Int, TipoSpInsert.Insert);
            AddParameters("@ProductId",SqlDbType.Int, obj.ProductId);
            AddParameters("@ProductName",SqlDbType.VarChar, obj.ProductName);
            AddParameters("@SupplierId",SqlDbType.Int, obj.SupplierId);
            AddParameters("@CategoryId",SqlDbType.Int, obj.CategoryId);
            AddParameters("@QuantityPerUnit",SqlDbType.VarChar, obj.QuantityPerUnit);
            AddParameters("@UnitPrice",SqlDbType.Decimal, obj.UnitPrice);
            AddParameters("@UnitsInStock",SqlDbType.Int,obj.UnitsInStock);
            AddParameters("@UnitsOnOrder",SqlDbType.Int, obj.UnitsOnOrder);
            AddParameters("@ReorderLevel",SqlDbType.Int, obj.ReorderLevel);
            AddParameters("@Discontinued",SqlDbType.Bit, obj.Discontinued);
            return ExecuteNonQueryBase("Sp_InsertProduct");
        }

   

        public bool UpdateDTO(Product obj)
        {

            AddParameters("@tipo", SqlDbType.Int, TipoSpInsert.Insert);
            AddParameters("@ProductId", SqlDbType.Int, obj.ProductId);
            AddParameters("@ProductName", SqlDbType.VarChar, obj.ProductName);
            AddParameters("@SupplierId", SqlDbType.Int, obj.SupplierId);
            AddParameters("@CategoryId", SqlDbType.Int, obj.CategoryId);
            AddParameters("@QuantityPerUnit", SqlDbType.VarChar, obj.QuantityPerUnit);
            AddParameters("@UnitPrice", SqlDbType.Decimal, obj.UnitPrice);
            AddParameters("@UnitsInStock", SqlDbType.Int, obj.UnitsInStock);
            AddParameters("@UnitsOnOrder", SqlDbType.Int, obj.UnitsOnOrder);
            AddParameters("@ReorderLevel", SqlDbType.Int, obj.ReorderLevel);
            AddParameters("@Discontinued", SqlDbType.Bit, obj.Discontinued);
            return ExecuteNonQueryBase("Sp_InsertProduct");
        }

        public Product GetDTO(int id)
        {
            AddParameters("@ProductId",SqlDbType.Int, id);
            return ExuecuteProcedure("Sp_BuscarProduct").FirstOrDefault();
        }

        public List<Product> GetDTO()
        {
            List<Product> retorno = ExuecuteProcedure("Sp_BuscarProduct").ToList();
            return retorno;
        }

        public bool deleteDTO(int id)
        {
            AddParameters("@ProductId",SqlDbType.Int, id);
            return ExecuteNonQueryBase("Sp_DeleteProduct");
        }
        #endregion Crud Product

        public List<Product> ProductosPorCategoria(int id) {
            AddParameters("@CategoryId",SqlDbType.Int, id);
            return ExuecuteProcedure("Sp_BuscarProductByCategory").ToList();
        }
    }
}
