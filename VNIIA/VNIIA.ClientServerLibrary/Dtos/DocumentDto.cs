using System;
using System.Collections.Generic;
using System.Text;

namespace VNIIA.ClientServerLibrary.Dtos
{
	public class DocumentDto : EntityDto
	{
		/// <summary>
		/// Дата создания документа
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Сумма всех позиций документа
		/// </summary>
		public int Amount { get; set; }

		/// <summary>
		/// Примечание
		/// </summary>
		public string Note { get; set; }

		/// <summary>
		/// Список связных позиций документа
		/// </summary>
		public IEnumerable<DocumentPositionDto> DocumentPositions { get; set; }
	}
}
