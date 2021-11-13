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
    /// Comment entity.
    /// </summary>
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }

        public int PostID { get; set; }

        public Post Post { get; set; }

        [MaxLength(255)]
        public string CommentHeader { get; set; }

        [Column("CommentText", TypeName = "NVARCHAR")]
        public string CommentText { get; set; }

        public DateTime? CommentTime { get; set; }
    }
}
