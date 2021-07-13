using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace NewsAdministration
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
        }

        public int CountriesId { get; set; }

        
        [Required(ErrorMessage = "Contries Name is Required")]
        public string ContriesName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
