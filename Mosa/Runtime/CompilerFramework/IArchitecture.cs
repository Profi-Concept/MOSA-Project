/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (<mailto:sharpos@michaelruck.de>)
 */

using System;
using System.Collections.Generic;
using System.Text;

using Mosa.Runtime.CompilerFramework.Ir;
using Mosa.Runtime.Metadata;
using Mosa.Runtime.Metadata.Signatures;

namespace Mosa.Runtime.CompilerFramework
{
	
    /// <summary>
	/// Interface to allow compiler stages to perform architecture specific operations.
	/// </summary>
	/// <remarks>
    /// The functions in this interface are required to perform architecture specific
    /// optimizations in previous stages.
	/// </remarks>
	public interface IArchitecture
    {
        #region Properties

        /// <summary>
        /// Returns the type, which represents a native (unsigned) int on the VES stack.
        /// </summary>
        SigType NativeType { get; }

        /// <summary>
        /// Returns the entire register set of the architecture.
        /// </summary>
        /// <remarks>
        /// Returns an array of Register classes, which represent the register set of
        /// the target machine.
        /// </remarks>
        Register[] RegisterSet { get; }

        /// <summary>
        /// Returns the stack frame register of the architecture.
        /// </summary>
        Register StackFrameRegister { get; }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Retrieves an object, that is able to translate the CIL calling convention into appropriate native code.
        /// </summary>
        /// <param name="cc">The CIL calling convention to translate.</param>
        /// <returns>A calling convention implementation.</returns>
        ICallingConvention GetCallingConvention(CallingConvention cc);

        /// <summary>
        /// Requests the architecture to add architecture specific compilation stages to the assembly compiler 
        /// pipeline. These may depend upon the current state of the pipeline.
        /// </summary>
        /// <param name="assemblyPipeline">
        /// The pipeline of the assembly compiler to add architecture specific compilation stages to.
        /// </param>
        void ExtendAssemblyCompilerPipeline(CompilerPipeline<IAssemblyCompilerStage> assemblyPipeline);

        /// <summary>
        /// Requests the architecture to add architecture specific compilation stages to the pipeline. These
        /// may depend upon the current state of the pipeline.
		/// </summary>
        /// <param name="methodPipeline">
        /// The pipeline of the method compiler to add architecture specific compilation stages to.
        /// </param>
        void ExtendMethodCompilerPipeline(CompilerPipeline<IMethodCompilerStage> methodPipeline);

        /// <summary>
        /// Factory method for instruction object instances.
        /// </summary>
        /// <param name="instructionType">The type of the instruction to create.</param>
        /// <param name="args">Array of arguments to pass to the instruction type.</param>
        /// <returns>An instance of Instruction or a derived class to represent the requested opcode.</returns>
        Instruction CreateInstruction(Type instructionType, params object[] args);

        /// <summary>
        /// Factory method for result operands of instructions.
        /// </summary>
        /// <param name="instruction">The instruction to create a result operand for.</param>
        /// <param name="type">The datatype held in the result operand.</param>
        /// <returns>The operand, which holds the instruction result.</returns>
        Operand CreateResultOperand(Instruction instruction, SigType type);

        #endregion // Methods
    }
}
