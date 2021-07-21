using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNIIA.Server.Models
{
	public class DocumentPosition : DocumentBase
	{

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Сумма
		/// </summary>
		public int Sum { get; set; }


		public int DocumentId { get; set; }
		/// <summary>
		/// Свойство навигации по ссылке: Свойство навигации, содержащее ссылку на одну связанную сущность.
		/// </summary>
		public Document Document { get; set; }
	}
}
