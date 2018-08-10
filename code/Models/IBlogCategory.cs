using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Feature.Blog.Models
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.BlogCategory.ID_String)]
    public interface IBlogCategory : IBaseItem
    {
        [SitecoreField(FieldId = Templates.BlogCategory.Fields.BlogCategory_String)]
        string BlogCategory { get; set; }
    }
}
