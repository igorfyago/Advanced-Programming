using System;
using System.Configuration;

namespace NTier.BLL
{
	public abstract class BLL
	{
		private static String _applicationName;

		public static String ApplicationName
			{
				get
				{
					if (_applicationName == null)
					{
						try
						{
							_applicationName = (String) ConfigurationSettings.AppSettings["ApplicationName"];
						}
						catch
						{
							_applicationName = "Unknown";
						}
					}
					return _applicationName;
				}
			}
	}
}
