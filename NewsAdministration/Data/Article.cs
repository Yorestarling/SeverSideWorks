using System;
using System.Collections.Generic;

#nullable disable

namespace NewsAdministration
{
    public partial class Article
    {
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Ulr { get; set; }
        public string UlrToImage { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }
        public int SourcesId { get; set; }
        public int CategoryId { get; set; }
        public int CountriesId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country Countries { get; set; }
        public virtual Source Sources { get; set; }
    }
}
