using System;
using System.Web.Mvc;

namespace Tras.Web.Framework.ViewModelAttributes
{
    //http://stackoverflow.com/questions/5824124/html5-placeholders-with-net-mvc-3-razor-editorfor-extension/
    public class PlaceholderAttribute : Attribute, IMetadataAware
    {
        private readonly string _placeholder;
        public PlaceholderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }
}
