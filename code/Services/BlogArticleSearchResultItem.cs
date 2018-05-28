using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.Foundation.Indexing.Models;

namespace Sitecore.Feature.Blog.Services
{
    public class BlogArticleSearchResultItem : IndexedItem
    {
        [IndexField("blogdate")]
        public DateTime BlogDate { get; set; }

        [IndexField("tags")]
        public List<string> Tags { get; set; }
    }
}
