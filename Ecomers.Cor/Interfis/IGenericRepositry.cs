using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Interfis
{
    public interface IGenericRepositry<T> where T : class
    {
       
        Task<IReadOnlyList<T>> GatAllAsinc(params Expression<Func<T, object>>[] includes);
        Task<T> GetBayIdAsinc(int Id);
        Task<T> GetBayIdAsinc(int Id, params Expression<Func<T, object>>[] includes);
        Task AddAsinc(T entity);
        Task UpdateAsinc(T entity);
        Task DeleteAsinc(int Id);

    }
}
