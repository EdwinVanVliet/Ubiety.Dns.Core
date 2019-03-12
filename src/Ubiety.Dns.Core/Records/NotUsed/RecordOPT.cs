/*
 * Licensed under the MIT license
 * See the LICENSE file in the project root for more information
 */

namespace Ubiety.Dns.Core.Records.NotUsed
{
    /// <summary>
    ///     OPT DNS record.
    /// </summary>
    public class RecordOpt : Record
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordOpt" /> class.
        /// </summary>
        /// <param name="rr"><see cref="RecordReader" /> for the record data.</param>
        public RecordOpt(RecordReader rr)
            : base(rr)
        {
        }
    }
}