#pragma checksum "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customer_Category1\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5effe68770455142da147eeb95a3d400e80ce5ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Category1_Create), @"mvc.1.0.view", @"/Views/Customer_Category1/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5effe68770455142da147eeb95a3d400e80ce5ae", @"/Views/Customer_Category1/Create.cshtml")]
    public class Views_Customer_Category1_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FoodYeah.Model.Customer_Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customer_Category1\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>Customer_Category</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Customer_CategoryName"" class=""control-label""></label>
                <input asp-for=""Customer_CategoryName"" class=""form-control"" />
                <span asp-validation-for=""Customer_CategoryName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Customer_CategoryDescription"" class=""control-label""></label>
                <input asp-for=""Customer_CategoryDescription"" class=""form-control"" />
                <span asp-validation-for=""Customer_CategoryDescription"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
       ");
            WriteLiteral(" </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 37 "D:\GitHub Repos\FoodYeah-WebApp\FoodYeah\Views\Customer_Category1\Create.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FoodYeah.Model.Customer_Category> Html { get; private set; }
    }
}
#pragma warning restore 1591