using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.ClientServerLibrary.Attributes;

namespace VNIIA.ClientServerLibrary.Dtos
{
	public class EntityDto
	{
		[Order(1)]
		public int Number { get; set; }
	}
}
