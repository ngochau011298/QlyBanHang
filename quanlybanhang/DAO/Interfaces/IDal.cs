using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IDal<T> where T:class
    {
        DataTable GetAll();
        T GetById(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
       
    }
}
