using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Common.Implementation
{
	public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		public DbContext Context;

		private DbSet<TEntity> _set;

		protected DbSet<TEntity> Set => _set ?? (_set = Context.Set<TEntity>());

		public IList<TEntity> GetAll()
		{
			return Set.AsNoTracking().ToList();
		}

		public Task<List<TEntity>> GetAllAsync()
		{
			return Set.ToListAsync();
		}

		public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return Set.ToListAsync(cancellationToken);
		}

		public List<TEntity> PageAll(int skip, int take)
		{
			return Set.Skip(skip).Take(take).ToList();
		}

		public Task<List<TEntity>> PageAllAsync(int skip, int take)
		{
			return Set.Skip(skip).Take(take).ToListAsync();
		}

		public Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
		{
			return Set.Skip(skip).Take(take).ToListAsync(cancellationToken);
		}
		public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			TEntity result = Set.Find(predicate);
			return result;
		}

		public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			IQueryable<TEntity> result = Set.Where(predicate).AsNoTracking();
			return result;
		}

		public TEntity FindById(object id)
		{
			TEntity tEntity = Set.Find(id);
			return tEntity;
		}

		public ValueTask<TEntity> FindByIdAsync(object id)
		{
			return Set.FindAsync(id);
		}

		public ValueTask<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id)
		{
			return Set.FindAsync(cancellationToken, id);
		}

		public virtual void Save(TEntity entity)
		{
			Set.Add(entity);
		}

		public void Update(TEntity entity)
		{
			var entry = Context.Entry(entity);
			if (entry.State == EntityState.Detached)
			{
				Set.Attach(entity);
				entry = Context.Entry(entity);
			}
			entry.State = EntityState.Modified;
		}

		public void Delete(TEntity entity)
		{
			Set.Remove(entity);
		}
		public virtual void SaveAll(List<TEntity> entity)
		{
			Set.AddRange(entity);
		}
	}
}
