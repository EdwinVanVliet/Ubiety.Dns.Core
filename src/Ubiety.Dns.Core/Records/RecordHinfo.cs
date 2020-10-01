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

/*
 3.3.2. HINFO RDATA format

    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /                      CPU                      /
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /                       OS                      /
    +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

where:

CPU             A <character-string> which specifies the CPU type.

OS              A <character-string> which specifies the operating
                system type.

Standard values for CPU and OS can be found in [RFC-1010].

HINFO records are used to acquire general information about a host.  The
main use is for protocols such as FTP that can use special procedures
when talking between machines or operating systems of the same type.
 */

namespace Ubiety.Dns.Core.Records
{
    /// <summary>
    ///     Hardware info DNS record.
    /// </summary>
    public class RecordHinfo : Record
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordHinfo" /> class.
        /// </summary>
        /// <param name="reader"><see cref="RecordReader" /> for the record data.</param>
        public RecordHinfo(RecordReader reader)
            : base(reader)
        {
            Cpu = Reader.ReadString();
            Os = Reader.ReadString();
        }

        /// <summary>
        ///     Gets the CPU.
        /// </summary>
        public string Cpu { get; }

        /// <summary>
        ///     Gets the OS.
        /// </summary>
        public string Os { get; }

        /// <summary>
        ///     String representation of the record data.
        /// </summary>
        /// <returns>String version of the record.</returns>
        public override string ToString()
        {
            return $"CPU={Cpu} OS={Os}";
        }
    }
}
