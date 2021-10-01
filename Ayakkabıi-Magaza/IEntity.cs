using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayakkabıi_Magaza
{
    interface IEntity<T> where T : class
    {
        List<T> GetAll();
        List<T> Get(string key);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
