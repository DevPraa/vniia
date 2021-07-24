using System;
using System.ComponentModel;

using VNIIA.ClientServerLibrary.Attributes;

namespace VNIIA.Client.ViewModels
{
	/// <summary>
	/// View модель для документа
	/// </summary>
	public class DocumentViewModel : NotifyPropertyChangedViewModel
	{
		private int number;
		private DateTime date;
		private int amount;
		private string note;
		private BindingList<DocumentPositionViewModel> documentPositions;


		public DocumentViewModel(int Id)
		{
			number = Id;
			
		}

		private void CalculateAmount()
		{
			amount = 0;
			foreach (var documentPosition in documentPositions)
			{
				amount += documentPosition.Sum;
			}

			NotifyPropertyChanged(nameof(Amount));
		}

		private void DocumentPositions_ListChanged(object sender, ListChangedEventArgs e)
		{
			CalculateAmount();
		}

		/// <summary>
		/// Номер
		/// </summary>
		[Order]
		public int Number => number;

		/// <summary>
		/// Дата создания документа
		/// </summary>
		[Order]
		public DateTime Date
		{
			get => date;
			set
			{
				if (value != date)
				{
					date = value;
					NotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Сумма всех позиций документа
		/// </summary>
		[Order]
		public int Amount => amount;

		/// <summary>
		/// Примечание
		/// </summary>
		[Order]
		public string Note
		{
			get => note;
			set
			{
				if (value != note)
				{
					note = value;
					NotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Список связных позиций документа
		/// </summary>
		[Order]
		public BindingList<DocumentPositionViewModel> DocumentPositions
		{
			get => documentPositions;
			set
			{
				if (value != null)
				{
					
				}
				if (value != documentPositions)
				{
					documentPositions = value;
					documentPositions.ListChanged += DocumentPositions_ListChanged;
					NotifyPropertyChanged();
					CalculateAmount();
				}

			}
		}

		public void SetAmountProperty(int value)
		{
			amount = value;
			NotifyPropertyChanged(nameof(Amount));
		}
	}
}
