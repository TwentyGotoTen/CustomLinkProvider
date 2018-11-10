using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HelixDemo1.Foundation.Links
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextualLinkProvider : LinkProvider
    {
        private List<ILinkStrategy> _linkStrategies = new List<ILinkStrategy>();

        public ContextualLinkProvider()
        {
            XmlNode strategies = Factory.GetConfigNode("linkManager/strategies");

            foreach (XmlNode node in strategies)
            {
                string providerName = node.Attributes["provider"].Value.ToLower();
                var strategy = Factory.CreateObject<ILinkStrategy>(node);
                _linkStrategies.Add(strategy);
            }
        }

        public override string GetItemUrl(Item item, UrlOptions options)
        {
            var matchingStrategy = _linkStrategies.FirstOrDefault(s => s.MatchesContext(item));

            if(matchingStrategy != null)
            {
                return matchingStrategy.GetItemUrl(item, options);
            }
            else
            {
                return base.GetItemUrl(item, options);
            }
        }
    }
}