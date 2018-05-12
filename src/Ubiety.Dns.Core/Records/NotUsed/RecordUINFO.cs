using System;

namespace Ubiety.Dns.Core.Records.NotUsed
{
        /// <summary>
        /// </summary>
    public class RecordUINFO : Record
    {
        /// <summary>
        /// </summary>
        public byte[] RDATA { get; set; }

        /// <summary>
        /// </summary>
        public RecordUINFO(RecordReader rr)
        {
            // re-read length
            ushort RDLENGTH = rr.ReadUInt16(-2);
            RDATA = rr.ReadBytes(RDLENGTH);
        }

        /// <summary>
        /// </summary>
        public override string ToString()
        {
            return "not-used";
        }

    }
}