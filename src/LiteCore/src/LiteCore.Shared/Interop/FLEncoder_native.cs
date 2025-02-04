//
// FLEncoder_native.cs
//
// Copyright (c) 2023 Couchbase, Inc All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Runtime.InteropServices;

using LiteCore.Util;

namespace LiteCore.Interop
{

    internal unsafe static partial class Native
    {
        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FLEncoder* FLEncoder_New();

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FLEncoder_Free(FLEncoder* encoder);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FLEncoder_SetExtraInfo(FLEncoder* encoder, void* info);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* FLEncoder_GetExtraInfo(FLEncoder* encoder);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FLEncoder_Reset(FLEncoder* encoder);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteNull(FLEncoder* encoder);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteBool(FLEncoder* encoder, [MarshalAs(UnmanagedType.U1)]bool b);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteInt(FLEncoder* encoder, long l);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteUInt(FLEncoder* encoder, ulong u);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteFloat(FLEncoder* encoder, float f);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteDouble(FLEncoder* encoder, double d);

        public static bool FLEncoder_WriteString(FLEncoder* encoder, string? str)
        {
            using(var str_ = new C4String(str)) {
                return NativeRaw.FLEncoder_WriteString(encoder, (FLSlice)str_.AsFLSlice());
            }
        }

        public static bool FLEncoder_WriteData(FLEncoder* encoder, byte[]? slice)
        {
            fixed(byte *slice_ = slice) {
                return NativeRaw.FLEncoder_WriteData(encoder, new FLSlice(slice_, slice == null ? 0 : (ulong)slice.Length));
            }
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteValue(FLEncoder* encoder, FLValue* value);

        public static bool FLEncoder_BeginArray(FLEncoder* encoder, ulong reserveCount)
        {
            return NativeRaw.FLEncoder_BeginArray(encoder, (UIntPtr)reserveCount);
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_EndArray(FLEncoder* encoder);

        public static bool FLEncoder_BeginDict(FLEncoder* encoder, ulong reserveCount)
        {
            return NativeRaw.FLEncoder_BeginDict(encoder, (UIntPtr)reserveCount);
        }

        public static bool FLEncoder_WriteKey(FLEncoder* encoder, string? str)
        {
            using(var str_ = new C4String(str)) {
                return NativeRaw.FLEncoder_WriteKey(encoder, (FLSlice)str_.AsFLSlice());
            }
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_EndDict(FLEncoder* encoder);

        public static byte[]? FLEncoder_Finish(FLEncoder* encoder, FLError* outError)
        {
            using(var retVal = NativeRaw.FLEncoder_Finish(encoder, outError)) {
                return ((FLSlice)retVal).ToArrayFast();
            }
        }


    }

    internal unsafe static partial class NativeRaw
    {
        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteString(FLEncoder* encoder, FLSlice str);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteData(FLEncoder* encoder, FLSlice slice);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_BeginArray(FLEncoder* encoder, UIntPtr reserveCount);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_BeginDict(FLEncoder* encoder, UIntPtr reserveCount);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool FLEncoder_WriteKey(FLEncoder* encoder, FLSlice str);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FLSliceResult FLEncoder_Finish(FLEncoder* encoder, FLError* outError);


    }
}
