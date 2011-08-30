﻿/*
 * (c) 2011 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Simon Wollwage (rootnode) <rootnode@mosa-project.org>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mosa.Runtime.CompilerFramework.Operands;
using Mosa.Runtime.CompilerFramework.IR;
using System.Diagnostics;

namespace Mosa.Runtime.CompilerFramework
{
	/// <summary>
	/// 
	/// </summary>
	public class EnterSSA : BaseMethodCompilerStage, IMethodCompilerStage, IPipelineStage
	{
		/// <summary>
		/// 
		/// </summary>
		private class AssignmentInformation
		{
			public List<BasicBlock> AssigningBlocks = new List<BasicBlock>();
			public Operand Operand;

			public AssignmentInformation(Operand operand)
			{
				this.Operand = operand;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private class VariableInformation
		{
			public int Count = 0;
			public Stack<int> Stack = new Stack<int>();
		}

		/// <summary>
		/// 
		/// </summary>
		private Dictionary<string, Operand> oldLefHandSide = new Dictionary<string,Operand>();
		/// <summary>
		/// 
		/// </summary>
		private Dictionary<string, VariableInformation> variableInformation = new Dictionary<string, VariableInformation>();
		/// <summary>
		/// 
		/// </summary>
		private IDominanceProvider dominanceCalculationStage;
		/// <summary>
		/// 
		/// </summary>
		private PhiPlacementStage phiPlacementStage;

		public void Run()
		{
			this.dominanceCalculationStage = this.methodCompiler.Pipeline.FindFirst<DominanceCalculationStage>() as IDominanceProvider;
			this.phiPlacementStage = this.methodCompiler.Pipeline.FindFirst<PhiPlacementStage>();

			var numberOfParameters = this.methodCompiler.Method.Parameters.Count;
			if (this.methodCompiler.Method.Signature.HasThis)
				++numberOfParameters;

			foreach (var name in this.phiPlacementStage.Assignments.Keys)
				this.variableInformation[name] = new VariableInformation();

			for (var i = 0; i < numberOfParameters; ++i)
			{
				var op = this.methodCompiler.GetParameterOperand(i);
				var name = NameForOperand(op);
				this.variableInformation[name].Stack.Push(0);
				this.variableInformation[name].Count = 1;
			}

			for (var i = 0; (this.methodCompiler as BaseMethodCompiler).LocalVariables != null && i < (this.methodCompiler as BaseMethodCompiler).LocalVariables.Length; ++i)
			{
				var op = (this.methodCompiler as BaseMethodCompiler).LocalVariables[i];
				var name = NameForOperand(op);
				if (!this.variableInformation.ContainsKey(name))
					this.variableInformation[name] = new VariableInformation();
				this.variableInformation[name].Stack.Push(0);
				this.variableInformation[name].Count = 1;
			}
			this.RenameVariables(this.FindBlock(-1).NextBlocks[0]);
			Debug.WriteLine("ESSA: " + this.methodCompiler.Method.FullName);
		}

		public string Name
		{
			get { return @"Enter Static Single Assignment Form"; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="block"></param>
		private void RenameVariables(BasicBlock block)
		{
			for (var context = new Context(this.instructionSet, block); !context.EndOfInstruction; context.GotoNext())
			{
				if (!(context.Instruction is PhiInstruction))
				{
					for (var i = 0; i < context.OperandCount; ++i)
					{
						var op = context.GetOperand(i);
						if (!(op is StackOperand))
							continue;
						var name = NameForOperand(context.GetOperand(i));
						if (!this.variableInformation.ContainsKey(name))
							throw new Exception(name + " is not in dictionary [block = " + block + "]");
						var index = this.variableInformation[name].Stack.Peek();
						context.SetOperand(i, new SsaOperand(context.GetOperand(i), index));
					}
				}

				if (PhiPlacementStage.IsAssignmentToStackVariable(context))
				{
					var name = NameForOperand(context.Result);
					var index = this.variableInformation[name].Count;
					context.SetResult(new SsaOperand(context.Result, index));
					this.variableInformation[name].Stack.Push(index);
					++this.variableInformation[name].Count;
				}
			}

			foreach (var s in block.NextBlocks)
			{
				var j = this.WhichPredecessor(s, block);
				for (var context = new Context(this.instructionSet, s); !context.EndOfInstruction; context.GotoNext())
				{
					if (!(context.Instruction is PhiInstruction))
						continue;
					var name = NameForOperand(context.GetOperand(j));
					if (this.variableInformation[name].Stack.Count > 0)
					{
						var index = this.variableInformation[name].Stack.Peek();
						context.SetOperand(j, new SsaOperand(context.GetOperand(j), index));
					}
				}
			}

			foreach (var s in this.dominanceCalculationStage.GetChildren(block))
			{
				this.RenameVariables(s);
			}

			for (var context = new Context(this.instructionSet, block); !context.EndOfInstruction; context.GotoNext())
			{
				if (PhiPlacementStage.IsAssignmentToStackVariable(context))
				{
					var instName = context.Label + "." + context.Index;
					var op = this.oldLefHandSide[instName];
					var name = NameForOperand(op);
					this.variableInformation[name].Stack.Pop();
				}
			}
		}

		private int WhichPredecessor(BasicBlock y, BasicBlock x)
		{
			for (var i = 0; i < y.PreviousBlocks.Count; ++i)
				if (y.PreviousBlocks[i].Sequence == x.Sequence)
					return i;
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private bool IsAssignment(Context context)
		{
			var op = context.Result;
			if (op == null)
				return false;

			return (op is StackOperand);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="operand"></param>
		/// <returns></returns>
		private string NameForOperand(Operand operand)
		{
			return PhiPlacementStage.NameForOperand(operand);
		}
	}
}
