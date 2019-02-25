// ===============================================================================
// Microsoft Data Access Application Block for .NET 3.0
//
// DaabSectionHandler.cs
//
// This file contains the implementations of the DAABSectionHandler 
// configuration section handler.
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
using System.Configuration;
using System.Xml;

namespace ExtractTransformLoad.Data
{
	public class DAABSectionHandler : 
		IConfigurationSectionHandler
	{
		#region IConfigurationSectionHandler Members

		public object Create(object parent, object configContext, XmlNode section)
		{
			Hashtable ht = new Hashtable();
			XmlNodeList list = section.SelectNodes( "daabProvider" );
			foreach( XmlNode prov in list )
			{
				if( prov.Attributes[ "alias" ] == null )
					throw new Exception( "The 'daabProvider' node must contain an attribute named 'alias' with the alias name for the provider." );
				if( prov.Attributes[ "assembly" ] == null )
					throw new Exception( "The 'daabProvider' node must contain an attribute named 'assembly' with the name of the assembly containing the provider." );
				if( prov.Attributes[ "type" ] == null )
					throw new Exception( "The 'daabProvider' node must contain an attribute named 'type' with the full name of the type for the provider." );

				ht[ prov.Attributes[ "alias" ].Value ] = new ProviderAlias( prov.Attributes[ "assembly" ].Value, prov.Attributes[ "type" ].Value );
			}
			return ht;
		}

		#endregion
	}

	public class ProviderAlias
	{
		public ProviderAlias( string assemblyName, string typeName )
		{
			_assemblyName = assemblyName;
			_typeName = typeName;
		}

		public string AssemblyName
		{
			get{ return _assemblyName; }
		} string _assemblyName;

		public string TypeName
		{
			get{ return _typeName; }
		} string _typeName;
	}
}