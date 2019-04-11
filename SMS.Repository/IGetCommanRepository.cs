using System.Collections.Generic;

namespace SMS.Repository
{
    public interface IGetCommanRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetEntities();
    }
}
