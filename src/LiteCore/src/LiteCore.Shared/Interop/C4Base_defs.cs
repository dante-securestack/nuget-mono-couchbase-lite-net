//
// C4Base_defs.cs
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


    internal unsafe struct C4ExtraInfo
    {
        public void* pointer;
        private IntPtr _destructor;

        public C4ExtraInfoDestructor? destructor
        {
            get => Marshal.GetDelegateForFunctionPointer<C4ExtraInfoDestructor>(_destructor);
            set => _destructor = value != null ? Marshal.GetFunctionPointerForDelegate(value) : IntPtr.Zero;
        }
    }
    

	internal unsafe partial struct C4BlobKey
    {
    }

	internal unsafe partial struct C4Address
    {
    }

	internal unsafe struct C4BlobStore
    {
    }

	internal unsafe struct C4Cert
    {
    }

	internal unsafe struct C4Collection
    {
    }

	internal unsafe struct C4CollectionObserver
    {
    }

	internal unsafe struct C4Database
    {
    }

	internal unsafe partial struct C4Document
    {
    }

	internal unsafe struct C4DocumentObserver
    {
    }

	internal unsafe struct C4DocEnumerator
    {
    }

	internal unsafe struct C4KeyPair
    {
    }

	internal unsafe struct C4Listener
    {
    }

	internal unsafe struct C4Query
    {
    }

	internal unsafe partial struct C4QueryEnumerator
    {
    }

	internal unsafe struct C4QueryObserver
    {
    }

	internal unsafe partial struct C4RawDocument
    {
    }

	internal unsafe struct C4ReadStream
    {
    }

	internal unsafe struct C4Replicator
    {
    }

	internal unsafe struct C4Socket
    {
    }

	internal unsafe partial struct C4SocketFactory
    {
    }

	internal unsafe struct C4WriteStream
    {
    }
}

#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore CS0649  // Member never assigned to
#pragma warning restore CS0169  // Member never used
