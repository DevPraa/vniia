using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNIIA.Server.Models
{
	public abstract class DocumentBase
	{
		/// <summary>
		/// Номер документа
		/// </summary>
		[Key]
		public virtual int Number { get; set; }
	}
}
