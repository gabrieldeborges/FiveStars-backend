using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        protected Context Db; 
        public BaseRepository(Context context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Select()
        {
            throw new NotImplementedException();
        }

        public TEntity Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
