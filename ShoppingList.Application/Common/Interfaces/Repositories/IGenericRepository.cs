using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IGenericCommandRepository<T>, IGenericQueryRepository<T> where T : BaseEntity
    {
    }
   
  
}
