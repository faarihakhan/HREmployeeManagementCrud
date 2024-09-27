namespace Service.Common.Interface
{
	public interface IGenericServices<TEntity, DEntity>
	{
		void SaveAll(List<TEntity> entity);
		void Save(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		IEnumerable<TEntity> GetAll();
		TEntity GetById(int id);
		IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<DEntity, bool>> predicate);
		TEntity Find(System.Linq.Expressions.Expression<Func<DEntity, bool>> predicate);
	}
}
