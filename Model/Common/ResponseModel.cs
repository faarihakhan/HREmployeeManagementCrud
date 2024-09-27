using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
	public class ResponseModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Message { get; set; }
		public bool IsSuccess { get; set; }
		public bool IsAdmin { get; set; }
		public int Status { get; set; }
		public object Model { get; set; }
		public Component.Action Action { get; set; }
	}
}
