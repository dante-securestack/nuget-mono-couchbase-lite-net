//
// C4Database_native.cs
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
        public static C4Database* c4db_openNamed(string? name, C4DatabaseConfig2* config, C4Error* outError)
        {
            using(var name_ = new C4String(name)) {
                return NativeRaw.c4db_openNamed(name_.AsFLSlice(), config, outError);
            }
        }

        public static bool c4db_copyNamed(string? sourcePath, string? destinationName, C4DatabaseConfig2* config, C4Error* error)
        {
            using(var sourcePath_ = new C4String(sourcePath))
            using(var destinationName_ = new C4String(destinationName)) {
                return NativeRaw.c4db_copyNamed(sourcePath_.AsFLSlice(), destinationName_.AsFLSlice(), config, error);
            }
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_close(C4Database* database, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_delete(C4Database* database, C4Error* outError);

        public static bool c4db_deleteNamed(string? dbName, string? inDirectory, C4Error* outError)
        {
            using(var dbName_ = new C4String(dbName))
            using(var inDirectory_ = new C4String(inDirectory)) {
                return NativeRaw.c4db_deleteNamed(dbName_.AsFLSlice(), inDirectory_.AsFLSlice(), outError);
            }
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_rekey(C4Database* database, C4EncryptionKey* newKey, C4Error* outError);

        public static string? c4db_getPath(C4Database* db)
        {
            using(var retVal = NativeRaw.c4db_getPath(db)) {
                return ((FLSlice)retVal).CreateString();
            }
        }

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_getUUIDs(C4Database* database, C4UUID* publicUUID, C4UUID* privateUUID, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_maintenance(C4Database* database, C4MaintenanceType type, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_beginTransaction(C4Database* database, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_endTransaction(C4Database* database, [MarshalAs(UnmanagedType.U1)]bool commit, C4Error* outError);


    }

    internal unsafe static partial class NativeRaw
    {
        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern C4Database* c4db_openNamed(FLSlice name, C4DatabaseConfig2* config, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_copyNamed(FLSlice sourcePath, FLSlice destinationName, C4DatabaseConfig2* config, C4Error* error);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool c4db_deleteNamed(FLSlice dbName, FLSlice inDirectory, C4Error* outError);

        [DllImport(Constants.DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FLSliceResult c4db_getPath(C4Database* db);


    }
}
