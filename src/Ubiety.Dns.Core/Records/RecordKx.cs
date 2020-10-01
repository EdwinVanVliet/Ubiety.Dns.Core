/*
 * Copyright 2020 Dieter Lunn
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Globalization;
using Ubiety.Dns.Core.Common.Extensions;

/*
 * http://tools.ietf.org/rfc/rfc2230.txt
 *
 * 3.1 KX RDATA format

   The KX DNS record has the following RDATA format:

    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    |                  PREFERENCE                   |
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /                   EXCHANGER                   /
    /                                               /
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

   where:

   PREFERENCE      A 16 bit non-negative integer which specifies the
                   preference given to this RR among other KX records
                   at the same owner.  Lower values are preferred.

   EXCHANGER       A <domain-name> which specifies a host willing to
                   act as a mail exchange for the owner name.

   KX records MUST cause type A additional section processing for the
   host specified by EXCHANGER.  In the event that the host processing
   the DNS transaction supports IPv6, KX records MUST also cause type
   AAAA additional section processing.

   The KX RDATA field MUST NOT be compressed.

 */

namespace Ubiety.Dns.Core.Records
{
    /// <summary>
    ///     Key exchange record.
    /// </summary>
    public sealed class RecordKx : Record, IComparable, IEquatable<RecordKx>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordKx" /> class.
        /// </summary>
        /// <param name="reader"><see cref="RecordReader" /> for the data.</param>
        public RecordKx(RecordReader reader)
            : base(reader)
        {
            Preference = Reader.ReadUInt16();
            Exchanger = Reader.ReadDomainName();
        }

        /// <summary>
        ///     Gets the preference.
        /// </summary>
        public ushort Preference { get; }

        /// <summary>
        ///     Gets the exchanger.
        /// </summary>
        public string Exchanger { get; }

        /// <summary>
        /// Is the left less than the right.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator <(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) < 0;
        }

        /// <summary>
        /// Is the left greater than the right.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator >(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) > 0;
        }

        /// <summary>
        /// Is the left less than or equal to the right.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator <=(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) <= 0;
        }

        /// <summary>
        /// Is the left greater than or equal to the right.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator >=(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) >= 0;
        }

        /// <summary>
        /// Do the objects equal each other.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator ==(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) == 0;
        }

        /// <summary>
        /// Do the objects not equal each other.
        /// </summary>
        /// <param name="x">Left comparison object.</param>
        /// <param name="y">Right comparison object.</param>
        public static bool operator !=(RecordKx x, RecordKx y)
        {
            return CompareTo(x.ThrowIfNull(nameof(x)), y) != 0;
        }

        /// <summary>
        ///     Compares instance to an object.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>Integer representing the comparison.</returns>
        public int CompareTo(object obj)
        {
            return CompareTo(this, (RecordKx)obj);
        }

        /// <summary>
        ///     Are two instances of <see cref="RecordKx" /> equal.
        /// </summary>
        /// <param name="other"><see cref="RecordKx" /> to compare to.</param>
        /// <returns>Boolean indicating whether the two instances are equal.</returns>
        public bool Equals(RecordKx other)
        {
            if (other == null)
            {
                return false;
            }

            return CompareTo(other) == 0;
        }

        /// <summary>
        ///     Overrides equals.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>Boolean indicating whether the instances are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return ReferenceEquals(this, obj) || Equals(obj as RecordKx);
        }

        /// <summary>
        ///     String representation of the record data.
        /// </summary>
        /// <returns>String version of the record.</returns>
        public override string ToString()
        {
            return $"{Preference} {Exchanger}";
        }

        /// <summary>
        ///     Gets the hash code.
        /// </summary>
        /// <returns>Integer value of the hash.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashcode = 13;
                hashcode = (hashcode * 397) ^ Preference;
                return hashcode;
            }
        }

        private static int CompareTo(RecordKx x, RecordKx y)
        {
            if (y == null)
            {
                return -1;
            }

            if (x.Preference > y.Preference)
            {
                return 1;
            }

            if (x.Preference < y.Preference)
            {
                return -1;
            }

            return string.Compare(x.Exchanger, y.Exchanger, true, CultureInfo.InvariantCulture);
        }
    }
}
