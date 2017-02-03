namespace Tras.Core.Domain.Configuration
{
    public partial class Lookup : BaseEntity
    {
        public int LookupId { get; set; }
        public string LookupType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        
    }
}