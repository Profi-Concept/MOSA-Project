// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Push32 - Push multiple registers onto the stack
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Push32 : ARMv6Instruction
	{
		public override int ID { get { return 730; } }

		internal Push32()
			: base(1, 3)
		{
		}
	}
}
