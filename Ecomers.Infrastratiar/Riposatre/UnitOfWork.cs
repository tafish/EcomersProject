//using Ecom.Cor.Interfis;
using AutoMapper;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using Ecomers.Cor.Service;
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
        private readonly IMapper _mapper;
        private readonly IImagemanagenentService _imagemanagenentService;

        public ICategoryRepositrycs categoryRepositrycs { get; }

        public IPhotoRepositry PhotoRepositry { get; }

        public IProductRepositry productRepositry { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImagemanagenentService imagemanagenentService)
        {
            _context = context;
            _mapper = mapper;
            _imagemanagenentService = imagemanagenentService;
            categoryRepositrycs = new CategoryRepositrycs(_context);
            PhotoRepositry = new PhotoRepositry(_context);
            productRepositry = new ProductRepositry(_context, mapper, imagemanagenentService);

        }
    }
}
