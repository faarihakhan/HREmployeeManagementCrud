using Repository.Interface;
using Service.Common.Helper;
using Service.Common.Interface;

namespace Service.Implementation
{
	public abstract class GenericServices<TEntity, DEntity> : IDisposable, IGenericServices<TEntity, DEntity>
		where TEntity : class
		where DEntity : class
	{
		private IUnitOfWork _unitOfWork;
		private IGenericRepository<DEntity> _genericRepository;

		public IUnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
			protected set { _unitOfWork = value; }
		}
		public IGenericRepository<DEntity> GenericRepository
		{
			get { return _genericRepository; }
			protected set { _genericRepository = value; }
		}

		public virtual void Save(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			_genericRepository.Save(MapperHelper.Map<DEntity, TEntity>(entity));
			_unitOfWork.Commit();
		}

		public virtual void Update(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			_genericRepository.Update(MapperHelper.Map<DEntity, TEntity>(entity));
			_unitOfWork.Commit();
		}

		public virtual void Delete(object id)
		{
			_genericRepository.Delete(_genericRepository.FindById(id));
			_unitOfWork.Commit();
		}

		public virtual void Delete(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			_genericRepository.Delete(MapperHelper.Map<DEntity, TEntity>(entity));
			_unitOfWork.Commit();
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return MapperHelper.MapList<TEntity, DEntity>(_genericRepository.GetAll());
		}

		public virtual TEntity Find(System.Linq.Expressions.Expression<Func<DEntity, bool>> predicate)
		{
			return MapperHelper.Map<TEntity, DEntity>(_genericRepository.Find(predicate));
		}

		public virtual TEntity GetById(int id)
		{

			return MapperHelper.Map<TEntity, DEntity>(_genericRepository.FindById(id));
		}

		public virtual IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<DEntity, bool>> predicate)
		{
			return MapperHelper.MapList<TEntity, DEntity>(_genericRepository.FindBy(predicate));
		}

		public void SaveAll(List<TEntity> entity)
		{
			if (entity.ToList().Count == 0) throw new ArgumentNullException(nameof(entity));
			var convertListToEntity = MapperHelper.MapList<DEntity, TEntity>(entity);
			_genericRepository.SaveAll(convertListToEntity.ToList());
		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}

	}
}
