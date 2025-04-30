using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomers.Cor.Sharing
{
    public class ProductParams
    {   
        public string? sor { get; set; }
        public int? CatagoryId { get; set; }
        public int pageNumber { get; set; }
        public string? Search { get; set; }
        public int MaxpageSize { get; set; } = 6;

        private int _pageSize = 3;

        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value>MaxpageSize?MaxpageSize:value; }
        }

    }
}
