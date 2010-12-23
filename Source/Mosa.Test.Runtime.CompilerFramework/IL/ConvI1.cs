﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Alex Lyman <mail.alex.lyman@gmail.com>
 *  Simon Wollwage (rootnode) <kintaro@think-in-co.de>
 *  Michael Fröhlich (grover) <michael.ruck@michaelruck.de>
 *  
 */

using System;
using System.Collections.Generic;
using System.Text;
using MbUnit.Framework;
using System.Reflection.Emit;

namespace Mosa.Test.Runtime.CompilerFramework.IL
{
	[TestFixture]
	public class ConvI1 : TestCompilerAdapter
	{
		
		[Column(0, 1, 2, sbyte.MinValue, sbyte.MaxValue)]
		[Test]
		public void ConvI1_I1(sbyte a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_I1(sbyte expect, sbyte a) 
					{ 
						return expect == (sbyte)a; 
					} 
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_I1", a, a));
		}

		[Column(0, 1, 2, sbyte.MinValue, sbyte.MaxValue, short.MinValue, short.MaxValue)]
		[Test]
		public void ConvI1_I2(short a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_I2(sbyte expect, short a) 
					{ 
						return expect == (sbyte)a; 
					}
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_I2", ((sbyte)a), a));
		}

		[Column(/*0, 1, 2, sbyte.MinValue, sbyte.MaxValue, */int.MinValue, int.MaxValue)]
		[Test]
		public void ConvI1_I4(int a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_I4(sbyte expect, int a) 
					{ 
						return expect == (sbyte)a; 
					} 
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_I4", ((sbyte)a), a));
		}

		[Column(0, 1, 2, sbyte.MinValue, sbyte.MaxValue, long.MinValue, long.MaxValue)]
		[Test]
		public void ConvI1_I8(long a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_I8(sbyte expect, long a) 
					{ 
						return expect == (sbyte)a; 
					} 
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_I8", ((sbyte)a), a));
		}

		[Column(0.0f, 1.0f, 2.0f, (float)sbyte.MinValue, (float)sbyte.MaxValue, Single.MinValue, Single.MaxValue)]
		[Test]
		public void ConvI1_R4(float a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_R4(sbyte expect, float a) 
					{ 
						return expect == (sbyte)a; 
					} 
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_R4", ((sbyte)a), a));
		}

		[Column(0, 1, 2, (double)sbyte.MinValue, (double)sbyte.MaxValue, Double.MinValue, Double.MaxValue)]
		[Test]
		public void ConvI1_R8(double a)
		{
			compiler.CodeSource = @"
				static class Test { 
					static bool ConvI1_R8(sbyte expect, double a) 
					{ 
						return expect == (sbyte)a;
					} 
				}" + Code.AllTestCode;
			Assert.IsTrue(compiler.Run<bool>(string.Empty, "Test", "ConvI1_R8", ((sbyte)a), a));
		}
	}
}
