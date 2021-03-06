/*
 * [The "BSD licence"]
 * Copyright (c) 2005-2008 Terence Parr
 * All rights reserved.
 *
 * Conversion to C#:
 * Copyright (c) 2008 Sam Harwell, Pixel Mine, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. The name of the author may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
//#if DEBUG
//using System.Linq;
//#endif

using IDictionary = System.Collections.IDictionary;

namespace Antlr.Runtime.JavaExtensions {
    public static class DictionaryExtensions {
#if DEBUG
        [Obsolete]
        public static bool containsKey(IDictionary map, object key) {
            return map.Contains(key);
        }

        [Obsolete]
        public static object get(IDictionary map, object key) {
            return map[key];
        }
#endif

        public static TValue get<TKey, TValue>(IDictionary<TKey, TValue> map, TKey key) {
            TValue value;
            if (map.TryGetValue(key, out value))
                return value;

            if (typeof(TValue).IsValueType)
                throw new KeyNotFoundException();

            return default(TValue);
        }

        // disambiguates
        public static TValue get<TKey, TValue>(Dictionary<TKey, TValue> map, TKey key) {
            TValue value;
            if (map.TryGetValue(key, out value))
                return value;

            if (typeof(TValue).IsValueType)
                throw new KeyNotFoundException();

            return default(TValue);
        }

        public static TValue get<TKey, TValue>(SortedList<TKey, TValue> map, TKey key) {
            TValue value;
            if (map.TryGetValue(key, out value))
                return value;

            if (typeof(TValue).IsValueType)
                throw new KeyNotFoundException();

            return default(TValue);
        }

#if DEBUG
        [Obsolete]
        public static void put(IDictionary map, object key, object value) {
            map[key] = value;
        }

        [Obsolete]
        public static void put<TKey, TValue>(IDictionary<TKey, TValue> map, TKey key, TValue value) {
            map[key] = value;
        }

        [Obsolete]
        public static void put<TKey, TValue>(Dictionary<TKey, TValue> map, TKey key, TValue value) {
            map[key] = value;
        }
#if FALSE
        [Obsolete]
        public static HashSet<object> keySet(IDictionary map) {
            return new HashSet<object>(map.Keys.Cast<object>());
        }

        [Obsolete]
        public static HashSet<TKey> keySet<TKey, TValue>(IDictionary<TKey, TValue> map) {
            return new HashSet<TKey>(map.Keys);
        }

        // disambiguates for Dictionary, which implements both IDictionary<T,K> and IDictionary
        [Obsolete]
        public static HashSet<TKey> keySet<TKey, TValue>(Dictionary<TKey, TValue> map) {
            return new HashSet<TKey>(map.Keys);
        }

        [Obsolete]
        public static HashSet<object> keySet<TKey, TValue>(SortedList<TKey, TValue> map) {
            return new HashSet<object>(map.Keys.Cast<object>());
        }
#endif
#endif
    }
}
