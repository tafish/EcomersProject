using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Entites.Product
{
    public class Product :BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public virtual List<Photo> Photos { get; init; }
        public int CatagoryId { get; set; }

        [ForeignKey(nameof(CatagoryId))]
        public virtual Catagory Catagory { get; set; }
    }
}
