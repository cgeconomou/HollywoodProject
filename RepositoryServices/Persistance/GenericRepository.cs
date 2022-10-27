using Entities;
using MyDatabase;
using RepositoryServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : HollywoodEntity
    {
        public ApplicationDbContext db;
        public DbSet<T> table;


        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }


        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            //db.Entry(obj).State = EntityState.Added;//
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);   //db.Entry(obj).State = EntityState.Deleted;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return table.SingleOrDefault(predicate);
        }
    }
}
