// ===============================================================================
// Microsoft Data Access Application Block for .NET 3.0
//
// Odbc.cs
//
// This file contains the implementations of the AdoHelper supporting Odbc.
//
// For more information see the Documentation. 
// ===============================================================================
// Release history
// VERSION	DESCRIPTION
//   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
//   3.0	New abstract class supporting the same methods using ADO.NET interfaces
//
// ===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ExtractTransformLoad.Data
{
	public class Odbc : AdoHelper
	{
		static Regex _regExpr = new Regex( @"\{.*call|CALL\s\w+.*}", RegexOptions.Compiled );

		public Odbc()
		{
		}

		public override IDbConnection GetConnection( string connectionString )
		{
			return new OdbcConnection( connectionString );
		}

		protected override IDbDataAdapter GetDataAdapter()
		{
			return new OdbcDataAdapter(); 
		}

		protected override void DeriveParameters( IDbCommand cmd )
		{
			if( !( cmd is OdbcCommand ) )
				throw new ArgumentException( "The command provided is not a OdbcCommand instance.", "cmd" );
			OdbcCommandBuilder.DeriveParameters( (OdbcCommand)cmd );
		}

		public override IDataParameter GetParameter()
		{
			return new OdbcParameter(); 
		}
		
		protected override void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDataParameter[] commandParameters, out bool mustCloseConnection )
		{
			base.PrepareCommand( command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection );
			
			// Post-process the CommandText to convert into an ODBC syntax
			if( command.CommandType == CommandType.StoredProcedure )
			{
				if( !_regExpr.Match( command.CommandText ).Success && // If does not like like { call sp_name() }
					command.CommandText.Trim().IndexOf( " " ) == -1 ) // If there's only a stored procedure name
				{
					StringBuilder par = new StringBuilder();
					if( command.Parameters.Count != 0 )
					{
						bool isFirst = true;
						for( int i = 0; i < command.Parameters.Count; i++ )
						{
							OdbcParameter p = command.Parameters[i] as OdbcParameter;
							if( p.Direction != ParameterDirection.ReturnValue )
							{
								if( isFirst )
								{
									isFirst = false;
									par.Append( "(?" );
								}
								else
								{
									par.Append( ",?" );
								}
							}
						}
						par.Append( ")" );
					}
					command.CommandText = "{ call " + command.CommandText + par.ToString() + " }";
				}
			}
		}
	}
}