using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelixDemo1.Foundation.Links
{
    public interface ILinkStrategy
    {
        bool MatchesContext(Item item);
        string GetItemUrl(Item item, UrlOptions options);
    }
}
