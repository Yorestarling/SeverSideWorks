using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Sources Name is Required")]
        public string SourcesName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
