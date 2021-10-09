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

        public void Dispose()
        {
            Db.Dispose();
        }

        public int Insert(TEntity obj)
        {
            DbSet.Add(obj);
            return Db.SaveChanges();
        }
        public int Update(TEntity obj)
        {
            DbSet.Update(obj);
            return Db.SaveChanges();
        }
    }
}
