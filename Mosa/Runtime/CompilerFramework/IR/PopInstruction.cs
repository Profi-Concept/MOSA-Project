﻿/*
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

namespace Mosa.Runtime.CompilerFramework.IR
{
    /// <summary>
    /// Intermediate representation of a pop operation, that removes the topmost element from the stack and
    /// places it in the destination operand.
    /// </summary>
    public class PopInstruction : Instruction
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PopInstruction"/>.
        /// </summary>
        public PopInstruction() :
            base(0, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PopInstruction"/>.
        /// </summary>
        /// <param name="destination">The destination operand to fill with the topmost element of the stack.</param>
        public PopInstruction(Operand destination) :
            base(0, 1)
        {
            SetResult(0, destination);
        }

        #endregion // Construction

        #region Properties

        /// <summary>
        /// Gets or sets the destination of the pop operation.
        /// </summary>
        public Operand Destination
        {
            get { return this.Results[0]; }
            set { SetResult(0, value); }
        }

        #endregion // Properties

        #region Instruction

        /// <summary>
        /// Returns a string representation of the <see cref="PopInstruction"/>.
        /// </summary>
        /// <returns>A string representation of the instruction.</returns>
        public override string ToString()
        {
            return String.Format(@"IR pop {0}", this.Destination);
        }

        /// <summary>
        /// Implementation of the visitor pattern.
        /// </summary>
        /// <param name="visitor">The visitor requesting visitation. The object must implement <see cref="IIrVisitor"/>.</param>
        public override void Visit(IInstructionVisitor visitor)
        {
            IIrVisitor irv = visitor as IIrVisitor;
            if (null == irv)
                throw new ArgumentException(@"Must implement IIrVisitor.", @"visitor");

            irv.Visit(this);
        }

        #endregion // Instruction
    }
}
