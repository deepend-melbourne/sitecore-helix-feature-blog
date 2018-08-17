using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace Sitecore.Feature.Blog.Models
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.RenderingParameter_LatestNews.ID_String)]
    public interface IRenderingParameter_LastestNews
    {
        [SitecoreField(FieldId = Templates.RenderingParameter_LatestNews.Fields.ViewAllNewsLink_String)]
        Link ViewAllNewsLink { get; set; }
    }
}
