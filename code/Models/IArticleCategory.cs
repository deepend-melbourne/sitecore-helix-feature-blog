using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Feature.Blog.Models
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.ArticleCategory.ID_String)]
    public interface IArticleCategory : IBaseItem
    {
    }
}
