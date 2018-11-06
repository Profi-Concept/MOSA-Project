// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Common;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Orr32 - Bitwise OR
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Orr32 : ARMv6Instruction
	{
		public override int ID { get { return 728; } }

		internal Orr32()
			: base(1, 3)
		{
		}

		protected override void Emit(InstructionNode node, ARMv6CodeEmitter emitter)
		{
			EmitDataProcessingInstruction(node, emitter, Bits.b1100);
		}
	}
}
