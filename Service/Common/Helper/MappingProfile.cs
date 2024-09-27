using AutoMapper;

namespace Service.Common.Helper
{
	internal class MappingProfile: Profile
	{
		public MappingProfile()
		{
			SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
			DestinationMemberNamingConvention = new PascalCaseNamingConvention();
		}
	}
}
