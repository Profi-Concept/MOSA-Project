// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.Simplification
{
	/// <summary>
	/// Add64MultipleWithCommon
	/// </summary>
	public sealed class Add64MultipleWithCommon : BaseTransformation
	{
		public Add64MultipleWithCommon() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand2;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t2, t3);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t1, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v1
	/// </summary>
	public sealed class Add64MultipleWithCommon_v1 : BaseTransformation
	{
		public Add64MultipleWithCommon_v1() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand2;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t3, t2);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t1, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v2
	/// </summary>
	public sealed class Add64MultipleWithCommon_v2 : BaseTransformation
	{
		public Add64MultipleWithCommon_v2() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand1;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t2, t3);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t1, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v3
	/// </summary>
	public sealed class Add64MultipleWithCommon_v3 : BaseTransformation
	{
		public Add64MultipleWithCommon_v3() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2.Definitions[0].Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand2;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t3, t1);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t2, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v4
	/// </summary>
	public sealed class Add64MultipleWithCommon_v4 : BaseTransformation
	{
		public Add64MultipleWithCommon_v4() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2.Definitions[0].Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand2;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t1, t3);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t2, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v5
	/// </summary>
	public sealed class Add64MultipleWithCommon_v5 : BaseTransformation
	{
		public Add64MultipleWithCommon_v5() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand1;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t3, t2);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t1, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v6
	/// </summary>
	public sealed class Add64MultipleWithCommon_v6 : BaseTransformation
	{
		public Add64MultipleWithCommon_v6() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2.Definitions[0].Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand1;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t1, t3);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t2, v1);
		}
	}

	/// <summary>
	/// Add64MultipleWithCommon_v7
	/// </summary>
	public sealed class Add64MultipleWithCommon_v7 : BaseTransformation
	{
		public Add64MultipleWithCommon_v7() : base(IRInstruction.Add64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned64)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2.Definitions[0].Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand1.Definitions[0].Operand2;
			var t3 = context.Operand2.Definitions[0].Operand1;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I8);

			context.SetInstruction(IRInstruction.Add64, v1, t3, t1);
			context.AppendInstruction(IRInstruction.MulUnsigned64, result, t2, v1);
		}
	}
}