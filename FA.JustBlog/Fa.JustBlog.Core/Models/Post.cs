namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Post entity.
    /// </summary>
    [Table("Tbl_post")]
    public class Post
    {
        [Key]
        [Column("PostID",TypeName ="INT")]
        public int ID { get; set; }

        [Column("Title", TypeName = "NVARCHAR")]
        [MaxLength(255,ErrorMessage ="Title is max 255")]
        [Required(ErrorMessage = "Title can't be empty")]
        public string Title { get; set; }

        [Column("ShortDescription", TypeName = "NVARCHAR")]

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Column("PostContent")]
        public string PostContent { get; set; }

        [MaxLength(255)]
        public string UrlSlug { get; set; }

        [Column("IsPublishedFlag", TypeName = "BIT")]
        public bool Published { get; set; }

        [Column("PostedDate")]
        public DateTime PostedOn { get; set; }

        [Column("ModifiedDate")]
        public DateTime? Modified { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        [Column("ViewCount", TypeName = "int")]
        [Range(0, int.MaxValue)]
        public int ViewCount { get; set; }

        [Column("RateCount", TypeName = "INT")]
        [Range(0, int.MaxValue)]
        public int RateCount { get; set; }

        [Column("TotalRate", TypeName = "INT")]
        [Range(0, int.MaxValue)]
        public int TotalRate { get; set; }

        public decimal Rate
        {
            get { return this.RateCount != 0 ? Math.Round(this.TotalRate * 1.0m / this.RateCount, 2) : 0; }
        }

        public virtual IList<Comment> Comments { get; set; }
    }
}
