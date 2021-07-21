using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNIIA.Server.Models
{
	public interface IEntity
	{
		int Number { get; set; }
	}

	public abstract class DocumentBase : IEntity
	{
		/// <summary>
		/// Номер документа
		/// </summary>
		[Key]
		public virtual int Number { get; set; }
	}
}
