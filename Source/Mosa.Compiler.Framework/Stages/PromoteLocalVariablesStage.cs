/*
 * (c) 2012 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using Mosa.Compiler.Framework.IR;
using Mosa.Compiler.InternalTrace;

namespace Mosa.Compiler.Framework.Stages
{
	/// <summary>
	///
	/// </summary>
	public sealed class PromoteLocalVariablesStage : BaseMethodCompilerStage, IMethodCompilerStage, IPipelineStage
	{
		private CompilerTrace trace;

		#region IMethodCompilerStage Members

		/// <summary>
		/// Performs stage specific processing on the compiler context.
		/// </summary>
		void IMethodCompilerStage.Execute()
		{
			// Unable to optimize SSA w/ exceptions or finally handlers present
			if (BasicBlocks.HeadBlocks.Count != 1)
				return;

			trace = CreateTrace();

			foreach (var local in MethodCompiler.LocalVariables)
			{
				if (local.Uses.Count == 0)
					continue;

				if (!local.IsReferenceType && !local.IsInteger && !local.IsR && !local.IsChar && !local.IsBoolean && !local.IsPointer)
					continue;

				if (ContainsAddressOf(local))
					continue;

				Promote(local);
			}
		}

		#endregion IMethodCompilerStage Members

		private bool ContainsAddressOf(Operand local)
		{
			foreach (int index in local.Uses)
			{
				Context ctx = new Context(InstructionSet, index);

				if (ctx.Instruction == IRInstruction.AddressOf)
					return true;
			}

			return false;
		}

		private void Promote(Operand local)
		{
			var v = MethodCompiler.CreateVirtualRegister(local.Type);

			if (trace.Active) trace.Log("*** Replacing: " + local.ToString() + " with " + v.ToString());

			foreach (int index in local.Uses.ToArray())
			{
				Context ctx = new Context(InstructionSet, index);

				for (int i = 0; i < ctx.OperandCount; i++)
				{
					Operand operand = ctx.GetOperand(i);

					if (local == operand)
					{
						if (trace.Active) trace.Log("BEFORE:\t" + ctx.ToString());
						ctx.SetOperand(i, v);
						if (trace.Active) trace.Log("AFTER: \t" + ctx.ToString());
					}
				}
			}

			foreach (int index in local.Definitions.ToArray())
			{
				Context ctx = new Context(InstructionSet, index);

				for (int i = 0; i < ctx.OperandCount; i++)
				{
					Operand operand = ctx.GetResult(i);

					if (local == operand)
					{
						if (trace.Active) trace.Log("BEFORE:\t" + ctx.ToString());
						ctx.SetResult(i, v);
						if (trace.Active) trace.Log("AFTER: \t" + ctx.ToString());
					}
				}
			}
		}
	}
}