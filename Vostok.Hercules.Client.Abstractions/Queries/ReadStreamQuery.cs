﻿using System;
using JetBrains.Annotations;
using Vostok.Hercules.Client.Abstractions.Models;
using Vostok.Hercules.Client.Abstractions.Results;

namespace Vostok.Hercules.Client.Abstractions.Queries
{
    [PublicAPI]
    public class ReadStreamQuery
    {
        public ReadStreamQuery([NotNull] string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Name of the stream to read from.
        /// </summary>
        [NotNull]
        public string Name { get; set; }

        /// <summary>
        /// Limit on how many events this query may return.
        /// </summary>
        public int Limit { get; set; } = 10 * 1000;

        /// <summary>
        /// <para>Zero-based index of the client-side virtual shard.</para>
        /// <para>These shards are mapped into actual physical shards by Hercules.</para>
        /// </summary>
        public int ClientShard { get; set; }

        /// <summary>
        /// <para>Count of client-side virtual shards.</para>
        /// <para>These shards are mapped into actual physical shards by Hercules.</para>
        /// </summary>
        public int ClientShardCount { get; set; } = 1;

        /// <summary>
        /// <para>Starting coordinates in the stream.</para>
        /// <para><see cref="StreamCoordinates.Empty"/> by default (start from the beginning)</para>
        /// <para>Use this state to resume a previous read by passing a value obtained from <see cref="HerculesStreamReadResult"/>.</para>
        /// </summary>
        public StreamCoordinates Coordinates { get; set; } = StreamCoordinates.Empty;
    }
}
