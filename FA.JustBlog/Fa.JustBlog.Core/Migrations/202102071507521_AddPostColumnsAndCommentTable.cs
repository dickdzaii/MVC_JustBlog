namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add comment table and view count ratecount, total rate for post table.
    /// </summary>
    public partial class AddPostColumnsAndCommentTable : DbMigration
    {
        /// <summary>
        /// Upgrade.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Comments",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 255),
                    PostID = c.Int(nullable: false),
                    CommentHeader = c.String(maxLength: 255),
                    CommentText = c.String(maxLength: 4000),
                    CommentTime = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);

            this.AddColumn("dbo.Tbl_post", "ViewCount", c => c.Int(nullable: false));
            this.AddColumn("dbo.Tbl_post", "RateCount", c => c.Int(nullable: false));
            this.AddColumn("dbo.Tbl_post", "TotalRate", c => c.Int(nullable: false));
        }

        /// <summary>
        /// Downgrade.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Comments", "PostID", "dbo.Tbl_post");
            this.DropIndex("dbo.Comments", new[] { "PostID" });
            this.DropColumn("dbo.Tbl_post", "TotalRate");
            this.DropColumn("dbo.Tbl_post", "RateCount");
            this.DropColumn("dbo.Tbl_post", "ViewCount");
            this.DropTable("dbo.Comments");
        }
    }
}
