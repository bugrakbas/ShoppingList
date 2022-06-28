using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Common.Interfaces.Repositories
{
    public interface IGenericCommandRepository<T> where T : class
    {

        Task Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
