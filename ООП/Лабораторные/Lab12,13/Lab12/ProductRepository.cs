using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class ProductRepository : IRepository<PRODUCTS>
    {
        private CodeFirst db;

        public ProductRepository(CodeFirst context)
        {
            this.db = context;
        }

        public IEnumerable<PRODUCTS> GetAll()
        {
            return db.PRODUCTS;
        }

        public PRODUCTS Get(int id)
        {
            return db.PRODUCTS.Find(id);
        }

        public void Create(PRODUCTS prod)
        {
            db.PRODUCTS.Add(prod);
        }

        public void Update(PRODUCTS prod)
        {
            db.Entry(prod).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PRODUCTS prod = db.PRODUCTS.Find(id);
            if (prod != null)
                db.PRODUCTS.Remove(prod);
        }
    }
}
