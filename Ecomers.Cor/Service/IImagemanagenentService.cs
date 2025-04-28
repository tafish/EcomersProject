using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomers.Cor.Service
{
    public interface IImagemanagenentService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
        void DeletImegaAsinc(string src);
    }
}
