using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Feature.Blog.Models
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.BlogAuthor.ID_String)]
    public interface IBlogAuthor : IBaseItem
    {
        string BlogAuthorName { get; set; }

        Image BlogAuthorPhoto { get; set; }

        string BlogAuthorBio { get; set; }
    }
}
