// ===============================================================================
// Microsoft Data Access Application Block for .NET 3.0
//
// Oldedb.cs
//
// This file contains the implementations of the AdoHelper supporting OleDb.
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
using System.Data.OleDb;
using System.Xml;

namespace ExtractTransformLoad.Data
{
	public class OleDb : AdoHelper
	{
		public OleDb()
		{
		}

		public override IDbConnection GetConnection( string connectionString )
		{
			return new OleDbConnection( connectionString );
		}

		protected override IDbDataAdapter GetDataAdapter()
		{
			return new OleDbDataAdapter(); 
		}

		protected override void DeriveParameters( IDbCommand cmd )
		{
			if( !( cmd is OleDbCommand ) )
				throw new ArgumentException( "The command provided is not a OleDbCommand instance.", "cmd" );
			OleDbCommandBuilder.DeriveParameters( (OleDbCommand)cmd );
		}

		public override IDataParameter GetParameter()
		{
			return new OleDbParameter(); 
		}
		
	}
}