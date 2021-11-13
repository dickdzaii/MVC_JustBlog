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
    /// Tag entity.
    /// </summary>
    public class Tag
    {
        [Key]
        [Column("TagID", TypeName = "INT")]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Tag name.")]
        public string TagName { get; set; }

        [Column("UrlSlug", TypeName = "VARCHAR")]
        [MaxLength(255)]
        public string UrlSlug { get; set; }

        [Column("Description", TypeName = "NVARCHAR")]

        [MaxLength(1024)]
        public string Description { get; set; }

        [Column("TagCount", TypeName = "INT")]
        [Range(0, int.MaxValue, ErrorMessage = "Count is a postive number.")]
        public int Count { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
