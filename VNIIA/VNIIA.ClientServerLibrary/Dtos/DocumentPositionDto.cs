using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.ClientServerLibrary.Attributes;

namespace VNIIA.ClientServerLibrary.Dtos
{
	public class DocumentPositionDto : EntityDto
	{
		/// <summary>
		/// Наименование
		/// </summary>
		[Order]
		public string Name { get; set; }
		/// <summary>
		/// Сумма
		/// </summary>
		[Order]
		public int Sum { get; set; }

		/// <summary>
		/// Идентификатор документа с которым связана текущая позиция
		/// </summary>
		[Order]
		public int DocumentId { get; set; }
	}
}
