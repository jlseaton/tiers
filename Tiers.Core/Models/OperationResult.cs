using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    public class OperationResult
    {
        /// <summary>
        /// Caller of the operation
        /// </summary>
        public string Caller { get; set; }

        /// <summary>
        /// Method of the operation
        /// </summary>
        public string Method  { get; set; }

        /// <summary>
        /// Results of operation message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Delimiter between fields
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Last operation results in a delimited format
        /// </summary>
        public virtual string DelimitedSummary
        {
            get
            {
                StringBuilder summary = new StringBuilder();

                if (!String.IsNullOrEmpty(Caller))
                {
                    summary.Append(Caller);
                    summary.Append(Delimiter);
                }

                if (!String.IsNullOrEmpty(Method))
                {
                    summary.Append(Method);
                    summary.Append(Delimiter);
                }

                if (!String.IsNullOrEmpty(Message))
                {
                    summary.Append(Message);
                    summary.Append(Delimiter);
                }

                return summary.ToString();
            }
        }

        public OperationResult(Exception ex = null, string delimiter = ",")
        {
            Delimiter = delimiter;
            Caller = String.Empty;
            Method = String.Empty;
            Message = String.Empty;

            if (ex != null)
            {
                Message = ex.GetInnerMessages();
            }
        }
        
        public override string ToString()
        {
            return DelimitedSummary;
        }
    }
}
