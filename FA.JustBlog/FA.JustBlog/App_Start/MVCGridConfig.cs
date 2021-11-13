[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FA.JustBlog.MVCGridConfig), "RegisterGrids")]

namespace FA.JustBlog
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using FA.JustBlog.Core.Models;
    using FA.JustBlog.Core.Repositories;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("Post", new MVCGridBuilder<Post>()
    .WithAuthorizationType(AuthorizationType.AllowAnonymous)
    .WithSorting(sorting: true, defaultSortColumn: "ID", defaultSortDirection: SortDirection.Dsc)
    .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
    .WithAdditionalQueryOptionNames("search")
    .AddColumns(cols =>
    {
        cols.Add("Id").WithValueExpression((p, c) => c.UrlHelper.Action("detail", "demo", new { id = p.ID }))
            .WithValueTemplate("<a href='{Value}'>{Model.Id}</a>", false)
            .WithPlainTextValueExpression(p => p.ID.ToString());
        cols.Add("Title").WithHeaderText("Title")
            .WithVisibility(true, true)
            .WithValueExpression(p => p.Title);
        cols.Add("ShortDescription").WithHeaderText("Short Description")
            .WithVisibility(true, true)
            .WithValueExpression(p => p.ShortDescription);
        cols.Add("Published").WithHeaderText("Published")
            .WithValueExpression(p => p.Published ? "Yes" : "No")
            .WithVisibility(visible: true, allowChangeVisibility: true)
            .WithSorting(false)
            .WithCellCssClassExpression(p => p.Published ? "success" : "danger");
        cols.Add("PostedOn").WithHeaderText("Posted On")
            .WithVisibility(visible: true, allowChangeVisibility: true)
            .WithValueExpression(p => p.PostedOn.ToString("dd/MM/yyyy"));
        cols.Add("Rate")
            .WithVisibility(visible: true, allowChangeVisibility: true)
            .WithHeaderText("Rate")
            .WithValueExpression(p => p.Rate.ToString());
        cols.Add("Url").WithVisibility(false)
            .WithValueExpression((p, c) => c.UrlHelper.Action("detail", "demo", new { id = p.ID }));
    })
    //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
    .WithRetrieveDataMethod((context) =>
    {
        var options = context.QueryOptions;
        int totalRecords;
        var repo = DependencyResolver.Current.GetService<PostRepository>();
        string globalSearch = options.GetAdditionalQueryOptionString("search");
        string sortColumn = options.GetSortColumnData<string>();
        var items = repo.GetAll();
        return new QueryResult<Post>()
        {
            Items = items,
            
        };
    })
);
        }
    }
}