using System;
using System.Collections.Generic;

#nullable disable

namespace NewsAdministration
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
