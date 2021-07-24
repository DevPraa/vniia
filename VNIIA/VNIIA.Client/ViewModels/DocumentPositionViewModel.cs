using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.ClientServerLibrary.Attributes;

namespace VNIIA.Client.ViewModels
{
	/// <summary>
	/// View модель для позиции документа
	/// </summary>
	public class DocumentPositionViewModel : NotifyPropertyChangedViewModel
	{
		public DocumentPositionViewModel(int documentPositionId, int documentId)
		{
			number = documentPositionId;
			this.documentId = documentId;
		}
		private int number;
		private string name;
		private int sum;
		private int documentId;

		/// <summary>
		/// Номер
		/// </summary>
		[Order]
		public int Number => number;

		/// <summary>
		/// Наименование
		/// </summary>
		[Order]
		public string Name
		{
			get => name;
			set
			{
				if (value != name)
				{
					name = value;
					NotifyPropertyChanged();
				}
			}
		}
		/// <summary>
		/// Сумма
		/// </summary>
		[Order]
		public int Sum
		{
			get => sum;
			set
			{
				if (value != sum)
				{
					sum = value;
					NotifyPropertyChanged();
				}
			}
		}


		/// <summary>
		/// Id документа
		/// </summary>
		[Order]
		public int DocumentNumber=> documentId;
	}
}
