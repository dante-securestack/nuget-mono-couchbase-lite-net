//
// C4DocumentTypes_defs.cs
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

#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CS0649  // Member never assigned to
#pragma warning disable CS0169  // Member never used


using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

using LiteCore.Util;

namespace LiteCore.Interop
{
    [Flags]
    internal enum C4DocumentFlags : uint
    {
        DocDeleted        = 0x01,
        DocConflicted     = 0x02,
        DocHasAttachments = 0x04,
        DocExists         = 0x1000
    }

    [Flags]
    internal enum C4RevisionFlags : byte
    {
        Deleted        = 0x01,
        Leaf           = 0x02,
        New            = 0x04,
        HasAttachments = 0x08,
        KeepBody       = 0x10,
        IsConflict     = 0x20,
        Closed         = 0x40,
        Purged         = 0x80,
    }

    internal enum C4DocContentLevel : byte
    {
        DocGetMetadata,
        DocGetCurrentRev,
        DocGetAll,
    }

	internal unsafe struct C4Revision
    {
        public FLHeapSlice revID;
        public C4RevisionFlags flags;
        public ulong sequence;
    }

	internal unsafe partial struct C4DocPutRequest
    {
        public FLSlice body;
        public FLSlice docID;
        public C4RevisionFlags revFlags;
        private byte _existingRevision;
        private byte _allowConflict;
        public FLSlice* history;
        private UIntPtr _historyCount;
        private byte _save;
        public uint maxRevTreeDepth;
        public uint remoteDBID;
        public FLSliceResult allocedBody;
        private IntPtr _deltaCB;
        public void* deltaCBContext;
        public FLSlice deltaSourceRevID;

        public bool existingRevision
        {
            get {
                return Convert.ToBoolean(_existingRevision);
            }
            set {
                _existingRevision = Convert.ToByte(value);
            }
        }

        public bool allowConflict
        {
            get {
                return Convert.ToBoolean(_allowConflict);
            }
            set {
                _allowConflict = Convert.ToByte(value);
            }
        }

        public ulong historyCount
        {
            get {
                return _historyCount.ToUInt64();
            }
            set {
                _historyCount = (UIntPtr)value;
            }
        }

        public bool save
        {
            get {
                return Convert.ToBoolean(_save);
            }
            set {
                _save = Convert.ToByte(value);
            }
        }

        public C4DocDeltaApplier? deltaCB
        {
            get {
                return  Marshal.GetDelegateForFunctionPointer<C4DocDeltaApplier>(_deltaCB);
            }
            set {
                _deltaCB = value != null ? Marshal.GetFunctionPointerForDelegate(value) : IntPtr.Zero;
            }
        }
    }

	internal unsafe struct C4CollectionChange
    {
        public FLHeapSlice docID;
        public FLHeapSlice revID;
        public ulong sequence;
        public uint bodySize;
        public C4RevisionFlags flags;
    }

	internal unsafe struct C4CollectionObservation
    {
        public uint numChanges;
        private byte _external;
        public C4Collection* collection;

        public bool external
        {
            get {
                return Convert.ToBoolean(_external);
            }
            set {
                _external = Convert.ToByte(value);
            }
        }
    }
}

#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore CS0649  // Member never assigned to
#pragma warning restore CS0169  // Member never used
