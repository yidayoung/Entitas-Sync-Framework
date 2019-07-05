﻿/*
 *  Copyright (c) 2018 Stanislav Denisov
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using System;
using System.Runtime.CompilerServices;

#if !(ENABLE_MONO || ENABLE_IL2CPP)
	using System.Numerics;
#else
	using UnityEngine;
#endif

namespace NetStack.Compression {
	public struct CompressedVector2 {
		public uint x;
		public uint y;

		public CompressedVector2(uint x, uint y) {
			this.x = x;
			this.y = y;
		}
	}

	public struct CompressedVector3 {
		public uint x;
		public uint y;
		public uint z;

		public CompressedVector3(uint x, uint y, uint z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}

	public struct CompressedVector4 {
		public uint x;
		public uint y;
		public uint z;
		public uint w;

		public CompressedVector4(uint x, uint y, uint z, uint w) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
	}

	public static class DeBruijn {
		public static readonly int[] Lookup = new int[32] {
			0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
			8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
		};
	}

	public class BoundedRange {
		private readonly float minValue;
		private readonly float maxValue;
		private readonly float precision;
		private readonly int requiredBits;
		private readonly uint mask;

		public BoundedRange(float minValue, float maxValue, float precision) {
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.precision = precision;

			requiredBits = Log2((uint)((maxValue - minValue) * (1.0f / precision) + 0.5f)) + 1;
			mask = (uint)((1L << requiredBits) - 1);
		}

		private int Log2(uint value) {
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;

			return DeBruijn.Lookup[(value * 0x07C4ACDDU) >> 27];
		}

		#if NETSTACK_INLINING
			[MethodImpl(256)]
		#endif
		public uint Compress(float value) {
			if (value < minValue)
				value = minValue;
			else if (value > maxValue)
				value = maxValue;

			return (uint)((float)((value - minValue) * (1f / precision)) + 0.5f) & mask;
		}

		#if NETSTACK_INLINING
			[MethodImpl(256)]
		#endif
		public float Decompress(uint data) {
			float adjusted = ((float)data * precision) + minValue;

			if (adjusted < minValue)
				adjusted = minValue;
			else if (adjusted > maxValue)
				adjusted = maxValue;

			return adjusted;
		}

		public static CompressedVector2 Compress(Vector2 vector2, BoundedRange[] boundedRange) {
			CompressedVector2 data = default(CompressedVector2);

			#if ENABLE_MONO || ENABLE_IL2CPP
				data.x = boundedRange[0].Compress(vector2.x);
				data.y = boundedRange[1].Compress(vector2.y);
			#else
				data.x = boundedRange[0].Compress(vector2.X);
				data.y = boundedRange[1].Compress(vector2.Y);
			#endif

			return data;
		}

		public static CompressedVector3 Compress(Vector3 vector3, BoundedRange[] boundedRange) {
			CompressedVector3 data = default(CompressedVector3);

			#if ENABLE_MONO || ENABLE_IL2CPP
				data.x = boundedRange[0].Compress(vector3.x);
				data.y = boundedRange[1].Compress(vector3.y);
				data.z = boundedRange[2].Compress(vector3.z);
			#else
				data.x = boundedRange[0].Compress(vector3.X);
				data.y = boundedRange[1].Compress(vector3.Y);
				data.z = boundedRange[2].Compress(vector3.Z);
			#endif

			return data;
		}

		public static CompressedVector4 Compress(Vector4 vector4, BoundedRange[] boundedRange) {
			CompressedVector4 data = default(CompressedVector4);

			#if ENABLE_MONO || ENABLE_IL2CPP
				data.x = boundedRange[0].Compress(vector4.x);
				data.y = boundedRange[1].Compress(vector4.y);
				data.z = boundedRange[2].Compress(vector4.z);
				data.w = boundedRange[3].Compress(vector4.w);
			#else
				data.x = boundedRange[0].Compress(vector4.X);
				data.y = boundedRange[1].Compress(vector4.Y);
				data.z = boundedRange[2].Compress(vector4.Z);
				data.w = boundedRange[3].Compress(vector4.W);
			#endif

			return data;
		}

		public static Vector2 Decompress(CompressedVector2 data, BoundedRange[] boundedRange) {
			return new Vector2(boundedRange[0].Decompress(data.x), boundedRange[1].Decompress(data.y));
		}

		public static Vector3 Decompress(CompressedVector3 data, BoundedRange[] boundedRange) {
			return new Vector3(boundedRange[0].Decompress(data.x), boundedRange[1].Decompress(data.y), boundedRange[2].Decompress(data.z));
		}

		public static Vector4 Decompress(CompressedVector4 data, BoundedRange[] boundedRange) {
			return new Vector4(boundedRange[0].Decompress(data.x), boundedRange[1].Decompress(data.y), boundedRange[2].Decompress(data.z), boundedRange[3].Decompress(data.w));
		}
	}
}