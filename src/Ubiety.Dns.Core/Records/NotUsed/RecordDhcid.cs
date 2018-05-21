namespace Ubiety.Dns.Core.Records.NotUsed
{
    /// <summary>
    ///     DCHP information resource record
    /// </summary>
    public class RecordDhcid : Record
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordDhcid" /> class
        /// </summary>
        /// <param name="rr"><see cref="RecordReader" /> for the record data</param>
        public RecordDhcid(RecordReader rr)
            : base(rr)
        {
        }
    }
}