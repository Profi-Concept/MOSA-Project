﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.IR.ConstantFolding
{
	public sealed class MulUnsigned32 : BaseTransformation
	{
		public MulUnsigned32() : base(IRInstruction.MulUnsigned32, OperandFilter.ResolvedConstant, OperandFilter.ResolvedConstant)
		{
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			transformContext.SetResultToConstant(context, (context.Operand1.ConstantUnsigned64 * context.Operand2.ConstantUnsigned64) & 0xFFFFFFFF);
		}
	}
}