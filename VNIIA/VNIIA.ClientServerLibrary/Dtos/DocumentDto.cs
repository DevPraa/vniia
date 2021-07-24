using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.ClientServerLibrary.Attributes;

namespace VNIIA.ClientServerLibrary.Dtos
{
	public class DocumentDto : EntityDto
	{
		/// <summary>
		/// Дата создания документа
		/// </summary>
		[Order]
		public DateTime Date { get; set; }

		/// <summary>
		/// Сумма всех позиций документа
		/// </summary>
		[Order]
		public int Amount { get; set; }

		/// <summary>
		/// Примечание
		/// </summary>
		[Order]
		public string Note { get; set; }

		/// <summary>
		/// Список связных позиций документа
		/// </summary>
		[Order]
		public IEnumerable<DocumentPositionDto> Positions { get; set; }
	}
}
