using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
	public interface IUnitOfWork: IDisposable
	{
		int Commit();
		Task<int> CommitAsync();
		Task<int> CommitAsync(CancellationToken cancellationToken);
		//IEmployeeInformationRepository EmployeeInformationRepository { get; }
        //IRegistrationRepository RegistrationRepository {  get; }
        IEmployeeInformationRepository EmployeeInformationRepository {  get; }

    }
}
