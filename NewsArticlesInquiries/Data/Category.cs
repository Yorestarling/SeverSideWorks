using System;
using System.Collections.Generic;

#nullable disable

namespace NewsArticlesInquiries
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
