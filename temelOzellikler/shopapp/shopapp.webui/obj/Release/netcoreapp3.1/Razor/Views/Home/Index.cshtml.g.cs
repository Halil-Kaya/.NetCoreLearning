#pragma checksum "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54aa37873468a58d3e97675c7fe53f38d71cbb31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using shopapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using shopapp.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using temelOzellikler.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54aa37873468a58d3e97675c7fe53f38d71cbb31", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd226c1f2d6a59590df7a514449febd42858bcb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<temelOzellikler.ViewModels.ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n\n\n");
            DefineSection("Header", async() => {
                WriteLiteral("\n        ");
#nullable restore
#line 7 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
   Write(await Html.PartialAsync("_header"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-md-3\">\n        \n        ");
#nullable restore
#line 13 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
   Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 14 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
   Write(await Html.PartialAsync("_search"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n    </div>\n    <div class=\"col-md-9\">\n\n        <div class=\"row\">\n");
#nullable restore
#line 20 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
             foreach (var product in Model.products)
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\n                ");
#nullable restore
#line 24 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
           Write(await Html.PartialAsync("_product",product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n");
#nullable restore
#line 26 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Home/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n\n    </div>\n</div>\n\n\n\n\n\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-3.5.1.slim.min.js"" integrity=""sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj"" crossorigin=""anonymous""></script>
    <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"" integrity=""sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN"" crossorigin=""anonymous""></script>
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"" integrity=""sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV"" crossorigin=""anonymous""></script>   
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<temelOzellikler.ViewModels.ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
