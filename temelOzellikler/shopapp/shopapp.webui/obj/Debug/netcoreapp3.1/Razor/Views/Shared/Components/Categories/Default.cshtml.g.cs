#pragma checksum "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfe6cd02d0cc00c9ad0451e673e0857f7299c6fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Categories_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Categories/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfe6cd02d0cc00c9ad0451e673e0857f7299c6fe", @"/Views/Shared/Components/Categories/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd226c1f2d6a59590df7a514449febd42858bcb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Categories_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"list-group\">\n\n\n        <a href=\"/products\" class=\"list-group-item list-group-item-action title\">Tüm Kategoriler</a>             \n\n");
#nullable restore
#line 8 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
         foreach (var category in Model)
        {  
            
            if(ViewBag.SelectedCategory == category.Url){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 307, "\"", 337, 2);
            WriteAttributeValue("", 314, "/products/", 314, 10, true);
#nullable restore
#line 12 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
WriteAttributeValue("", 324, category.Url, 324, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" asp-route-category=\"halil\" class=\"list-group-item list-group-item-action title active\">");
#nullable restore
#line 12 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
                                                                                                                                    Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>             \n");
#nullable restore
#line 13 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
            }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 495, "\"", 525, 2);
            WriteAttributeValue("", 502, "/products/", 502, 10, true);
#nullable restore
#line 14 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
WriteAttributeValue("", 512, category.Url, 512, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" asp-route-category=\"halil\" class=\"list-group-item list-group-item-action title\">");
#nullable restore
#line 14 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
                                                                                                                             Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>             \n");
#nullable restore
#line 15 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shared/Components/Categories/Default.cshtml"
            }         



        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

</div>

<script>

    let title = document.querySelectorAll("".list-group-item"")

    let varMi = false;
    title.forEach(element => {

        if(element.classList.value.includes(""active"") == true){
            varMi = true
        }
    })

    if(!varMi){
        title[0].className = title[0].className + "" active""
    }    

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
