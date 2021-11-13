namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Upgrade.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Categories",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false, maxLength: 255),
                    UrlSlug = c.String(maxLength: 255),
                    Description = c.String(maxLength: 1024),
                })
                .PrimaryKey(t => t.ID);

            this.CreateTable(
                "dbo.Tbl_post",
                c => new
                {
                    PostID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 255, unicode: false),
                    ShortDescription = c.String(maxLength: 500, unicode: false),
                    PostContent = c.String(maxLength: 1024, unicode: false),
                    UrlSlug = c.String(maxLength: 255),
                    IsPublishedFlag = c.Boolean(nullable: false),
                    PostedDate = c.DateTime(),
                    ModifiedDate = c.DateTime(),
                    CategoryID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);

            this.CreateTable(
                "dbo.Tags",
                c => new
                {
                    TagID = c.Int(nullable: false, identity: true),
                    TagName = c.String(nullable: false, maxLength: 255),
                    UrlSlug = c.String(maxLength: 255, unicode: false),
                    Description = c.String(maxLength: 1024),
                    TagCount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.TagID);

            this.CreateTable(
                "dbo.PostTagMap",
                c => new
                {
                    PostID = c.Int(nullable: false),
                    TagID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Tbl_post", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
        }

        /// <summary>
        /// Downgrate.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.PostTagMap", "TagID", "dbo.Tags");
            this.DropForeignKey("dbo.PostTagMap", "PostID", "dbo.Tbl_post");
            this.DropForeignKey("dbo.Tbl_post", "CategoryID", "dbo.Categories");
            this.DropIndex("dbo.PostTagMap", new[] { "TagID" });
            this.DropIndex("dbo.PostTagMap", new[] { "PostID" });
            this.DropIndex("dbo.Tbl_post", new[] { "CategoryID" });
            this.DropTable("dbo.PostTagMap");
            this.DropTable("dbo.Tags");
            this.DropTable("dbo.Tbl_post");
            this.DropTable("dbo.Categories");
        }
    }
}
