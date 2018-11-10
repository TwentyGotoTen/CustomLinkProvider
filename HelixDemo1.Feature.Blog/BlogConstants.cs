using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelixDemo1.Feature.Blog
{
    public class BlogConstants
    {
        public class Templates
        {
            public static readonly ID BlogTemplateId = new ID("{2A912DCD-ED25-4A9F-9C22-6592D4136CAE}");
        }
        public class Fields
        {
            public static readonly string BlogPostUrlName = "Blog post url name";
        }

        public class Wildcards
        {
            public static readonly string BlogToken = "BLOG POST URL NAME";
        }
    }
}