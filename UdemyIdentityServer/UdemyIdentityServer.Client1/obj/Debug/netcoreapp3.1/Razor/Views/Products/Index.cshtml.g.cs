#pragma checksum "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc92dc22cb4183cbc4f5cfd657923c90374080d7"
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
#line 1 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\_ViewImports.cshtml"
using UdemyIdentityServer.Client1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\_ViewImports.cshtml"
using UdemyIdentityServer.Client1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc92dc22cb4183cbc4f5cfd657923c90374080d7", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47be26540ee4e53df07cb6edb8e9a16efe40df8", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Products</h1>\r\n\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>Id</th>\r\n            <th>Name</th>\r\n            <th>Price</th>\r\n            <th>Stock</th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 21 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
               Write(product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
               Write(product.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 26 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\Products\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
