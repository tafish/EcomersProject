using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Riposatre
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : class
    {
        private readonly AppDbContext _Context;

        public GenericRepositry(AppDbContext context)
        {
            _Context = context;
        }
        public async Task AddAsinc(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task<int> CountAsinc()
        => await _Context.Set<T>().CountAsync();

        public async Task DeleteAsinc(int Id)
        {
            var entity = await _Context.Set<T>().FindAsync(Id);
            _Context.Set<T>().Remove(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GatAllAsinc()
            => await _Context.Set<T>().AsNoTracking().ToListAsync();


        public async Task<IReadOnlyList<T>> GatAllAsinc(params Expression<Func<T, object>>[] includes)
        {
            var query = _Context.Set<T>().AsNoTracking();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetBayIdAsinc(int Id)
        {
            var entity = await _Context.Set<T>().FindAsync(Id);
            return entity;
        }

        public async Task<T> GetBayIdAsinc(int Id, params Expression<Func<T, object>>[] includes)
        {
            var query = _Context.Set<T>().AsNoTracking();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            var entity = await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == Id);
            return entity;
        }

        public async Task UpdateAsinc(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
       
         
    }
}
