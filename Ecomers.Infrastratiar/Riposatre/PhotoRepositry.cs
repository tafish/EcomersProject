using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;

//using Ecom.Cor.Interfis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Riposatre
{
    public class PhotoRepositry : GenericRepositry<Photo>, IPhotoRepositry
    {
        public PhotoRepositry(Data.AppDbContext context) : base(context)
        {
        }
    }
}
