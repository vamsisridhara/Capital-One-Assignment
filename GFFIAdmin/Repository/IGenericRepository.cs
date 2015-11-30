using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
namespace GFFIAdmin.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> SelectAll();
        T SelectByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private NorthwindEntities db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new NorthwindEntities();
            table = db.Set<T>();
        }

        public GenericRepository(NorthwindEntities db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public List<T> SelectAll()
        {
            return table.Select(p => p).ToList();
            //return await table.ProjectToListAsync<T>();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
