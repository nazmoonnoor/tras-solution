namespace Tras.Core.Domain.Configuration
{
    public partial class Setting : BaseEntity
    {
        public Setting(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
