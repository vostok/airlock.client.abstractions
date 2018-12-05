﻿using System;
using JetBrains.Annotations;
using Vostok.Hercules.Client.Abstractions.Events;

namespace Vostok.Hercules.Client.Abstractions.Values
{
    public abstract partial class HerculesValue
    {
        /// <summary>
        /// Returns the value cast to <see cref="byte"/>. Requires the value to have <see cref="HerculesValueType.Byte"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public byte AsByte => As<byte>();

        /// <summary>
        /// Returns the value cast to <see cref="short"/>. Requires the value to have <see cref="HerculesValueType.Short"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public short AsShort => As<short>();

        /// <summary>
        /// Returns the value cast to <see cref="int"/>. Requires the value to have <see cref="HerculesValueType.Int"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public int AsInt => As<int>();

        /// <summary>
        /// Returns the value cast to <see cref="long"/>. Requires the value to have <see cref="HerculesValueType.Long"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public long AsLong => As<long>();

        /// <summary>
        /// Returns the value cast to <see cref="bool"/>. Requires the value to have <see cref="HerculesValueType.Bool"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public bool AsBool => As<bool>();

        /// <summary>
        /// Returns the value cast to <see cref="float"/>. Requires the value to have <see cref="HerculesValueType.Float"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public float AsFloat => As<float>();

        /// <summary>
        /// Returns the value cast to <see cref="double"/>. Requires the value to have <see cref="HerculesValueType.Double"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public double AsDouble => As<double>();

        /// <summary>
        /// Returns the value cast to <see cref="Guid"/>. Requires the value to have <see cref="HerculesValueType.Guid"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        public Guid AsGuid => As<Guid>();

        /// <summary>
        /// Returns the value cast to <see cref="string"/>. Requires the value to have <see cref="HerculesValueType.String"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        [NotNull]
        public string AsString => As<string>();

        /// <summary>
        /// Returns the value cast to a vector of arbitrary <see cref="HerculesValue"/>s. Requires the value to have <see cref="HerculesValueType.Vector"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        [NotNull]
        public HerculesVector AsVector => As<HerculesVector>();

        /// <summary>
        /// Returns the value cast to a container of arbitrary tags (<see cref="HerculesTags"/>). Requires the value to have <see cref="HerculesValueType.Container"/> type.
        /// <exception cref="InvalidCastException">The cast is not valid due to mismatching value type.</exception>
        /// </summary>
        [NotNull]
        public HerculesTags AsContainer => As<HerculesTags>();

        private TValue As<TValue>()
        {
            if (this is HerculesValue<TValue> typedValue)
                return typedValue.TypedValue;
            
            throw new InvalidCastException($"Elements of vector cannot be cast to '{nameof(TValue)}' due to being of type '{Type}'.");
        }
    }
}