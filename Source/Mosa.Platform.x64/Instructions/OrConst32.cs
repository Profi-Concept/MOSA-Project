// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// OrConst32
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class OrConst32 : X64Instruction
	{
		public override int ID { get { return 534; } }

		internal OrConst32()
			: base(1, 2)
		{
		}

		public override bool IsCommutative { get { return true; } }

		public override bool IsZeroFlagModified { get { return true; } }

		public override bool IsCarryFlagCleared { get { return true; } }

		public override bool IsCarryFlagModified { get { return true; } }

		public override bool IsSignFlagModified { get { return true; } }

		public override bool IsOverflowFlagCleared { get { return true; } }

		public override bool IsOverflowFlagModified { get { return true; } }

		public override bool IsParityFlagModified { get { return true; } }
	}
}
