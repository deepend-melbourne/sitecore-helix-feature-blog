using Sitecore.Feature.Blocks.Models;
using Sitecore.Feature.Blog.Models;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Feature.Blog.ViewModels
{
    public interface IBlogContent : IBaseItem, IBlogArticle, IPageBanner, IPageScheme
    {
    }
}
