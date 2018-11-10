using Sitecore.Data.Items;
using Sitecore.Links;
using System.Collections.Generic;

namespace HelixDemo1.Foundation.Links
{
    public abstract class AbstractLinkStrategy : ILinkStrategy
    {
        public List<string> Sites { get; set; }
        public List<string> Templates { get; set; }

        public bool MatchesContext(Item item)
        {
            var siteName = Sitecore.Context.Site?.Name;

            if (siteName == null)
            {
                return false;
            }

            var matchingSite = Sites.Contains(siteName);
            var matchingTemplate = Templates.Contains(item.TemplateID.ToString());

            return matchingSite && matchingTemplate;
        }

        public abstract string GetItemUrl(Item item, UrlOptions options);
    }
}