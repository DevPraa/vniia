using System;
using System.Collections.Generic;
using System.Text;

namespace VNIIA.ClientServerLibrary.Dtos
{
	public class DocumentPositionDto : EntityDto
	{
		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Сумма
		/// </summary>
		public int Sum { get; set; }

		/// <summary>
		/// Идентификатор документа с которым связана текущая позиция
		/// </summary>
		public int DocumentNumber { get; set; }
	}
}
