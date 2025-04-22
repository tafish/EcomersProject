//using Ecom.Cor.Interfis;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Riposatre
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoryRepositrycs categoryRepositrycs { get; }

        public IPhotoRepositry PhotoRepositry { get; }

        public IProductRepositry productRepositry { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categoryRepositrycs = new CategoryRepositrycs(_context);
            PhotoRepositry = new PhotoRepositry(_context);
            productRepositry = new ProductRepositry(_context);
        }
    }
}
