using System.Collections.Generic;
using System.ComponentModel;

using VNIIA.Client.ViewModels;
using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client.Helpers
{
	public static class DtoTool
	{
		public static DocumentViewModel ToViewModel(this DocumentDto documentDto)
		{
			DocumentViewModel doc = new DocumentViewModel(documentDto.Number);
			doc.Date = documentDto.Date;
			doc.Note = documentDto.Note;
			doc.SetAmountProperty(documentDto.Amount);
			doc.DocumentPositions = documentDto.Positions.ToViewModel();
			return doc;
		}

		public static IEnumerable<DocumentViewModel> ToViewModel(this IEnumerable<DocumentDto> documentDto)
		{
			List<DocumentViewModel> collection = new List<DocumentViewModel>();
			foreach (var document in documentDto)
			{
				collection.Add(document.ToViewModel());
			}
			return collection;
		}


		public static DocumentPositionViewModel ToViewModel(this DocumentPositionDto documentPositionDto)
		{
			DocumentPositionViewModel doc = new DocumentPositionViewModel(documentPositionDto.Number, documentPositionDto.DocumentId);
			doc.Name = documentPositionDto.Name;
			doc.Sum = documentPositionDto.Sum;
			return doc;
		}

		public static BindingList<DocumentPositionViewModel> ToViewModel(this IEnumerable<DocumentPositionDto> documentPositionDto)
		{
			if (documentPositionDto == null) return  new BindingList<DocumentPositionViewModel>();

			BindingList<DocumentPositionViewModel> collection = new BindingList<DocumentPositionViewModel>();
			foreach (var documentPosition in documentPositionDto)
			{
				collection.Add(documentPosition.ToViewModel());
			}
			return collection;
		}


		/// <summary>
		/// Получение Dto
		/// </summary>
		public static DocumentDto ToDto(this DocumentViewModel document)
		{
			return document != null
				? new DocumentDto
				{
					Number = document.Number,
					Date = document.Date,
					Amount = document.Amount,
					Note = document.Note,
					Positions = document.DocumentPositions.ToDto()
				}
				: null;
		}

		/// <summary>
		/// Получение Dto
		/// </summary>
		public static DocumentPositionDto ToDto(this DocumentPositionViewModel documentPosition)
		{
			return documentPosition != null
				? new DocumentPositionDto
				{
					Number = documentPosition.Number,
					Name = documentPosition.Name,
					Sum = documentPosition.Sum,
					DocumentId = documentPosition.DocumentNumber
				}
				: null;
		}

		/// <summary>
		/// Получение Dto
		/// </summary>
		public static IEnumerable<DocumentPositionDto> ToDto(this IEnumerable<DocumentPositionViewModel> documentPositionCollection)
		{
			if (documentPositionCollection == null) return null;

			List<DocumentPositionDto> collection = new List<DocumentPositionDto>();
			
			foreach (var documentPosition in documentPositionCollection)
			{
				collection.Add(documentPosition.ToDto());
			}

			return collection != null && collection.Count > 0 ? collection : null;
		}
	}
}
