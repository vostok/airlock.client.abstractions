﻿using System;
using System.Threading;
using JetBrains.Annotations;
using Vostok.Hercules.Client.Abstractions.Queries;
using Vostok.Hercules.Client.Abstractions.Results;

namespace Vostok.Hercules.Client.Abstractions
{
    [PublicAPI]
    public static class HerculesStreamClientExtensions
    {
        [NotNull]
        public static ReadStreamResult Read(
            [NotNull] this IHerculesStreamClient client,
            [NotNull] ReadStreamQuery query,
            TimeSpan timeout,
            CancellationToken cancellationToken = default) =>
            client.ReadAsync(query, timeout, cancellationToken).GetAwaiter().GetResult();
    }
}