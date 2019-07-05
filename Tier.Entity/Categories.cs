using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Entity
{
    [DataContract]
    public  class Categories
    {
        [DataMember]
        [Column(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [DataMember]
        [Column(Name = "CategoryName")]
        public string CategoryName { get; set; }

        [DataMember]
        [Column(Name = "Description")]
        public string Description { get; set; }

        [DataMember]
        public List<Product> _Productos { get; set; }
    }
}
