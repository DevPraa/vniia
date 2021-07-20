using System;
using System.Collections.Generic;
using System.Text;

namespace VNIIA.Server.Common.Services
{
	public class WebAppStartUp : StartupServiceBase
	{
		public override int Priority => 0;

		public WebAppStartUp()
		{

		}

		public override void Start()
		{
			base.Start();
		}


		public override void Stop()
		{
			base.Stop();
		}
	}
}
