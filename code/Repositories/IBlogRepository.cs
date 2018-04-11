using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Sitecore.Feature.Blog.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<Item> Get(Item contextItem);
        IEnumerable<Item> GetLatest(Item contextItem, int skip, int take);
    }
}
