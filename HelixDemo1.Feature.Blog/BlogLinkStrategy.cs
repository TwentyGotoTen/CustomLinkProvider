using HelixDemo1.Foundation.Links;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Marketing.Wildcards;
using System.Collections.Specialized;

namespace HelixDemo1.Feature.Blog
{
    public class BlogLinkStrategy : AbstractLinkStrategy
    {
        public override string GetItemUrl(Item item, UrlOptions options)
        {
            var tokenizedString = WildcardManager.Provider.GetWildcardUrl(item, options.Site);

            var data = new NameValueCollection();
            data.Add("BLOG POST URL NAME", item["Blog post url name"]);

            return tokenizedString.ReplaceTokens(data);
        }
    }
}