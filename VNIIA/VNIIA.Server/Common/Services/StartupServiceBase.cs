using System;
using System.Collections.Generic;
using System.Text;

using VNIIA.Server.Common.Interfaces;

namespace VNIIA.Server.Common.Services
{
	/// <summary>
	/// Базовый класс сервиса, запускаемого при старте системы
	/// </summary>
	public class StartupServiceBase : IStartupService
	{
		/// <summary>
		/// Приоритет сервиса.
		/// </summary>
		public virtual int Priority => int.MaxValue;

		/// <summary>
		/// Старт сервиса
		/// </summary>
		public virtual void Start()
		{

		}

		/// <summary>
		/// Остановка сервиса
		/// </summary>
		public virtual void Stop()
		{

		}
	}
}
