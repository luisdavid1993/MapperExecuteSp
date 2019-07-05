using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace Tier.Entity
{
    [DataContract]
    public class Product
    {
        [DataMember]
        [Column(Name = "ProductId")]
        public int ProductId { get; set; }

        [DataMember]
        [Column(Name = "ProductName")]
        public string ProductName{ get; set; }

        [DataMember]
        [Column(Name = "SupplierId")]
        public int SupplierId { get; set; }

        [DataMember]
        [Column(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [DataMember]
        [Column(Name = "QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [DataMember]
        [Column(Name = "UnitPrice")]
        public decimal UnitPrice { get; set; }

        [DataMember]
        [Column(Name = "UnitsInStock")]
        public int UnitsInStock { get; set; }

        [DataMember]
        [Column(Name = "UnitsOnOrder")]
        public int UnitsOnOrder { get; set; }

        [DataMember]
        [Column(Name = "ReorderLevel")]
        public int ReorderLevel  { get; set; }

        [DataMember]
        [Column(Name = "Discontinued")]
        public bool Discontinued { get; set; }

        [DataMember]
        public Categories _Categorias  { get; set; }

    }
}
