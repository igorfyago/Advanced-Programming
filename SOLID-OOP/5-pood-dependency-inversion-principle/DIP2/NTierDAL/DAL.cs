using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NTier.DAL 
{

	/// <summary>
	/// Base Class for all Data Access Layer (DAL) objects used by ASPAlliance
	/// </summary>
	public abstract class DAL
	{
		private static String m_ConnectionString;
		
		/// <summary>
		/// References the database connection string found in the AppSettings["ConnectionString"] Web.Config element.
		/// </summary>
		protected static String ConnectionString
		{
			get
			{
				if (m_ConnectionString == null)
				{
					try
					{
						m_ConnectionString = (String) ConfigurationSettings.AppSettings["ConnectionString"];
					}
					catch
					{
						throw new ConfigurationException("Connection string value not set in web.config.");
					}

					if (m_ConnectionString == null)
					{
						throw new ConfigurationException("Connection string value not set in web.config.");
					}
				}
				return m_ConnectionString;
			}
		}

		/// <summary>
		/// Creates a SqlParameter for a stored procedure call.  Overload.  Defaults to Output Parameter.
		/// </summary>
		/// <param name="parameterName">The name of the parameter, usually beginning with @</param>
		/// <param name="DbType"></param>
		/// <param name="Size"></param>
		/// <returns>An instance of a SqlParameter holding the contents specified in the parameters.</returns>
		protected static SqlParameter pMaker(String parameterName, SqlDbType DbType, Int32 Size)
		{
			return pMaker(parameterName, DbType, Size, ParameterDirection.Output);
		}

		/// <summary>
		/// Creates a SqlParameter for a stored procedure call.  Overload.
		/// </summary>
		/// <param name="parameterName">The name of the parameter, usually beginning with @</param>
		/// <param name="DbType"></param>
		/// <param name="Size"></param>
		/// <param name="Direction"></param>
		/// <returns>An instance of a SqlParameter holding the contents specified in the parameters.</returns>
		protected static SqlParameter pMaker(String parameterName, SqlDbType DbType, Int32 Size, ParameterDirection Direction)
		{
			return pMaker(parameterName, DbType, Size, Direction, null);
		}

		/// <summary>
		/// Creates a SqlParameter for a stored procedure call.
		/// </summary>
		/// <param name="parameterName">The name of the parameter, usually beginning with @</param>
		/// <param name="DbType"></param>
		/// <param name="Size"></param>
		/// <param name="Direction"></param>
		/// <param name="Value">The value to pass as input.</param>
		/// <returns>An instance of a SqlParameter holding the contents specified in the parameters.</returns>
		protected static SqlParameter pMaker(String parameterName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, Object Value)
		{
			SqlParameter param;

			if(Size > 0)
			{
				param = new SqlParameter(parameterName, DbType, Size);
			}
			else
			{
				param = new SqlParameter(parameterName, DbType);
			}
			param.Direction = Direction;
			if (!(Direction == ParameterDirection.Output && Value == null))
			{
				param.Value = Value;
			}
			return param;
		}
	}
}