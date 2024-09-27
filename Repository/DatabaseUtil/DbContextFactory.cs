using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entity;

namespace Repository.DatabaseUtil
{
	public class DbContextFactory
	{
		/// <summary>
		/// Get Front DbContext
		/// </summary>
		/// <returns></returns>
		public static DbContext GetFrontDbContext()
		{
			return new FrontDbContext();
		}
		public static DbContext GetBackDbContext()
		{
			return new BackDbContext();
		}
	}
	public class BackDbContext : EmployeeContext
	{
		public BackDbContext()
		{

		}
		public BackDbContext(DbContextOptions<EmployeeContext> options) : base(options)
		{

		}
		#region On Model Creating
		/// <summary>
		/// On Model Creating
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		#endregion

		#region Properties & Variables
		public IConfigurationRoot Configuration { get; set; }

		#endregion

		#region On Configuring
		/// <summary>
		/// On Configuring
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var configuration = new ConfigurationBuilder()
				  .AddJsonFile("appsettings.json")
				  .AddJsonFile($"appsettings.{ASPNETCORE_ENVIRONMENT}.json");
			Configuration = configuration.Build();
			optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Employee"));
		}
		#endregion

	}
	public class FrontDbContext : DbContext
	{
		#region On Model Creating
		/// <summary>
		/// On Model Creating
		/// </summary>
		/// <param name="builder"></param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
		#endregion
	}
}

