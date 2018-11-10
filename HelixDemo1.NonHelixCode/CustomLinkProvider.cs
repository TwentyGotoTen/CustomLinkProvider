using HelixDemo1.Feature.Blog;
using HelixDemo1.Feature.Products;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Marketing.Wildcards;
using System.Collections.Specialized;

namespace HelixDemo1.NonHelixCode
{
    public class CustomLinkProvider : LinkProvider
    {
        public override string GetItemUrl(Item item, UrlOptions options)
        {
            if (item.TemplateID == ProductsConstants.Templates.ProductTemplateID)
            {
                // PRODUCT URL
                var baseUrl = base.GetItemUrl(item, options);
                var productCode = item[ProductsConstants.Fields.ProductCode];
                return $"{baseUrl}?id={productCode}";
            }
            else if (options.Site.Name == "ConsumerSite" && item.TemplateID == BlogConstants.Templates.BlogTemplateId)
            {
                // BLOG URL
                var tokenizedString = WildcardManager.Provider.GetWildcardUrl(item, options.Site);

                var data = new NameValueCollection();
                data.Add(BlogConstants.Wildcards.BlogToken, item[BlogConstants.Fields.BlogPostUrlName]);

                return tokenizedString.ReplaceTokens(data);
            }

            return base.GetItemUrl(item, options);
        }
    }
}

