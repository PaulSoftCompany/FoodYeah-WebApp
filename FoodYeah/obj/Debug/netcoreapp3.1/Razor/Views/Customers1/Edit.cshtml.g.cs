#pragma checksum "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customers1\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b037ef89e823db1e1e5d3d0fa8f646fdb4d6a31c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customers1_Edit), @"mvc.1.0.view", @"/Views/Customers1/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b037ef89e823db1e1e5d3d0fa8f646fdb4d6a31c", @"/Views/Customers1/Edit.cshtml")]
    public class Views_Customers1_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FoodYeah.Model.Customer>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customers1\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Customer</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""CustomerId"" />
            <div class=""form-group"">
                <label asp-for=""Customer_CategoryId"" class=""control-label""></label>
                <select asp-for=""Customer_CategoryId"" class=""form-control"" asp-items=""ViewBag.Customer_CategoryId""></select>
                <span asp-validation-for=""Customer_CategoryId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""CustomerName"" class=""control-label""></label>
                <input asp-for=""CustomerName"" class=""form-control"" />
                <span asp-validation-for=""CustomerName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""CustomerAge"" class=""control-label""><");
            WriteLiteral(@"/label>
                <input asp-for=""CustomerAge"" class=""form-control"" />
                <span asp-validation-for=""CustomerAge"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 43 "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customers1\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FoodYeah.Model.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
