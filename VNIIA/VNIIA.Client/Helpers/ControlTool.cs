using System;
using System.Windows.Forms;

namespace VNIIA.Client.Helpers
{
	public static class ControlTool
	{
		public static void HelpInvoke(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}
	}
}
