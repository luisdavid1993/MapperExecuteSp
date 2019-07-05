﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tier.Data.Utiles;
using Tier.Entity;

namespace Tier.Data.Entidades
{
  public  class CategoriesDTO : BaseDTO<Categories>, Ioperaciones<Categories>
    {
        public bool deleteDTO(int id)
        {
            AddParameters("@CategoryId",SqlDbType.Int,id);
            return ExecuteNonQueryBase("Sp_DeleteCategories");
        }

        public List<Categories> GetDTO()
        {
            return ExuecuteProcedure("Sp_BuscarCategories").ToList();
        }

        public Categories GetDTO(int id)
        {
            AddParameters("@CategoryId",SqlDbType.Int,id);
            return ExuecuteProcedure("Sp_BuscarCategories").FirstOrDefault();
        }

        public bool InsertDTO(Categories obj)
        {
            AddParameters("@tipo",SqlDbType.Int,TipoSpInsert.Insert);
            AddParameters("@CategoryId",SqlDbType.Int,obj.CategoryId);
            AddParameters("@CategoryName",SqlDbType.VarChar,obj.CategoryName);
            AddParameters("@Description",SqlDbType.VarChar,obj.Description);
            return ExecuteNonQueryBase("Sp_InsertCategories");
        }

        public bool UpdateDTO(Categories obj)
        {
            AddParameters("@tipo", SqlDbType.Int, TipoSpInsert.Insert);
            AddParameters("@CategoryId", SqlDbType.Int, obj.CategoryId);
            AddParameters("@CategoryName", SqlDbType.VarChar, obj.CategoryName);
            AddParameters("@Description", SqlDbType.VarChar, obj.Description);
            return ExecuteNonQueryBase("Sp_InsertCategories");
        }
    }
}
