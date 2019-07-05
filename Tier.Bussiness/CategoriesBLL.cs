using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tier.Bussiness.Interfaces;
using Tier.Data.Entidades;
using Tier.Entity;

namespace Tier.Bussiness
{
  public  class CategoriesBLL : Icrud<Categories>
    {
        public Categories Buscar(int id) { return new CategoriesDTO().GetDTO(id); }

        public List<Categories> Buscar() { return new CategoriesDTO().GetDTO(); }

        public bool Insertar(Categories p) { return new CategoriesDTO().InsertDTO(p); }

        public bool Actualizar(Categories p) { return new CategoriesDTO().UpdateDTO(p); }

        public bool Eliminar(int id) { return new CategoriesDTO().deleteDTO(id); }

        public List<Categories> ProductsByCategory()
        {
            List<Categories> ListaCategories = new CategoriesDTO().GetDTO();
            foreach (Categories ct in ListaCategories)
                ct._Productos = new ProductsDTO().ProductosPorCategoria(ct.CategoryId);

            return ListaCategories;
        }


        public Categories ProductsByCategory(int id)
        {
            Categories ListaCategories = new CategoriesDTO().GetDTO(id);
            ListaCategories._Productos = new ProductsDTO().ProductosPorCategoria(ListaCategories.CategoryId);

            return ListaCategories;
        }

    }
}
