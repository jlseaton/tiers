using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    /// <summary>
    /// Provides data to a search request operation
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// User who called the operation
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Query criteria used in the search
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Sort order used in the search
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Sort order direction (ASC=ascending or DESC=decsending)
        /// </summary>
        public string SortDir { get; set; }

        /// <summary>
        /// Page number to start displaying rows from
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Total number of rows per page
        /// </summary>
        public int PageSize { get; set; }
    }
}
