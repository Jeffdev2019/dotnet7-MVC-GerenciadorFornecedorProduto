using Dev.IO.Business.Interfaces.Repository;
using Dev.IO.Data.Context;
using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dev.IO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public  async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
            

        public virtual async Task<List<TEntity>> ObterTodos() =>
            await DbSet.ToListAsync();


        public virtual async Task Remover(Guid id) 
        {
            DbSet.Remove(new TEntity { Id = id});
            await SaveChanges();
        }

        public  async Task<int> SaveChanges() => 
            await Db.SaveChangesAsync();
    }
}
