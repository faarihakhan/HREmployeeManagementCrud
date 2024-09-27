using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.DatabaseUtil;
using Repository.Implementation;

namespace Repository.Common.Implementation
{
	public class UnitOfWork: IUnitOfWork
	{
		#region private variables
		private readonly DbContext _dbContext;
		//private IRegistrationRepository _registrationRepository;
		private IEmployeeInformationRepository _employeeInformationRepository;
		#endregion

		#region constructor
		public UnitOfWork()
		{
			_dbContext = DbContextFactory.GetBackDbContext();

		}
		#endregion

		#region repository
		//public IRegistrationRepository RegistrationRepository => _registrationRepository ?? (_registrationRepository = new RegistrationRepository(_dbContext));
		public IEmployeeInformationRepository EmployeeInformationRepository => _employeeInformationRepository ?? (_employeeInformationRepository = new EmployeeInformationRepository(_dbContext));
		#endregion

		/// <summary>
		/// Commit
		/// </summary>
		/// <returns></returns>
		public int Commit()
		{
			return _dbContext.SaveChanges();
		}

		/// <summary>
		/// Commit Async
		/// </summary>
		/// <returns></returns>
		public Task<int> CommitAsync()
		{
			return _dbContext.SaveChangesAsync();
		}

		/// <summary>
		/// CommitAsync
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<int> CommitAsync(CancellationToken cancellationToken)
		{
			return _dbContext.SaveChangesAsync(cancellationToken);
		}

		/// <summary>
		/// Dispose
		/// </summary>
		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
