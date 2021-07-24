using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.ClientServerLibrary.Dtos;
using VNIIA.Server.Models;

namespace VNIIA.Server.Common.Helpers
{
	public static class DtoTool
	{
        /// <summary>
        /// Получение Dto
        /// </summary>
        public static DocumentDto ToDto(this Document document)
        {
            return document != null
                ? new DocumentDto
                {
                    Number = document.Number,
                    Date = document.Date,
                    Amount = document.Amount,
                    Note = document.Note,
                    Positions = document.Positions.ToDto()
                }
                : null;
        }

        /// <summary>
        /// Получение Dto
        /// </summary>
        public static DocumentPositionDto ToDto(this DocumentPosition documentPosition)
        {
            return documentPosition != null
                ? new DocumentPositionDto
                {
                    Number = documentPosition.Number,
                    Name = documentPosition.Name,
                    Sum = documentPosition.Sum,
                    DocumentId = documentPosition.Document.Number
                }
                : null;
        }

        /// <summary>
        /// Получение Dto
        /// </summary>
        public static IEnumerable<DocumentPositionDto> ToDto(this IEnumerable<DocumentPosition> documentPositionCollection)
        {
            List<DocumentPositionDto> collection = new List<DocumentPositionDto>();

			foreach (var documentPosition in documentPositionCollection)
			{
                collection.Add(documentPosition.ToDto());
            }

            return collection != null && collection.Count > 0 ? collection : null;
        }


    }
}
