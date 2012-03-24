﻿//
// TypeExtensions.cs
//
// Author:
//   Eric Maupin <me@ermau.com>
//
// Copyright (c) 2011 Eric Maupin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Reflection;

namespace Tempest
{
	public static class TypeExtensions
	{
		public static string GetSimplestName (this Type self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");
			if (self.Assembly == mscorlib || self.Assembly == Tempest)
				return self.FullName;
			if (!self.Assembly.GlobalAssemblyCache)
				return String.Format ("{0}, {1}", self.FullName, self.Assembly.GetName().Name);
			
			return self.AssemblyQualifiedName;
		}

		private static readonly Assembly Tempest = typeof (TypeExtensions).Assembly;
		private static readonly Assembly mscorlib = typeof (string).Assembly;
	}
}