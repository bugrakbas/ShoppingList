using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Common.Interfaces.Repositories
{
    public interface IGenericQueryRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);

    }
}
