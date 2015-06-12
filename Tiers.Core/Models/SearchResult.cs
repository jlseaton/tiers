using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    public class SearchResult : OperationResult
    {
        /// <summary>
        /// User who called the operation
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Query criteria used in the operation
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Sort order used in the operation
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Sort order descending instead of ascending
        /// </summary>
        public string SortDir { get; set; }

        /// <summary>
        /// Total number of rows per page
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Total number of rows per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total number of rows found
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Execution time of operation
        /// </summary>
        public TimeSpan Elapsed { get; set; }

        private string summary = String.Empty;
        /// <summary>
        /// Number of results and search execution time
        /// </summary>
        public string Summary
        {
            get
            {
                if (RowCount <= 0)
                {
                    summary = "No results found";
                }
                else
                {
                    if (String.IsNullOrEmpty(summary))
                    {
                        summary = String.Format("{0} found in ({1}.{2}) seconds",
                            RowCount.ToString(), 
                            Elapsed.Seconds.ToString(), 
                            Elapsed.Milliseconds.ToString());
                    }
                }
#if DEBUG
                if (!String.IsNullOrEmpty(Message))
                {
                    summary += " - " + Message;
                }
#endif
                return summary;
            }
            set
            {
                summary = value;
            }
        }

        /// <summary>
        /// Last operation results in a delimited format
        /// </summary>
        public override string DelimitedSummary
        {
            get
            {
                StringBuilder summary = 
                    new StringBuilder(base.DelimitedSummary);
                
                summary.Append("user=" + (String.IsNullOrEmpty(Query) 
                    ? String.Empty : User));
                summary.Append(Delimiter);
                summary.Append("query=" + (String.IsNullOrEmpty(Query) 
                    ? String.Empty : Query));
                summary.Append(Delimiter);
                summary.Append("sortorder=" + (String.IsNullOrEmpty(SortOrder) 
                    ? String.Empty : SortOrder));
                summary.Append(Delimiter);
                summary.Append("sortdescending=" + SortDir.ToString());
                summary.Append(Delimiter);
                summary.Append("pagenumber=" + PageNumber.ToString());
                summary.Append(Delimiter);
                summary.Append("pagesize=" + PageSize.ToString());
                summary.Append(Delimiter);
                summary.Append("rowcount=" + RowCount.ToString());
                summary.Append(Delimiter);
                summary.Append(Summary);
                
                if (!String.IsNullOrEmpty(Message))
                {
                    summary.Append(Delimiter);
                    summary.Append(Message);
                }

                return summary.ToString();
            }
        }

        /// <summary>
        /// Provides result information about a search query
        /// </summary>
        /// <param name="delimiter"></param>
        public SearchResult(string delimiter = ",")
            : base(null, delimiter)
        {
            Query = String.Empty;
            SortOrder = String.Empty;
            SortDir = "ASC";
        }
        
        public override string ToString()
        {
            return DelimitedSummary;
        }
    }
}
