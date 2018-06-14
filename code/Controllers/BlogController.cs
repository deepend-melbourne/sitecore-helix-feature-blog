using System.Linq;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Feature.Blog.Models;
using Sitecore.Feature.Blog.Services;
using Sitecore.Foundation.Models.Services;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Foundation.Tags.Search;

namespace Sitecore.Feature.Blog.Controllers
{
    public class BlogController : GlassController
    {
        private readonly BlogArticleSearchService blogArticleService;
        private readonly TagSearchService tagSearchService;

        public BlogController(BlogArticleSearchService blogArticleService, TagSearchService tagSearchService)
        {
            this.blogArticleService = blogArticleService;
            this.tagSearchService = tagSearchService;
        }

        public ActionResult BlogListing(int? page)
        {
            var request = new BlogArticleSearchRequest()
            {
                RootPath = Context.Site.RootPath,
                Page = page ?? 1,
                PageSize = 10 // hard code to 10 for now
            };

            ApplyUrlQueryTagsToBlogSearchRequest(request);

            var searchResult = blogArticleService.Search(request);
            return View("~/Views/Feature/Blog/BlogListing.cshtml", searchResult);
        }

        public ActionResult BlogAuthor()
        {
            IBlogAuthor author = null;
            var item = GetLayoutItem<Item>();

            if (item.IsDerived(Templates.BlogArticle.ID))
            {
                var article = item.As<IBlogArticle>();
                author = article?.BlogAuthor;
            }
            else if (item.IsDerived(Templates.BlogAuthor.ID))
            {
                author = item.As<IBlogAuthor>();
            }

            return View("~/Views/Feature/Blog/BlogAuthor.cshtml", author);
        }

        void ApplyUrlQueryTagsToBlogSearchRequest(BlogArticleSearchRequest request)
        {
            var tagQueryString = Request.QueryString["tags"];
            if (string.IsNullOrEmpty(tagQueryString))
            {
                return;
            }

            var urlQueryTags = tagQueryString.Split(',');

            if (urlQueryTags != null && urlQueryTags.Any())
            {
                var tagSearchRequest = new TagSearchRequest
                {
                    RootPath = Context.Site.RootPath,
                    TagNames = urlQueryTags
                };

                var tags = tagSearchService.Search(tagSearchRequest);

                if (tags.Results.Any())
                {
                    request.TagIds = tags.Results.Select(u => new ID(u.Id)).ToArray();
                }
            }
        }
    }
}
