#pragma checksum "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d71098ad55fc9405ef5181ef96e8c5daa32a9642"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
#line 1 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/_ViewImports.cshtml"
using UdemyIdentityServer.Client1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/_ViewImports.cshtml"
using UdemyIdentityServer.Client1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d71098ad55fc9405ef5181ef96e8c5daa32a9642", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47be26540ee4e53df07cb6edb8e9a16efe40df8", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Products</h1>\n\n<table class=\"table table-bordered\">\n    <thead>\n        <tr>\n            <th>Id</th>\n            <th>Name</th>\n            <th>Price</th>\n            <th>Stock</th>\n        </tr>\n    </thead>\n\n    <tbody>\n");
#nullable restore
#line 18 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 21 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
               Write(product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 22 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 23 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 24 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
               Write(product.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 26 "/home/ubunter/Desktop/NetCoreLearning/UdemyIdentityServer/UdemyIdentityServer.Client1/Views/Products/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
