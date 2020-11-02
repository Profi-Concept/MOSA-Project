// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transform.Auto.Simplification
{
	/// <summary>
	/// MulSigned32ByNegative1
	/// </summary>
	public sealed class MulSigned32ByNegative1 : BaseTransformation
	{
		public MulSigned32ByNegative1() : base(IRInstruction.MulSigned32)
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

	/// <summary>
	/// MulSigned32ByNegative1_v1
	/// </summary>
	public sealed class MulSigned32ByNegative1_v1 : BaseTransformation
	{
		public MulSigned32ByNegative1_v1() : base(IRInstruction.MulSigned32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsResolvedConstant)
				return false;

			if (context.Operand1.ConstantUnsigned64 != 18446744073709551615)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand2;

			var e1 = transformContext.CreateConstant(To32(0));

			context.SetInstruction(IRInstruction.Sub32, result, e1, t1);
		}
	}
}