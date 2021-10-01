using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayakkabıi_Magaza
{
    public class SqlServerCustomerDal : IEntity<Product>
    {
        public void Add(Product entity)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Entry(entity);
                result.State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Product entity)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Entry(entity);
                result.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> Get(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Etrade.Where(p => p.ModelAd.Contains(key)).ToList();
            }
        }

        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Etrade.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Etrade.SingleOrDefault(p => p.Modelid == id);
                return result;
            }
        }

        public void Update(Product entity)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Entry(entity);
                result.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
