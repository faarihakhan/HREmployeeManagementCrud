using System.ComponentModel;

namespace Component
{
	public enum Action
	{
		[Description("Create")]
		Create = 1,
		[Description("Update")]
		Update = 2,
		[Description("Delete")]
		Delete = 3,
		[Description("View")]
		View = 4
	}
}
