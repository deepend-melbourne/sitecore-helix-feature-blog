using Sitecore.Data;
using Sitecore.Foundation.Indexing.Search.Models;

namespace Sitecore.Feature.Blog.Services
{
    public class BlogArticleSearchRequest : SearchRequest
    {
        public BlogArticleSearchRequest()
        {
            TemplateIds = new[]
            {
                Templates.BlogArticle.ID
            };
        }

        public ID[] TagIds { get; set; }

        public BlogArticleSearchRequestSortType SortType { get; set; }
    }
}
