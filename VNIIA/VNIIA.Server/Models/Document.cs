using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace VNIIA.Server.Models
{
	[Table("Documents")]
	public class Document : DocumentBase
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
		[MaxLength(2000)]
		public string Note { get; set; }

		/// <summary>
		/// Свойство навигации коллекции: Свойство навигации, содержащее ссылки на множество связанных сущностей.
		/// </summary>
		public List<DocumentPosition> Positions { get; set; }
	}
}
