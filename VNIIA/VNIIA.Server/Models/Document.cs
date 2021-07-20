using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNIIA.Server.Models
{
	public class Document : DocumentBase
	{
		/// <summary>
		/// Дата создания документа
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Сумма всех позиций документа
		/// </summary>
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int Amount { get; set; }

		/// <summary>
		/// Примечание
		/// </summary>
		public string Note { get; set; }

		/// <summary>
		/// Свойство навигации коллекции: Свойство навигации, содержащее ссылки на множество связанных сущностей.
		/// </summary>
		public List<DocumentPosition> DocumentPositions { get; set; }
	}
}
