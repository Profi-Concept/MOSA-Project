// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.StrengthReduction
{
	/// <summary>
	/// MulSigned32ByNegative1
	/// </summary>
	public sealed class MulSigned32ByNegative1 : BaseTransformation
	{
		public MulSigned32ByNegative1() : base(IRInstruction.MulSigned32, true)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand2.IsResolvedConstant)
				return false;

			if (context.Operand2.ConstantUnsigned64 != 18446744073709551615)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1;

			var e1 = transformContext.CreateConstant(To32(0));

			context.SetInstruction(IRInstruction.Sub32, result, e1, t1);
		}
	}
}