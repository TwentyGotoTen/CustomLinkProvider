using HelixDemo1.Foundation.Links;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace HelixDemo1.Feature.Products
{
    /// <summary>
    /// This class produces URLs for product item
    /// </summary>
    public class ProductLinkStrategy : AbstractLinkStrategy
    {
        public override string GetItemUrl(Item item, UrlOptions options)
        {
            var productPageItem = item.Database.GetItem("{}");
            var baseUrl = LinkManager.GetItemUrl(item, options);
            var productCode = item["Product code"];
            return $"{baseUrl}?={productCode}";
        }
    }
}