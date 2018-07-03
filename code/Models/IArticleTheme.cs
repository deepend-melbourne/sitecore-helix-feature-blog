using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Feature.Blog.Models
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.ArticleTheme.ID_String)]
    public interface IArticleTheme : IBaseItem
    {
        IArticleType ArticleType { get; set; }
    }
}
