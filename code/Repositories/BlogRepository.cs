using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.Indexing.Repositories;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Feature.Blog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ISearchServiceRepository searchServiceRepository;

        public BlogRepository(ISearchServiceRepository searchServiceRepository)
        {
            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Item> Get(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }

            if (!contextItem.IsDerived(Templates.BlogFolder.ID))
            {
                throw new ArgumentException($"Item must derive from {nameof(Templates.BlogFolder)}", nameof(contextItem));
            }

            var searchService = this.searchServiceRepository.Get(new SearchSettingsBase
            {
                Templates = new[] { Templates.BlogArticle.ID }
            });

            searchService.Settings.Root = contextItem;

            // TODO: Refactor for scalability
            var results = searchService.FindAll();

            return results.Results.Select(x => x.Item).Where(x => x != null).OrderByDescending(i => i[Templates.BlogArticle.Fields.Date]);
        }

        public IEnumerable<Item> GetLatest(Item contextItem, int skip, int take)
        {
            // TODO: Refactor for scalability
            return this.Get(contextItem).Skip(skip).Take(take);
        }
    }
}
