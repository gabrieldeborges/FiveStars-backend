using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Domain.Entities;
using System.Linq;

namespace FIVESTARS.Infra.Data
{
    public class BaseMssqlRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;
    
        public BaseMssqlRepository(Context mySqlContext)
        {
            _context = mySqlContext;
        }
    
        public int Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            return _context.SaveChanges();
        }
    
        public int Update(TEntity obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();
        }
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

