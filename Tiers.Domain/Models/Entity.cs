using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiers.Core;

namespace Tiers.Domain.Models
{
    public abstract class Entity
    {
        /// <summary>
        /// Results of the last operation
        /// </summary>
        public virtual OperationResult LastResult { get; protected set; }
    }
}
