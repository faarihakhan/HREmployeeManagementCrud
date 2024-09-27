using AutoMapper;

namespace Service.Common.Helper
{
	internal class MapperHelper
	{
		private static IMapper GetMapper<TDestination, TSource>()
		{
			var config = new MapperConfiguration(cfg => {
				cfg.AllowNullCollections = true;
				cfg.CreateMap<TSource, TDestination>();
				cfg.AddProfile(new MappingProfile());
			});

			return config.CreateMapper();
		}

		public static TDestination Map<TDestination, TSource>(TSource entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<TDestination>(entity);
		}

		public static IQueryable<TDestination> MapList<TDestination, TSource>(IQueryable<TSource> entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<IQueryable<TSource>, IQueryable<TDestination>>(entity);
		}
		public static IEnumerable<TDestination> MapList<TDestination, TSource>(IEnumerable<TSource> entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(entity);
		}

		public static ICollection<TDestination> MapList<TDestination, TSource>(ICollection<TSource> entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<ICollection<TSource>, ICollection<TDestination>>(entity);
		}
		public static IList<TDestination> MapList<TDestination, TSource>(IList<TSource> entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<IList<TSource>, IList<TDestination>>(entity);
		}

		public static List<TDestination> MapList<TDestination, TSource>(List<TSource> entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<List<TSource>, List<TDestination>>(entity);
		}
		public static TDestination[] MapList<TDestination, TSource>(TSource[] entity)
		{
			var _mapper = GetMapper<TDestination, TSource>();
			return _mapper.Map<TSource[], TDestination[]>(entity);
		}
	}
}

