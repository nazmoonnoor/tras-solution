using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;

namespace Tras.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        [DefaultValue("true")]
        public Active? Active { get; set; }
        [DefaultValue("false")]
        public bool? Deleted { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int? LastUpdatedUserId { get; set; }

    }
}
