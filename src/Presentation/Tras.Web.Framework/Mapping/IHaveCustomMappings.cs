using AutoMapper;

namespace Tras.Web.Framework.Mapping
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IConfiguration configuration);
	}
}