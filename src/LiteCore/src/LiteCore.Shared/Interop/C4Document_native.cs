//
// C4Document_native.cs
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
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4doc_save(C4Document* doc, uint maxRevTreeDepth, C4Error* outError);

        public static byte[]? c4doc_getRevisionBody(C4Document* doc)
        {
            return (NativeRaw.c4doc_getRevisionBody(doc)).ToArrayFast();
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4doc_selectNextLeafRevision(C4Document* doc, [MarshalAs(UnmanagedType.U1)]bool includeDeleted, [MarshalAs(UnmanagedType.U1)]bool withBody, C4Error* outError);

        public static uint c4rev_getGeneration(string? revID)
        {
            using(var revID_ = new C4String(revID)) {
                return NativeRaw.c4rev_getGeneration(revID_.AsFLSlice());
            }
        }

        public static bool c4doc_resolveConflict(C4Document* doc, string? winningRevID, string? losingRevID, byte[]? mergedBody, C4RevisionFlags mergedFlags, C4Error* error)
        {
            using(var winningRevID_ = new C4String(winningRevID))
            using(var losingRevID_ = new C4String(losingRevID))
            fixed(byte *mergedBody_ = mergedBody) {
                return NativeRaw.c4doc_resolveConflict(doc, winningRevID_.AsFLSlice(), losingRevID_.AsFLSlice(), new FLSlice(mergedBody_, mergedBody == null ? 0 : (ulong)mergedBody.Length), mergedFlags, error);
            }
        }

        public static C4Document* c4doc_update(C4Document* doc, byte[]? revisionBody, C4RevisionFlags revisionFlags, C4Error* error)
        {
            fixed(byte *revisionBody_ = revisionBody) {
                return NativeRaw.c4doc_update(doc, new FLSlice(revisionBody_, revisionBody == null ? 0 : (ulong)revisionBody.Length), revisionFlags, error);
            }
        }


    }

    internal unsafe static partial class NativeRaw
    {
        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FLSlice c4doc_getRevisionBody(C4Document* doc);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint c4rev_getGeneration(FLSlice revID);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4doc_resolveConflict(C4Document* doc, FLSlice winningRevID, FLSlice losingRevID, FLSlice mergedBody, C4RevisionFlags mergedFlags, C4Error* error);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern C4Document* c4doc_update(C4Document* doc, FLSlice revisionBody, C4RevisionFlags revisionFlags, C4Error* error);


    }
}
