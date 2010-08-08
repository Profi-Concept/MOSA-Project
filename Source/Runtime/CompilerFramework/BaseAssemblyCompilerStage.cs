/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (grover) <sharpos@michaelruck.de>
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

using Mosa.Runtime.Linker;
using Mosa.Runtime.Metadata;
using Mosa.Runtime.Metadata.Tables;
using Mosa.Runtime.Vm;
using Mosa.Runtime.Metadata.Signatures;
using Mosa.Runtime.Loader;

namespace Mosa.Runtime.CompilerFramework
{
	/// <summary>
	/// Basic base class for assembly compiler pipeline stages
	/// </summary>
	public abstract class BaseAssemblyCompilerStage
	{
		#region Data members

		/// <summary>
		/// Holds the Architecture during compilation.
		/// </summary>
		protected IArchitecture architecture;

		/// <summary>
		/// Holds the assembly Compiler.
		/// </summary>
		protected AssemblyCompiler compiler;

		/// <summary>
		/// Holds the current type system during compilation.
		/// </summary>
		protected ITypeSystem typeSystem;

		/// <summary>
		/// Holds the assembly loader.
		/// </summary>
		/// <value>The assembly loader.</value>
		protected IAssemblyLoader assemblyLoader;

		#endregion // Data members

		#region IAssemblyCompilerStage members

		public void Setup(AssemblyCompiler compiler)
		{
			this.compiler = compiler;
			architecture = compiler.Architecture;
			typeSystem = compiler.TypeSystem; 
			assemblyLoader = compiler.AssemblyLoader; 
		}

		#endregion // IAssemblyCompilerStage members

	}
}