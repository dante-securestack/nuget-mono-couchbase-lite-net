//
// Copyright (c) 2023-present Couchbase, Inc All rights reserved.
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

// THIS IS AN AUTOGENERATED FILE, MANUAL CHANGES SHOULD BE EXPECTED TO
// BE OVERWRITTEN

using Couchbase.Lite.Sync;
using Couchbase.Lite.Query;
using Couchbase.Lite.Logging;
#if COUCHBASE_ENTERPRISE
using Couchbase.Lite.P2P;
#endif

using System;

namespace Couchbase.Lite.Info {
	public static class Constants {

		/// <summary>
		/// Default value for <see cref="LogFileConfiguration.UsePlainText" /> (false)
		/// Plaintext is not used, and instead binary encoding is used in log files
		/// </summary>
		public static readonly bool DefaultLogFileUsePlainText = false;

		/// <summary>
		/// Default value for <see cref="LogFileConfiguration.MaxSize" /> (524288)
		/// 512 KiB for the size of a log file
		/// </summary>
		public static readonly long DefaultLogFileMaxSize = 524288;

		/// <summary>
		/// Default value for <see cref="LogFileConfiguration.MaxRotateCount" /> (1)
		/// 1 rotated file present (2 total, including the currently active log file)
		/// </summary>
		public static readonly int DefaultLogFileMaxRotateCount = 1;

		/// <summary>
		/// Default value for <see cref="FullTextIndexConfiguration.IgnoreAccents" /> (false)
		/// Accents and ligatures are not ignored when indexing via full text search
		/// </summary>
		public static readonly bool DefaultFullTextIndexIgnoreAccents = false;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.Type" /> (ReplicatorType.PushAndPull)
		/// Perform bidirectional replication
		/// </summary>
		public static readonly ReplicatorType DefaultReplicatorType = ReplicatorType.PushAndPull;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.Continuous" /> (false)
		/// One-shot replication is used, and will stop once all initial changes are processed
		/// </summary>
		public static readonly bool DefaultReplicatorContinuous = false;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.Heartbeat" /> (TimeSpan.FromSeconds(300))
		/// A heartbeat messages is sent every 300 seconds to keep the connection alive
		/// </summary>
		public static readonly TimeSpan DefaultReplicatorHeartbeat = TimeSpan.FromSeconds(300);

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.MaxAttempts" /> (10)
		/// When replicator is not continuous, after 10 failed attempts give up on the replication
		/// </summary>
		public static readonly int DefaultReplicatorMaxAttemptsSingleShot = 10;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.MaxAttempts" /> (-1)
		/// When replicator is continuous, never give up unless explicitly stopped
		/// </summary>
		public static readonly int DefaultReplicatorMaxAttemptsContinuous = -1;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.MaxAttemptWaitTime" /> (TimeSpan.FromSeconds(300))
		/// Max wait time between retry attempts in seconds
		/// </summary>
		public static readonly TimeSpan DefaultReplicatorMaxAttemptWaitTime = TimeSpan.FromSeconds(300);

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.EnableAutoPurge" /> (true)
		/// Purge documents when a user loses access
		/// </summary>
		public static readonly bool DefaultReplicatorEnableAutoPurge = true;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.SelfSignedCertificateOnly" /> (false)
		/// Whether or not a replicator only accepts self-signed certificates from the remote
		/// </summary>
		public static readonly bool DefaultReplicatorSelfSignedCertificateOnly = false;

		/// <summary>
		/// Default value for <see cref="ReplicatorConfiguration.AllowParentDomainCookies" /> (false)
		/// Whether or not a replicator only accepts cookies for the sender's parent domains
		/// </summary>
		public static readonly bool DefaultReplicatorAcceptParentCookies = false;

#if COUCHBASE_ENTERPRISE

		/// <summary>
		/// Default value for <see cref="URLEndpointListenerConfiguration.Port" /> (0)
		/// No port specified, the OS will assign one
		/// </summary>
		public static readonly ushort DefaultListenerPort = 0;

		/// <summary>
		/// Default value for <see cref="URLEndpointListenerConfiguration.DisableTLS" /> (false)
		/// TLS is enabled on the connection
		/// </summary>
		public static readonly bool DefaultListenerDisableTls = false;

		/// <summary>
		/// Default value for <see cref="URLEndpointListenerConfiguration.ReadOnly" /> (false)
		/// The listener will allow database writes
		/// </summary>
		public static readonly bool DefaultListenerReadOnly = false;

		/// <summary>
		/// Default value for <see cref="URLEndpointListenerConfiguration.EnableDeltaSync" /> (false)
		/// Delta sync is disabled for the listener
		/// </summary>
		public static readonly bool DefaultListenerEnableDeltaSync = false;

#endif
	}
}
