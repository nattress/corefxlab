﻿//------------------------------------------------------------------------------
// <auto-generated>look at the SpanExtensionsTemplate.tt</auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace System
{
    public static partial class SpanExtensions
    {
        /// <summary>
        /// Determines whether two spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of bytes to compare to second.</param>
        /// <param name="second">A span of bytes T to compare to first.</param>
        public static bool SequenceEqual(this Span<byte> first, Span<byte> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

		/// <summary>
        /// Determines whether two read-only spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of bytes to compare to second.</param>
        /// <param name="second">A span of bytes T to compare to first.</param>
        public static bool SequenceEqual(this ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether two spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of characters to compare to second.</param>
        /// <param name="second">A span of characters T to compare to first.</param>
        public static bool SequenceEqual(this Span<char> first, Span<char> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

		/// <summary>
        /// Determines whether two read-only spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of characters to compare to second.</param>
        /// <param name="second">A span of characters T to compare to first.</param>
        public static bool SequenceEqual(this ReadOnlySpan<char> first, ReadOnlySpan<char> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether two spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of shorts to compare to second.</param>
        /// <param name="second">A span of shorts T to compare to first.</param>
        public static bool SequenceEqual(this Span<short> first, Span<short> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

		/// <summary>
        /// Determines whether two read-only spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of shorts to compare to second.</param>
        /// <param name="second">A span of shorts T to compare to first.</param>
        public static bool SequenceEqual(this ReadOnlySpan<short> first, ReadOnlySpan<short> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 512) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether two spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of integers to compare to second.</param>
        /// <param name="second">A span of integers T to compare to first.</param>
        public static bool SequenceEqual(this Span<int> first, Span<int> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 256) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

		/// <summary>
        /// Determines whether two read-only spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of integers to compare to second.</param>
        /// <param name="second">A span of integers T to compare to first.</param>
        public static bool SequenceEqual(this ReadOnlySpan<int> first, ReadOnlySpan<int> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 256) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether two spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of long integers to compare to second.</param>
        /// <param name="second">A span of long integers T to compare to first.</param>
        public static bool SequenceEqual(this Span<long> first, Span<long> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 256) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

		/// <summary>
        /// Determines whether two read-only spans are equal (byte-wise) by comparing the elements by using memcmp
        /// </summary>
        /// <param name="first">A span of long integers to compare to second.</param>
        /// <param name="second">A span of long integers T to compare to first.</param>
        public static bool SequenceEqual(this ReadOnlySpan<long> first, ReadOnlySpan<long> second)
        {
            if (first.Length != second.Length) { return false; }

            // pinvoke calls are expensive (mostly due to memory pinning) so we call memcmp only for big slices
            if (first.Length >= 256) { return MemoryUtils.MemCmp(first, second); }

            // for small slices we just use simple loop
            for (int i = 0; i < first.Length; i++) {
                if (first.GetItemWithoutBoundariesCheck(i) != second.GetItemWithoutBoundariesCheck(i)) { 
                    return false; 
                }
            }
            return true;
        }

    }
}
