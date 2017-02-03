using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tras.Core.Domain.Common;

namespace Tras.Web.Framework.ViewModelAttributes
{
    public class EditorViewAttribute : Attribute, IMetadataAware
    {
        public AppConstant.InputWidthType WidthType { get; set; }

        public EditorViewAttribute()
        {
            
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["input-size"] = WidthType == AppConstant.InputWidthType.Large
                ? 12
                : WidthType == AppConstant.InputWidthType.Medium ? 6 : 4;
        }
    }
}
