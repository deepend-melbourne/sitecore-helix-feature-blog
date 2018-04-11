using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Feature.Blog.Models;
using Sitecore.Data.Items;
using Sitecore.Feature.Blog.Repositories;
using Sitecore.Foundation.Models.Services;
using System.Linq;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Feature.Blog.Controllers
{
    public class BlogController : GlassController
    {
        private IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ActionResult BlogListing()
        {
            var datasource = GetLayoutItem<Item>();

            var blogItems = _blogRepository.Get(datasource)
                .Select(x => ModelService.As<IBlogArticle>(x));

            return View("~/Views/Feature/Blog/BlogListing.cshtml", blogItems);
        }

        public ActionResult BlogAuthor()
        {
            IBlogAuthor author = null;
            var item = GetLayoutItem<Item>();

            if(item.IsDerived(Templates.BlogArticle.ID))
            {
                var article = item.As<IBlogArticle>();
                author = article?.BlogAuthor;
            }
            else if(item.IsDerived(Templates.BlogAuthor.ID))
            {
                author = item.As<IBlogAuthor>();
            }

            return View("~/Views/Feature/Blog/BlogAuthor.cshtml", author);
        }
    }
}
