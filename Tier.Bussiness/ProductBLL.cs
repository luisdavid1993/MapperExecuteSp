using System.Collections.Generic;
using Tier.Bussiness.Interfaces;
using Tier.Data.Entidades;
using Tier.Entity;

namespace Tier.Bussiness
{
    public class ProductBLL : Icrud<Product>
    {
        public Product Buscar(int id){
            Product ProductObj =  new ProductsDTO().GetDTO(id);
            ProductObj._Categorias = (Categories)new  CategoriesDTO().GetDTO(ProductObj.CategoryId);
            return ProductObj;
        }

        public List<Product> Buscar() {
            List<Product> listaP= new ProductsDTO().GetDTO();
            foreach (Product p in listaP)
                p._Categorias = (Categories)new CategoriesDTO().GetDTO(p.CategoryId);
            return listaP;
        }

        public bool Insertar(Product p){  return new ProductsDTO().InsertDTO(p); }

        public bool Actualizar(Product p) {return new ProductsDTO().UpdateDTO(p); }

        public bool Eliminar(int id) { return new ProductsDTO().deleteDTO(id); }
    }
}
