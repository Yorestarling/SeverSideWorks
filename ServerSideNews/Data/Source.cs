using System;
using System.Collections.Generic;

#nullable disable

namespace ServerSideNews
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        public int SourcesId { get; set; }
        public string SourcesName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
