namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Just blog context class.
    /// </summary>
    public class JustBlogContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JustBlogContext"/> class.
        /// </summary>
        public JustBlogContext()
            : base("name=JustBlogContext")
        {
            Database.SetInitializer(new JustBlogInitializer());
        }

        //// virtual for lazy loading

        /// <summary>
        /// Category dbset.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Posts dbset.
        /// </summary>
        public virtual DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Tags dbset.
        /// </summary>
        public virtual DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Comments dbset.
        /// </summary>
        public virtual DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Fluent API to configure many to many relationship.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Post>().HasMany(p => p.Tags).WithMany(t => t.Posts).Map(m =>
            {
                m.MapLeftKey("PostID");
                m.MapRightKey("TagID");
                m.ToTable("PostTagMap");
            });
        }

    }
}
