using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Domain.Entities;
using System.Linq;

namespace FIVESTARS.Infra.Data
{
    public class BaseMssqlRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context _context;
    
        public BaseMssqlRepository(Context mySqlContext)
        {
            _context = mySqlContext;
        }
    
        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }
    
        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    
        public void Delete(int id)
        {
            _context.Remove(Select(id));
            _context.SaveChanges();
        }
    
        public IList<TEntity> Select() =>
            _context.Set<TEntity>().ToList();
    
        public TEntity Select(int id) =>
            _context.Set<TEntity>().Find(id);
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

