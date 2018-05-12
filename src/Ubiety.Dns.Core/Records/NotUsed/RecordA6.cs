using System;

namespace Ubiety.Dns.Core.Records.NotUsed
{
    /// <summary>
    ///     Historic IPv6 record lookup
    /// </summary>
    public class RecordA6 : Record
    {
        /// <summary>
        ///     Gets or sets the record data
        /// </summary>
        public byte[] RecordData { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordA6" /> class
        /// </summary>
        /// <param name="rr"><see cref="RecordReader" /> to read the record data</param>
        public RecordA6(RecordReader rr)
        {
            // re-read length
            ushort length = rr.ReadUInt16(-2);
            this.RecordData = rr.ReadBytes(length);
        }

        /// <summary>
        ///     String representation of the record
        /// </summary>
        /// <returns>String version of the record data</returns>
        public override string ToString()
        {
            return "not-used";
        }
    }
}
