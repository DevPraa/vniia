using System;
using System.Collections.Generic;
using System.Text;

namespace VNIIA.Server.Common.Interfaces
{
	/// <summary>
	/// Интерфейс для сервисов которые должны запускаться при старте приложения.
	/// </summary>
	interface IStartupService
	{
		/// <summary>
		/// Задает приоритет при старте
		/// </summary>
		int Priority { get; }
		/// <summary>
		/// Запустить сервис
		/// </summary>
		void Start();

		/// <summary>
		/// Остановить сервис
		/// </summary>
		void Stop();
	}
}
