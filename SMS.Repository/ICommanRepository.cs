using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository
{
	public interface ICommanRepository<TEntity> where TEntity : class
	{
		TEntity GetEntityById(int entityId);
		List<TEntity> GetEntityList();
		string InsertEntity(TEntity entity);
		string UpdateEntity(TEntity entity);
		string DeleteEntity(int entityId);
	}
}
