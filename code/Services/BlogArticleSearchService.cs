using System.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Feature.Blog.Models;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.Foundation.Indexing.Services;

namespace Sitecore.Feature.Blog.Services
{
    [Service]
    public class BlogArticleSearchService : SearchService<BlogArticleSearchResultItem, BlogArticleSearchRequest, IBlogArticle>
    {
        public BlogArticleSearchService(DefaultSitecoreService sitecoreService)
            : base(sitecoreService)
        {
        }

        protected override IQueryable<BlogArticleSearchResultItem> ApplyPredicates(IQueryable<BlogArticleSearchResultItem> query, BlogArticleSearchRequest request)
        {
            if (request.TagIds != null && request.TagIds.Any())
            {
                query = ApplyTagIdPredicate(query, request.TagIds);
            }

            return ApplySortType(query, request.SortType);
        }

        private IQueryable<BlogArticleSearchResultItem> ApplySortType(IQueryable<BlogArticleSearchResultItem> query, BlogArticleSearchRequestSortType sortType)
        {
            switch (sortType)
            {
                case BlogArticleSearchRequestSortType.BlogDateDescending:
                    return query.OrderByDescending(u => u.BlogDate);
                case BlogArticleSearchRequestSortType.BlogDateAscending:
                    return query.OrderBy(u => u.BlogDate);
                default:
                    return query;
            }
        }

        private IQueryable<BlogArticleSearchResultItem> ApplyTagIdPredicate(IQueryable<BlogArticleSearchResultItem> query, ID[] tagIds)
        {
            var expression = PredicateBuilder.False<BlogArticleSearchResultItem>();

            foreach (var tagId in tagIds)
            {
                expression = expression.Or(i => i.Tags.Contains(IdHelper.NormalizeGuid(tagId)));
            }

            return query.Where(expression);
        }
    }
}
