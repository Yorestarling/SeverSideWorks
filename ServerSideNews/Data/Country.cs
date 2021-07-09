using System;
using System.Collections.Generic;

#nullable disable

namespace ServerSideNews
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
        }

        public int CountriesId { get; set; }
        public string ContriesName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
