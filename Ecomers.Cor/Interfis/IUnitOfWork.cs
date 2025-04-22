using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Interfis
{
    public interface IUnitOfWork
    {
        public ICategoryRepositrycs categoryRepositrycs { get; }
        public IPhotoRepositry PhotoRepositry { get; }
        public IProductRepositry productRepositry { get; }
    }
}
