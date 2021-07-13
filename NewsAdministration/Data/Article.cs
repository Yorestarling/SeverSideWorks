using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace NewsAdministration
{
    public partial class Article
    {
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Descriptions is Required")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Ulr is Required")]
        public string Ulr { get; set; }

        public string UlrToImage { get; set; }

        [DisplayName("Published At")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Published At is Required")]
        public DateTime? PublishedAt { get; set; }
        [Required(ErrorMessage = "Content is Required")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Sources Name is Required")]

        public int SourcesId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Countries Name is Required")]
        public int CountriesId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country Countries { get; set; }
        public virtual Source Sources { get; set; }

     

        //public decimal ActualDate { get { return PublishedAt = DateTime.Now; } }
    }
}
